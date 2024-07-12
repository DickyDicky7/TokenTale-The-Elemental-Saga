@tool
extends BTAction;

func _generate_name() -> String:
	return "FireBall Activity" ;
	
@export var PathHitBox: NodePath;
	
var currentAbility:      Ability3D;
var movingDuration: float;
var FireBallHitBox: FireBallHitbox;

func _setup() -> void:
	currentAbility = agent                     ;
	FireBallHitBox = agent.get_node(PathHitBox);
	pass;

func _enter() -> void:
	movingDuration = currentAbility.MovingDuration;
	pass;
	
func _exit () -> void:
	pass;
	
func _tick(_delta: float) -> Status:
	if (FireBallHitBox.Hit == true):
		return SUCCESS;
	if (self .get_elapsed_time() >= movingDuration):
		FireBallHitBox.Explode();
		return SUCCESS;
	else:
		return RUNNING;
