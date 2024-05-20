@tool
extends BTAction

func _generate_name() -> String:
	return "Ability Activity";
	
@export var PathHitBox: NodePath
	
var currentAbility: Ability3D	
var movingDuration: float
var HitBox3D: Hittbox3D

func _setup() -> void:
	currentAbility = agent;
	HitBox3D = agent.get_node(PathHitBox)
	HitBox3D.StartWatching()
	pass;

func _enter() -> void:
	movingDuration = currentAbility.MovingDuration
	pass;
	
func _exit() -> void:
	pass;
	
func _tick(_delta: float) -> Status:
	#var temp = HitBox3D.get_node("CollisionShape3D_Hitbox") as CollisionShape3D
	#print(temp.scale)
	if (HitBox3D.Hit == true):
		return SUCCESS
	if (self.get_elapsed_time() >= movingDuration):
		HitBox3D.Action()
		return SUCCESS
	else:
		return RUNNING
