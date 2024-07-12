@tool
extends BTAction;

func _generate_name() -> String:
	return "Teleport"          ;

@export var PathFlipSprite3D : NodePath;

var flipSprite3D: Flippable3DSpriteBase3DConsolidation;
var  destination: Vector3;
var  targetCharacter: Character3D;
var currentCharacter: Character3D;

func _setup() -> void:
	currentCharacter = agent                           ;
	flipSprite3D     = agent.get_node(PathFlipSprite3D);
	pass;

func _enter() -> void:
	if (!is_instance_valid(
		blackboard.get_var(BBVariable.TargetCharacter    ))):
		blackboard.set_var(BBVariable.TargetCharacter, null);
	targetCharacter = blackboard.get_var(BBVariable.TargetCharacter);
	destination     = blackboard.get_var(BBVariable.Destination    );
	if (flipSprite3D != null):
		if (destination.x  <= targetCharacter.global_position.x):
			flipSprite3D.FlipH =  false;
		else:
			flipSprite3D.FlipH = !false;
	pass;
	
func _exit () -> void:
	pass;
	
func _tick(_delta: float) -> Status:
	if    (
	currentCharacter.IsStunning      == true       ):
		return FAILURE;
	currentCharacter.global_position =  destination ;
	return     SUCCESS;
