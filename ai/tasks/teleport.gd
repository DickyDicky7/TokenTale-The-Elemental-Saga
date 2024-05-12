@tool
extends BTAction

func _generate_name() -> String:
	return "Teleport";

@export var PathFlipSprite3D : NodePath

var flipSprite3D: Flippable3DSpriteBase3DConsolidation
var destination: Vector3
var targetCharacter: Character3D
var currentCharacter: Character3D

func _setup() -> void:
	currentCharacter = agent
	flipSprite3D = agent.get_node(PathFlipSprite3D)
	pass;

func _enter() -> void:
	targetCharacter = blackboard.get_var(BBVariable.TargetCharacter)
	destination = blackboard.get_var(BBVariable.Destination)
	if (flipSprite3D != null):
		if (destination.x <= targetCharacter.position.x):
			flipSprite3D.FlipH = false
		else:
			flipSprite3D.FlipH = true
	pass;
	
func _exit() -> void:
	pass;
	
func _tick(_delta: float) -> Status:
	currentCharacter.position = destination
	return SUCCESS;
