@tool
extends BTAction;

func _generate_name() -> String:
	return  "WatchingAround"   ;
	
var angle: float = 0;
var currentCharacter: Character3D;

func _setup() -> void:
	currentCharacter = agent;
	#blackboard.set_var(BBSeeingAngle, 0)
	pass;

func _enter() -> void:
	pass;
	
func _exit () -> void:
	pass;
	
func _tick(_delta:float) -> Status:
	if (currentCharacter.IsStunning  ==  true)      :
		return FAILURE;
	angle =(
	blackboard.get_var(BBVariable.SeeingAngle)     );
	if (int(angle) % 90 == 0):
			angle += 90      ;
	else:
			angle = ClosestDefaultSeeingAngle(angle);
	angle = Helper. StandardizeDegree        (angle);
	blackboard.set_var(BBVariable.SeeingAngle,angle);
	return SUCCESS;
	
func ClosestDefaultSeeingAngle(currentAngle: float) -> float:
	var array = [
		000,
		090,
		180,
		270,    ]        ;
	var closestAngle: int;
	var closestDelta: float = 0;
	var    tempDelta: float = 0;
	for i in range (array.size()):
		if (        array[i]  ==      currentAngle):
			return  array[i]                       ;
		tempDelta = abs(   array[i] - currentAngle);
		if (closestDelta == 0
		||  closestDelta > tempDelta):
			closestAngle = array[i]  ;
			closestDelta = tempDelta ;
	return  closestAngle ;
