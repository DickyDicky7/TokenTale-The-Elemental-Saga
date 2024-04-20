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
	if (currentCharacter.Health <= 0):
		return SUCCESS
	else:
		return FAILURE
