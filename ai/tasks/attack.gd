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
	targetCharacter = blackboard.get_var(BBVariable.TargetCharacter)
	pass;
	
func _exit() -> void:
	pass;

func _tick(_delta: float) -> Status:
	currentCharacter.Attack(targetCharacter)
	blackboard.set_var(BBVariable.ReadyToStrike, false)
	return SUCCESS;	
