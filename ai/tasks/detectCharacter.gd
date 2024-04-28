@tool
extends BTAction

func _generate_name() -> String:
	return "DetectCharacter";
	
@export var TargetCharacter3DName: StringName
@export var PathShapeCast3D: NodePath
@export var PathRayCast3D: NodePath
@export var PathEyeSight: NodePath

var currentCharacter: Character3D
var shapeCast3D: ShapeCast3D
var rayCast3D: RayCast3D
var eyeSight: Node3D
var SeeingAngle: float
var minSeeableAngle: float
var maxSeeableAngle: float
var alreadyDetect: bool

var BBSeeingAngle: StringName = "SeeingAngle"
var BBTargetCharacter: StringName = "TargetCharacter"
var BBAlreadyDetect: StringName = "AlreadyDetect"
var helper: Helper = Helper.GetInstance()

func _setup() -> void:
	currentCharacter = agent
	shapeCast3D = agent.get_node(PathShapeCast3D);
	rayCast3D = agent.get_node(PathRayCast3D);
	eyeSight = agent.get_node(PathEyeSight)
	blackboard.set_var(BBSeeingAngle, 0)
	blackboard.set_var(BBAlreadyDetect, false)
	pass;
func _enter() -> void:
	SeeingAngle = blackboard.get_var(BBSeeingAngle)
	SeeingAngle = helper.StandardizeDegree(SeeingAngle);
	minSeeableAngle = helper.StandardizeDegree(SeeingAngle - 45)
	maxSeeableAngle = helper.StandardizeDegree(SeeingAngle + 45)
	alreadyDetect = blackboard.get_var(BBAlreadyDetect)
	if (alreadyDetect == false):
		shapeCast3D.scale = Vector3(2, 1, 2)
		rayCast3D.target_position.x = 0.5
		eyeSight.scale = Vector3(2, 1, 2)
	else:
		shapeCast3D.scale = Vector3(4, 1, 4)
		rayCast3D.target_position.x = 1
		eyeSight.scale = Vector3(4, 1, 4)
	pass;

func _exit() -> void:
	pass;

func _tick(_delta: float) ->Status:
	if (shapeCast3D.is_colliding()):
		for i in range(shapeCast3D.collision_result.size()):
			var  targetCharacter:Object = shapeCast3D.get_collider(i);
			if  (targetCharacter != null
			&& targetCharacter is Character3D
			&& targetCharacter.name == TargetCharacter3DName):
				#projected Vector on XZ of CurrentChar To TargetChar
				var targetCharacterVector: Vector3 = helper.ProjectVector3ToPlane(
					currentCharacter.position.direction_to(targetCharacter.position)
					, Vector3.UP
				).normalized()
				var targetCharacterAngle: float = helper.StandardizeDegree(
					rad_to_deg(
						targetCharacterVector
						.signed_angle_to(Vector3(1, 0, 0), Vector3.DOWN))
				)
				rayCast3D.position = rayCast3D.position
				if (alreadyDetect == false):
					return PatrollDetection(targetCharacterAngle, targetCharacter)
				else:
					return ActionDetection(targetCharacterAngle, targetCharacter)
	if (alreadyDetect == true):
		blackboard.set_var(BBAlreadyDetect, false)
	return FAILURE

func PatrollDetection(targetCharacterAngle: float, targetCharacter: Object) -> Status:
	var realAngle: float = helper.Clamp_StandardAngle(
		targetCharacterAngle
		, minSeeableAngle
		, maxSeeableAngle
	)
	rayCast3D.rotation_degrees.y = realAngle	
	rayCast3D.force_raycast_update()
	if (rayCast3D.get_collider_rid() == targetCharacter.get_rid()):
		blackboard.set_var(BBTargetCharacter, targetCharacter)
		blackboard.set_var(BBSeeingAngle, helper.StandardizeDegree(realAngle))
		blackboard.set_var(BBAlreadyDetect, true)
		return SUCCESS;
	return FAILURE;

func ActionDetection(targetCharactedAngle: float, targetCharacter: Object) -> Status:
	rayCast3D.rotation_degrees.y = targetCharactedAngle
	rayCast3D.force_raycast_update()
	blackboard.set_var(BBTargetCharacter, targetCharacter)
	blackboard.set_var(BBSeeingAngle, helper.StandardizeDegree(targetCharactedAngle))
	return SUCCESS
