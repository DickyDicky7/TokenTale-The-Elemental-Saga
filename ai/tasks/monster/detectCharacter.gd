@tool
extends BTAction

func _generate_name() -> String:
	return "DetectCharacter";
	
@export var TargetCharacter3DName: StringName;
@export var PathShapeCast3D: NodePath; @export var PathRayCast3D: NodePath;
@export var PathEyeSight   : NodePath;

var currentCharacter: Character3D;
var shapeCast3D     : ShapeCast3D; var rayCast3D: RayCast3D;
var eyeSight        : Node3D;
var SeeingAngle     : float ;
var minSeeableAngle : float ;
var maxSeeableAngle : float ;
var alreadyDetect   : bool  ;
var rootScale : Array

func _setup() -> void:
	currentCharacter = agent;
	shapeCast3D      = agent.get_node(PathShapeCast3D); rayCast3D = agent.get_node(PathRayCast3D);
	eyeSight         = agent.get_node(PathEyeSight);
	blackboard.set_var(BBVariable.SeeingAngle  , 0    );
	blackboard.set_var(BBVariable.AlreadyDetect, false);
	blackboard.set_var(BBVariable.RootScale, [shapeCast3D.scale.x, rayCast3D.target_position.x])
	pass;

func _enter() -> void:
	eyeSight.visible = true
	SeeingAngle = blackboard.get_var(BBVariable.SeeingAngle)
	SeeingAngle =     Helper.StandardizeDegree(SeeingAngle     );
	minSeeableAngle = Helper.StandardizeDegree(SeeingAngle - 45);
	maxSeeableAngle = Helper.StandardizeDegree(SeeingAngle + 45);
	alreadyDetect = blackboard.get_var(BBVariable.AlreadyDetect);
	rootScale = blackboard.get_var(BBVariable.RootScale)
	if (alreadyDetect == false):
		var scaleVector: Vector3 = Vector3(rootScale[0], 1, rootScale[0])
		shapeCast3D.scale = scaleVector; rayCast3D.target_position.x = rootScale[1];
		var tween : Tween = currentCharacter.create_tween();
		tween.tween_property(eyeSight, "scale", scaleVector, 0.5);
		tween.set_ease (Tween. EASE_OUT );
		tween.set_trans(Tween.TRANS_CIRC);
	else:
		var scaleVector: Vector3 = Vector3(rootScale[0] * 2, 1, rootScale[0] * 2)
		shapeCast3D.scale = scaleVector; rayCast3D.target_position.x = rootScale[1] * 2;
		var tween : Tween = currentCharacter.create_tween();
		tween.tween_property(eyeSight, "scale", scaleVector, 0.5);
		tween.set_ease (Tween. EASE_OUT );
		tween.set_trans(Tween.TRANS_CIRC);
	pass;

func _exit() -> void:
	rayCast3D.position = rayCast3D.position
	rayCast3D.target_position = rayCast3D.target_position
	rayCast3D.force_raycast_update()
	pass;

func _tick(_delta: float) -> Status:
	if (currentCharacter.IsStunning == true):
		return FAILURE
	if (shapeCast3D.is_colliding()):
		for i in range(  shapeCast3D.collision_result.size()  ):
			var  targetCharacter:Object = shapeCast3D.get_collider(i);
			if  (targetCharacter != null
			&&   targetCharacter is Character3D
			&&   targetCharacter.name == TargetCharacter3DName):
				#projected Vector on XZ of CurrentChar To TargetChar
				var  targetCharacterVector: Vector3 =  Helper.ProjectVector3ToPlane(
					currentCharacter.position.direction_to(targetCharacter.position)
					, Vector3.UP
				).normalized();
				var targetCharacterAngle: float = Helper.StandardizeDegree(
					rad_to_deg(
					targetCharacterVector
						.signed_angle_to(Vector3(1, 0, 0), Vector3.DOWN))
				);
				rayCast3D.position = rayCast3D.position;
				if (alreadyDetect == false):
					return PatrollDetection(targetCharacterAngle, targetCharacter);
				else:
					return  ActionDetection(targetCharacterAngle, targetCharacter);
	if (alreadyDetect == true):
		blackboard.set_var(BBVariable.AlreadyDetect, false);
	return FAILURE;

func PatrollDetection(targetCharacterAngle: float, targetCharacter: Object) -> Status:
	var realAngle: float = Helper.Clamp_StandardAngle(
		targetCharacterAngle
		, minSeeableAngle
		, maxSeeableAngle
	);
	rayCast3D.rotation_degrees.y = realAngle;	
	rayCast3D.force_raycast_update()
	if (rayCast3D.get_collider_rid() == targetCharacter .get_rid()):
		blackboard.set_var(BBVariable.TargetCharacter, targetCharacter);
		blackboard.set_var(BBVariable.SeeingAngle  , Helper.StandardizeDegree(realAngle));
		blackboard.set_var(BBVariable.AlreadyDetect, true);
		return SUCCESS;
	return FAILURE;

func ActionDetection(targetCharactedAngle: float, targetCharacter: Object) -> Status:
	rayCast3D.rotation_degrees.y = targetCharactedAngle;
	rayCast3D.force_raycast_update()
	blackboard.set_var(BBVariable.TargetCharacter, targetCharacter);
	blackboard.set_var(BBVariable.SeeingAngle    , Helper.StandardizeDegree(targetCharactedAngle));
	return SUCCESS;


