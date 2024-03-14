@tool
extends BTAction

@export var PathRayCast2D : NodePath
@export var PathTimer_ChangeLocalLookingDirection          : NodePath
@export var PathHFlippable2DLocalLookingDirectionComponent : NodePath

var rayCast2D : RayCast2D
var timer_ChangeLocalLookingDirection          : Timer
var hFlippable2DLocalLookingDirectionComponent : HFlippable2DLocalLookingDirectionComponent

func _generate_name()    -> String:
	return "ELEMENTAL MONSTER IDLE"

func _setup() -> void:
	rayCast2D = agent.get_node(PathRayCast2D);
	timer_ChangeLocalLookingDirection          = agent.get_node(PathTimer_ChangeLocalLookingDirection         )
	hFlippable2DLocalLookingDirectionComponent = agent.get_node(PathHFlippable2DLocalLookingDirectionComponent)
	pass

func _enter() -> void:
	timer_ChangeLocalLookingDirection.timeout.   connect(OnTimer_ChangeLocalLookingDirectionTimeout)
	pass

func _exit () -> void:
	timer_ChangeLocalLookingDirection.timeout.disconnect(OnTimer_ChangeLocalLookingDirectionTimeout)
	pass

func _tick(delta: float) -> Status:
	
	return RUNNING

func OnTimer_ChangeLocalLookingDirectionTimeout() -> void:
	hFlippable2DLocalLookingDirectionComponent.LocalLookingDirection *= -1.0
	pass

