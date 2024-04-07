@tool
extends BTAction;

func _generate_name() -> String:
	return "RUNAWAY";

@export var TargetCharacter3DName: StringName;
@export var MinSeeableAngle: float;
@export var MaxSeeableAngle: float;
@export var PathShapeCast3D: NodePath;
@export var PathRay__Cast3D: NodePath;
@export var PathTimerChangeFlipH____________________: NodePath;
@export var PathFlippable3DSpriteBase3DConsolidation: NodePath;

var currentCharacter3D: Character3D;
var shapeCast3D: ShapeCast3D;
var ray__Cast3D:   RayCast3D;
var timerChangeFlipH____________________:                                Timer;
var flippable3DSpriteBase3DConsolidation: Flippable3DSpriteBase3DConsolidation;

func _setup() -> void:
	currentCharacter3D = agent;
	shapeCast3D = agent.get_node(PathShapeCast3D);
	ray__Cast3D = agent.get_node(PathRay__Cast3D);
	timerChangeFlipH____________________ = agent.get_node(PathTimerChangeFlipH____________________);
	flippable3DSpriteBase3DConsolidation = agent.get_node(PathFlippable3DSpriteBase3DConsolidation);
	pass;

var mvDirection: Vector3;
var lstPosition: Vector3;
@export
var maxDistance:   float;

func _enter() -> void:
	flippable3DSpriteBase3DConsolidation.FlipH = not flippable3DSpriteBase3DConsolidation.FlipH;
	var mvDirectionX : float;
	if (
	flippable3DSpriteBase3DConsolidation.FlipH):
		mvDirectionX = -1;
	else:
		mvDirectionX = +1;
	mvDirection = Vector3(mvDirectionX, 0, randf_range(-1, +1)).normalized();
	lstPosition = currentCharacter3D.position;
	pass;

func _exit () -> void:
	blackboard.top( ).set_var("mvDirectionX", mvDirection.x);
	pass;

func _tick(_delta: float) -> Status:

	ray__Cast3D.target_position=ray__Cast3D.target_position;
	ray__Cast3D.                     force_raycast_update();

	if (shapeCast3D.is_colliding()):
		for i in range(shapeCast3D.collision_result.size()):
			var  targetCharacter3D:Object=        shapeCast3D.get_collider(i);
			if  (targetCharacter3D      !=  null
			&&   targetCharacter3D      is        Character3D
			&&   targetCharacter3D.name ==  TargetCharacter3DName):
				currentCharacter3D.Move(
				mvDirection, _delta    );
				lstPosition = currentCharacter3D.position;
				return RUNNING
	
	if (currentCharacter3D.position                 .
			distance_to(lstPosition) <= maxDistance):
				currentCharacter3D.Move(mvDirection ,_delta);
				return RUNNING;

	return SUCCESS;

func _get_configuration_warnings() -> PackedStringArray:
	return     PackedStringArray();


