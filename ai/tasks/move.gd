@tool
extends BTAction

func _generate_name() -> String:
	return "Move";

@export var PathAnimatedSprite3D : NodePath

var currentCharacter: Character3D
var animatedSprite3D: AnimatedSprite3D
var moveDirection: Vector3
var lastPosition: Vector3
var moveDistance: float

var BBMoveDirection: StringName = "MoveDirection"
var BBMoveDistance: StringName = "MoveDistance"
var helper: Helper = Helper.GetInstance()

func _setup() -> void:
	currentCharacter = agent
	animatedSprite3D = agent.get_node(PathAnimatedSprite3D)
	pass;

func _enter() -> void:
	lastPosition = currentCharacter.position
	moveDirection = blackboard.get_var(BBMoveDirection)
	moveDistance = blackboard.get_var(BBMoveDistance)
	animatedSprite3D.scale.x = moveDirection.x / abs(moveDirection.x)
	pass;
	
func _exit() -> void:
	pass;
	
func _tick(_delta: float) -> Status:
	if (currentCharacter.position.distance_to(lastPosition) <= moveDistance):
		currentCharacter.Move(moveDirection, _delta)
		return RUNNING;
	else:
		return SUCCESS;
