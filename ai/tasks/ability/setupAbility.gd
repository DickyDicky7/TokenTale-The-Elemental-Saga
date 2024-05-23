@tool
extends BTAction

func _generate_name() -> String:
	return "Setup Activity";
	
@export var PathHitBox: NodePath

var HitBox3D: Hittbox3D

func _setup() -> void:
	HitBox3D = agent.get_node(PathHitBox)
	HitBox3D.StartWatching()
	pass;
	
func _enter() -> void:
	pass;
	
func _exit() -> void:
	pass;
	
func _tick(_delta: float) -> Status:
	return SUCCESS
