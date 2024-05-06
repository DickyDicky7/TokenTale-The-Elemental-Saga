@tool
extends BTAction

func _generate_name() -> String:
	return "ChangeClockwisePriority";

func _setup() -> void:
	blackboard.set_var(BBVariable.ClockwisePriority, true)
	pass;

func _enter() -> void:
	pass;
	
func _exit() -> void:
	pass;
	
func _tick(_delta: float) -> Status:
	var temp: bool = blackboard.get_var(BBVariable.ClockwisePriority)
	temp = !temp
	blackboard.set_var(BBVariable.ClockwisePriority, temp)
	return SUCCESS
