@tool
extends BTAction

func _generate_name()    -> String:
    return "ELEMENTAL MONSTER MOVE"

func _tick(delta: float) -> Status:
    return FAILURE