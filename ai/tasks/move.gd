@tool
extends BTAction

func _generate_name() -> String:
	return "Move";

@export var PathFlipSprite3D : NodePath
@export var PathNavigationAgent3D: NodePath

var currentCharacter: Character3D
var flipSprite3D: Flippable3DSpriteBase3DConsolidation
var navigationAgent3D: NavigationAgent3D

func _setup() -> void:
	currentCharacter = agent
	flipSprite3D = agent.get_node(PathFlipSprite3D)
	navigationAgent3D = agent.get_node(PathNavigationAgent3D)
	pass;

func _enter() -> void:
	navigationAgent3D.target_position = blackboard.get_var(BBVariable.Destination)
	pass;
	
func _exit() -> void:
	pass;
	
func _tick(_delta: float) -> Status:
	var finalPositionXZ: Vector2 = Vector2(
		navigationAgent3D.get_final_position().x,
		navigationAgent3D.get_final_position().z)
	var targetPostionXZ: Vector2 = Vector2(
		navigationAgent3D.target_position.x,
		navigationAgent3D.target_position.z)
	var targetDesireDistanceXZ = finalPositionXZ.distance_to(targetPostionXZ)
	if (targetDesireDistanceXZ > navigationAgent3D.target_desired_distance):
		return FAILURE
	var currentPositionXZ: Vector2 = Vector2(
		currentCharacter.position.x,
		currentCharacter.position.z)
	var distanceToTargetXZ: float = currentPositionXZ.distance_to(targetPostionXZ)
	if (distanceToTargetXZ <= navigationAgent3D.target_desired_distance):
		return SUCCESS
	else: 
		var nextDestination: Vector3 = navigationAgent3D.get_next_path_position()
		if (flipSprite3D != null):
			if (nextDestination.x <= currentCharacter.position.x):
				flipSprite3D.FlipH = true
			else:
				flipSprite3D.FlipH = false
		var direction: Vector3 = nextDestination - currentCharacter.global_position
		currentCharacter.Move(direction, _delta)
		return RUNNING
