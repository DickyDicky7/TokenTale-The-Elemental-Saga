@tool
extends BTAction

func _generate_name() -> String:
	return "ChangeSeeingDirection";
	
@export var PathAnimatedSprite3D : NodePath
@export var PathEyeSight : NodePath

var animatedSprite3D: AnimatedSprite3D
var eyeSight: Node3D
var SeeingAngle: float

var BBSeeingAngle: StringName = "SeeingAngle"
var helper: Helper = Helper.GetInstance()

func _setup() -> void:
	eyeSight = agent.get_node(PathEyeSight);
	animatedSprite3D = agent.get_node(PathAnimatedSprite3D);
	#blackboard.set_var(BBSeeingAngle, 0)
	pass;
	
func _enter() -> void:
	SeeingAngle = blackboard.get_var(BBSeeingAngle)
	SeeingAngle = helper.StandardizeDegree(SeeingAngle)
	pass;

func _exit() -> void:
	pass;
	
func _tick(_delta:float) -> Status:
	eyeSight.rotation_degrees.y = SeeingAngle + 45
	if (SeeingAngle >= 90 && SeeingAngle < 270):
		animatedSprite3D.scale.x = -1;
	else:
		animatedSprite3D.scale.x = 1;
	return SUCCESS;
