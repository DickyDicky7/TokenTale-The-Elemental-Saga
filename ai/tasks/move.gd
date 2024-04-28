@tool
extends BTAction

func _generate_name() -> String:
	return "Move";

@export var PathFlipSprite3D : NodePath

var currentCharacter: Character3D
var flipSprite3D: Flippable3DSpriteBase3DConsolidation
var moveDirection: Vector3
var lastPosition: Vector3
var moveDistance: float

var BBMoveDirection: StringName = "MoveDirection"
var BBMoveDistance: StringName = "MoveDistance"
var helper: Helper = Helper.GetInstance()

func _setup() -> void:
	currentCharacter = agent
	flipSprite3D = agent.get_node(PathFlipSprite3D)
	pass;

func _enter() -> void:
	lastPosition = currentCharacter.position
	moveDirection = blackboard.get_var(BBMoveDirection)
	moveDistance = blackboard.get_var(BBMoveDistance)
	if (flipSprite3D != null):
		if (moveDirection.x / abs(moveDirection.x) > 0):
			flipSprite3D.FlipH = false
		else:
			flipSprite3D.FlipH = true 
	pass;
	
func _exit() -> void:
	pass;
	
func _tick(_delta: float) -> Status:
	if (currentCharacter.position.distance_to(lastPosition) <= moveDistance):
		currentCharacter.Move(moveDirection, _delta)
		return RUNNING;
	else:
		return SUCCESS;
