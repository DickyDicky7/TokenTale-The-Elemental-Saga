@tool
extends BTAction

@export var PathRayCast2D : NodePath
@export var PathTimer_ChangeLocalSeeingDirection : NodePath
@export var PathFlippable2DHLocalSeeingDirection : NodePath

var rayCast2D : RayCast2D
var timer_ChangeLocalSeeingDirection : Timer
var flippable2DHLocalSeeingDirection : Flippable2DHLocalSeeingDirection

func _generate_name()    -> String:
	return "ELEMENTAL MONSTER IDLE"

func _setup() -> void:
	rayCast2D = agent.get_node(PathRayCast2D);
	timer_ChangeLocalSeeingDirection = agent.get_node(PathTimer_ChangeLocalSeeingDirection)
	flippable2DHLocalSeeingDirection = agent.get_node(PathFlippable2DHLocalSeeingDirection)
	pass

func _enter() -> void:
	timer_ChangeLocalSeeingDirection.timeout.   connect(OnTimer_ChangeLocalSeeingDirectionTimeout)
	pass

func _exit () -> void:
	timer_ChangeLocalSeeingDirection.timeout.disconnect(OnTimer_ChangeLocalSeeingDirectionTimeout)
	pass

func _tick(delta: float) -> Status:
	
	return RUNNING

func OnTimer_ChangeLocalSeeingDirectionTimeout() -> void:
	flippable2DHLocalSeeingDirection.LocalSeeingDirection *= -1.0
	pass

