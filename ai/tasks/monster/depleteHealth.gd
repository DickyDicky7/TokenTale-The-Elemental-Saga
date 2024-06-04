@tool
extends BTAction

func _generate_name() -> String:
	return "DepleteHealth";
	
var currentCharacter: Character3D

func _setup() -> void:
	currentCharacter = agent
	pass;
	
func _enter() -> void:
	pass;
	
func _exit() -> void:
	pass;
	
func _tick(_delta: float) -> Status:
	if (currentCharacter.CurrentHealth <= 0):
		currentCharacter = currentCharacter as Monster
		currentCharacter.Drop()
		return SUCCESS
	else:
		return FAILURE
