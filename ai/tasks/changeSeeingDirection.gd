@tool
extends BTAction

func _generate_name() -> String:
	return "ChangeSeeingDirection";
	
@export var PathFlipSprite3D : NodePath
@export var PathEyeSight : NodePath

var flipSprite3D: Flippable3DSpriteBase3DConsolidation
var eyeSight: Node3D
var SeeingAngle: float

var BBSeeingAngle: StringName = "SeeingAngle"
var helper: Helper = Helper.GetInstance()

func _setup() -> void:
	eyeSight = agent.get_node(PathEyeSight);
	flipSprite3D = agent.get_node(PathFlipSprite3D);
	pass;
	
func _enter() -> void:
	SeeingAngle = blackboard.get_var(BBSeeingAngle)
	SeeingAngle = helper.StandardizeDegree(SeeingAngle)
	pass;

func _exit() -> void:
	pass;
	
func _tick(_delta:float) -> Status:
	eyeSight.rotation_degrees.y = SeeingAngle + 45
	if (flipSprite3D != null):
		if (SeeingAngle >= 90 && SeeingAngle < 270):
			flipSprite3D.FlipH = true
		else:
			flipSprite3D.FlipH = false
	return SUCCESS;
