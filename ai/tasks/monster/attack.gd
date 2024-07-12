@tool
extends BTAction;

var currentCharacter: Monster    ;
var ttargetCharacter: Character3D;

func _generate_name() -> String:
	return "Attack";
	
func _setup() -> void:
	currentCharacter = agent;
	blackboard.set_var(BBVariable.ReadyToStrike, false);
	pass;
	
func _enter() -> void:
	if (!is_instance_valid(
		blackboard.get_var(BBVariable.TargetCharacter    ))):
		blackboard.set_var(BBVariable.TargetCharacter, null);
	ttargetCharacter = blackboard.get_var(BBVariable.TargetCharacter);
	pass;
	
func  _exit() -> void:
	pass;

func _tick(_delta: float) -> Status:
	if (currentCharacter.IsStunning == true):
		return FAILURE;
	if (ttargetCharacter            == null):
		return FAILURE;
	ttargetCharacter  =     ttargetCharacter as MainCharacter;
	currentCharacter.Attack(ttargetCharacter);
	blackboard.set_var(
	BBVariable.ReadyToStrike, false);
	return SUCCESS;
