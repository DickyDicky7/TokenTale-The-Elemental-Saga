@tool
extends BTAction;

func _generate_name() -> String:
	return  "DetectCharacter2" ;
	
@export var TargetCharacter3DName: StringName;
@export var   PathShapeCast3D              : NodePath;
@export var                  PathEyeSight3D: NodePath;

var currentCharacter: Character3D;
var shapeCast3D: ShapeCast3D;
var  eyeSight3D:  EyeSight3D;
var rootScale  : Array      ;
var alreadyDetect:    bool  ;

func _setup() -> void:
	currentCharacter = agent;
	shapeCast3D = agent.get_node(
PathShapeCast3D                 );
	eyeSight3D  = agent.get_node(
PathEyeSight3D                  );
	eyeSight3D.visible = false;
	blackboard.set_var(BBVariable.RootScale    , [shapeCast3D.scale.x]);
	blackboard.set_var(BBVariable.AlreadyDetect,              false   );
	pass;
	
func _enter() -> void:
	rootScale = blackboard.get_var(BBVariable.RootScale);
	pass;
	
func _exit () -> void:
	alreadyDetect = blackboard.get_var      (
					BBVariable.AlreadyDetect);
	if (alreadyDetect == false):
		shapeCast3D.scale = Vector3(rootScale[0] * 1, 1, rootScale[0] * 1);
	else:
		shapeCast3D.scale = Vector3(rootScale[0] * 2, 1, rootScale[0] * 2);
	pass;
	
func _tick(_delta: float) -> Status:
	if (           currentCharacter.IsStunning == true):
		return FAILURE;
	if (shapeCast3D.is_colliding()):
		for i in range(shapeCast3D.collision_result.size()):
			var  targetCharacter: Object =                  shapeCast3D.get_collider(i);
			if  (targetCharacter != null
			&&   targetCharacter is Character3D
			&&   targetCharacter.   name == TargetCharacter3DName):
				blackboard.set_var(BBVariable.AlreadyDetect  , true           );
				blackboard.set_var(BBVariable.TargetCharacter, targetCharacter);
				var  targetCharacterVector: Vector3 =  Helper.ProjectVector3ToPlane(
					currentCharacter.position.direction_to(
					 targetCharacter.position)
					, Vector3.UP
				).normalized();
				var targetCharacterAngle: float = Helper.StandardizeDegree(
					rad_to_deg(
					targetCharacterVector
						.signed_angle_to(Vector3(1, 0, 0), Vector3.DOWN)) );
				blackboard. set_var                         (
				BBVariable.SeeingAngle, targetCharacterAngle);
				return SUCCESS;
		blackboard.set_var             (
		BBVariable.AlreadyDetect, false);
		return FAILURE;
	blackboard.set_var             (
	BBVariable.AlreadyDetect, false);
	return FAILURE;
