@tool
extends BTAction;

func _generate_name() -> String:
    return "MOVE BY TWEEN";

@export var  StartPosition: Vector3;
@export var  CeasePosition: Vector3; 
@export var MovingDuration: float;
@export var EaseeeeeeeType: Tween.      EaseType;
@export var TransitionType: Tween.TransitionType;

var currentNode3D: Node3D;

func _setup() -> void:
    currentNode3D = agent;
    pass;

func _enter() -> void:
    currentNode3D.position = StartPosition;
    var   tween:Tween      = currentNode3D.create_tween();
    tween.tween_property(    currentNode3D,
                 "position", CeasePosition,
                    MovingDuration);
    tween.set_ease (EaseeeeeeeType);
    tween.set_trans(TransitionType);
    pass;

func _exit () -> void:
    pass;

func _tick(_delta : float) -> Status:
    return SUCCESS;

func _get_configuration_warnings(
    )   -> PackedStringArray  :
    return PackedStringArray();












