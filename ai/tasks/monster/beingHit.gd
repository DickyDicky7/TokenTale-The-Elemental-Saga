@tool
extends BTAction;

func _generate_name() -> String:
	return "BeingHit";

@export var PathHurtbox3D: NodePath;

var currentCharacter: Character3D;
var        hurtbox3D:   Hurtbox3D;
func _setup() -> void:
	currentCharacter = agent;
	hurtbox3D        = agent.get_node(PathHurtbox3D);
	hurtbox3D.        Character3D = currentCharacter;
	hurtbox3D.StartWatching();
	pass;

func _enter() -> void:
	pass;
	
func _exit () -> void:
	if (hurtbox3D.Hurt):
		hurtbox3D.Hurt = false;
	pass;
	
func _tick(_delta: float) -> Status:
	if (hurtbox3D.Hurt):
		#blackboard.set_var(BBVariable.AlreadyDetect, true)
		return SUCCESS;
	else:
		return FAILURE;
