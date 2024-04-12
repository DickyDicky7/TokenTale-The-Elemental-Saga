@tool
extends BTAction

func _generate_name() -> String:
	return "WatchingAround";
	
var angle: float = 0

var BBSeeingAngle: StringName = "SeeingAngle"
var helper: Helper = Helper.GetInstance()

func _setup() -> void:
	#blackboard.set_var(BBSeeingAngle, 0)
	pass;

func _enter() -> void:
	pass;
	
func _exit() -> void:
	pass;
	
func _tick(_delta:float) -> Status:
	angle = blackboard.get_var(BBSeeingAngle)
	if (int(angle) % 90 == 0):
		angle += 90
	else:
		angle = ClosestDefaultSeeingAngle(angle)
	angle = helper.StandardizeDegree(angle)
	blackboard.set_var(BBSeeingAngle, angle)
	return SUCCESS;
	
func ClosestDefaultSeeingAngle(currentAngle: float) -> float:
	var array = [0, 90, 180, 270]
	var closestAngle: int
	var closestDelta: float = 0
	var tempDelta: float = 0	
	for i in range (array.size()):
		if (array[i] == currentAngle):
			return array[i];
		tempDelta = abs(array[i] - currentAngle)
		if (closestDelta == 0 || tempDelta < closestDelta):
			closestAngle = array[i]
			closestDelta = tempDelta
	return closestAngle;
