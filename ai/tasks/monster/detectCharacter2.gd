@tool
extends BTAction

func _generate_name() -> String:
	return "DetectCharacter2";
	
@export var TargetCharacter3DName: StringName
@export var PathShapeCast3D: NodePath
@export var PathEyeSight3D: NodePath

var currentCharacter: Character3D
var shapeCast3D: ShapeCast3D
var eyeSight3D: EyeSight3D
var rootScale: float
var alreadyDetect: bool

func _setup() -> void:
	currentCharacter = agent
	shapeCast3D = agent.get_node(PathShapeCast3D)
	eyeSight3D = agent.get_node(PathEyeSight3D)
	blackboard.set_var(BBVariable.RootScale2, shapeCast3D.scale.x)
	blackboard.set_var(BBVariable.AlreadyDetect, false)
	pass;
	
func _enter() -> void:
	eyeSight3D.visible = false
	rootScale = blackboard.get_var(BBVariable.RootScale2)
	alreadyDetect = blackboard.get_var(BBVariable.AlreadyDetect)
	if (alreadyDetect == false):
		shapeCast3D.scale = Vector3(rootScale, 1, rootScale)
	else:
		shapeCast3D.scale = Vector3(rootScale * 2, 1, rootScale * 2)
	pass;
	
func _exit() -> void:
	pass;
	
func _tick(_delta: float) -> Status:
	if (shapeCast3D.is_colliding()):
		for i in range(shapeCast3D.collision_result.size()):
			var  targetCharacter:Object = shapeCast3D.get_collider(i);
			if  (targetCharacter != null
			&&   targetCharacter is Character3D
			&&   targetCharacter.name == TargetCharacter3DName):
				blackboard.set_var(BBVariable.AlreadyDetect, true)
				blackboard.set_var(BBVariable.TargetCharacter, targetCharacter)
				return SUCCESS
		blackboard.set_var(BBVariable.AlreadyDetect, false)
		return FAILURE
	blackboard.set_var(BBVariable.AlreadyDetect, false)
	return FAILURE;
