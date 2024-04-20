@tool
extends BTAction

func _generate_name() -> String:
	return "ChangeClockwisePriority";
	
var BBClockwisePriority: StringName = "ClockwisePriority"

func _setup() -> void:
	pass;

func _enter() -> void:
	pass;
	
func _exit() -> void:
	pass;
	
func _tick(_delta: float) -> Status:
	var temp: bool = blackboard.get_var(BBClockwisePriority)
	temp = !temp
	blackboard.set_var(BBClockwisePriority, temp)
	return SUCCESS
