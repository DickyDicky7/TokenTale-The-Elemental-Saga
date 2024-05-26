@tool
extends BTAction

var currentCharacter: Monster
var targetCharacter: Character3D

func _generate_name() -> String:
	return "Attack";
	
func _setup() -> void:
	currentCharacter = agent
	blackboard.set_var(BBVariable.ReadyToStrike, true)
	pass;
	
func _enter() -> void:
	if (!is_instance_valid(blackboard.get_var(BBVariable.TargetCharacter))):
		blackboard.set_var(BBVariable.TargetCharacter, null);
	targetCharacter = blackboard.get_var(BBVariable.TargetCharacter)
	pass;
	
func _exit() -> void:
	pass;

func _tick(_delta: float) -> Status:
	if (targetCharacter == null):
		return FAILURE
	targetCharacter = targetCharacter as MainCharacter
	currentCharacter.Attack(targetCharacter)
	blackboard.set_var(BBVariable.ReadyToStrike, false)
	return SUCCESS;	
