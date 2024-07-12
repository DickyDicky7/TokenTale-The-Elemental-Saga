@tool
extends BTAction;

@export var PathTimer: NodePath;

var timer: Timer;

func _generate_name() -> String:
	return "Reload";
	
func _setup() -> void:
	timer = agent.get_node( PathTimer  );
	timer.timeout.connect (TimerTimeout);
	pass;
	
func _enter() -> void:
	pass;
	
func _exit () -> void:
	pass;

func _tick(_delta: float) -> Status:
	var readyToStrike = blackboard.get_var(BBVariable.ReadyToStrike);
	if (readyToStrike == false):
		timer.paused  =  false ;
	else:
		timer.paused  = !false ;
	return SUCCESS;
	
func TimerTimeout() -> void:
	blackboard.set_var(BBVariable.ReadyToStrike, true);
	pass;
