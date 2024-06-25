@tool
extends BTAction;

func _generate_name() -> String:
	return "BeingHit";

@export var PathHurtbox3D: NodePath;
@export var PathShapeCast3D: NodePath

var currentCharacter: Character3D;
var        hurtbox3D:   Hurtbox3D;
var shapeCast3D: ShapeCast3D
var rootScale: Array
var alreadyDetect: bool
func _setup() -> void:
	currentCharacter = agent;
	shapeCast3D = agent.get_node(PathShapeCast3D)
	hurtbox3D        = agent.get_node(PathHurtbox3D);
	hurtbox3D.        Character3D = currentCharacter;
	hurtbox3D.StartWatching();
	pass;
func _enter() -> void:
	rootScale = blackboard.get_var(BBVariable.RootScale)
	pass;
	
func _exit () -> void:
	if (hurtbox3D.Hurt):
		hurtbox3D.Hurt = false;
	alreadyDetect = blackboard.get_var(BBVariable.AlreadyDetect)
	if (alreadyDetect == false):
		shapeCast3D.scale = Vector3(rootScale[0], 1, rootScale[0])
	else:
		shapeCast3D.scale = Vector3(rootScale[0] * 2, 1, rootScale[0] * 2)
	pass;
	
func _tick(_delta: float) -> Status:
	if (hurtbox3D.Hurt):
		blackboard.set_var(BBVariable.AlreadyDetect, true)
		return SUCCESS;
	else:
		return FAILURE;
