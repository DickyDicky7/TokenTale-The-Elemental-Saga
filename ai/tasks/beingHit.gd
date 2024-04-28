@tool
extends BTAction

func _generate_name() -> String:
	return "BeingHit";

@export var PathHurtBox3D: NodePath

var currentCharacter: Character3D
var hurtBox3D: HurtBox3d

func _setup() -> void:
	currentCharacter = agent
	hurtBox3D = agent.get_node(PathHurtBox3D)
	hurtBox3D.Character3D = currentCharacter
	hurtBox3D.StartWatching()
	pass;

func _enter() -> void:
	pass;
	
func _exit() -> void:
	if (hurtBox3D.Hurt == true):
		hurtBox3D.Hurt = false
	pass;
	
func _tick(_delta: float) -> Status:
	if (hurtBox3D.Hurt == true):
		return SUCCESS
	else:
		return FAILURE
