@tool
extends BTAction

func _generate_name() -> String:
	return "Throw";
	
func _setup() -> void:
	pass;
	
func _enter() -> void:
	pass;
	
func _exit() -> void:
	pass;

func _tick(_delta: float) -> Status:
	
	return SUCCESS;	
