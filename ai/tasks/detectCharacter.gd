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
var MinSeeableAngle: float
var MaxSeeableAngle: float
var AlreadyDetect: bool

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
	MinSeeableAngle = helper.StandardizeDegree(SeeingAngle - 45)
	MaxSeeableAngle = helper.StandardizeDegree(SeeingAngle + 45)
	AlreadyDetect = blackboard.get_var(BBAlreadyDetect)
	if (AlreadyDetect == false):
		shapeCast3D.scale = Vector3(2, 2, 2)
		rayCast3D.scale = Vector3(2, 2, 2)
		eyeSight.scale = Vector3(2, 2, 2)
	else:
		shapeCast3D.scale = Vector3(4, 4, 4)
		rayCast3D.scale = Vector3(4, 4, 4)
		eyeSight.scale = Vector3(4, 4, 4)
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
				if (AlreadyDetect == false):
					return PatrollDetection(targetCharacterAngle, targetCharacter)
				else:
					return ActionDetection(targetCharacterAngle, targetCharacter)
	if (AlreadyDetect == true):
		blackboard.set_var(BBAlreadyDetect, false)
	return FAILURE

func PatrollDetection(targetCharacterAngle: float, targetCharacter: Object) -> Status:
	var realAngle: float = helper.Clamp_StandardAngle(
		targetCharacterAngle
		, MinSeeableAngle
		, MaxSeeableAngle
	)
	rayCast3D.rotation_degrees.y = realAngle
	#var rayCastLength: float = rayCast3D.position.distance_to(rayCast3D.target_position)
	#rayCast3D.target_position = Vector3(
		#cos(realAngle) * rayCastLength
		#, rayCast3D.target_position.y
		#, sin(realAngle) * rayCastLength)	
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
