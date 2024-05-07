@tool
extends BTAction

func _generate_name() -> String:
	return "PATROLL";

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
	defaultTargetPosition = ray__Cast3D .target_position ;
	pass

var defaultTargetPosition : Vector3                      ;
func _enter() -> void:
	var mvDirectionX :float = blackboard.top(   ).  get_var("mvDirectionX", 0, false);
	if((mvDirectionX < 0 && defaultTargetPosition.x > 0)
	|| (mvDirectionX > 0 && defaultTargetPosition.x < 0)):
		defaultTargetPosition.x *= -1;
	timerChangeFlipH____________________.timeout.   connect(OnTimerChangeFlipH____________________Timeout);
	pass

func _exit () -> void:
	timerChangeFlipH____________________.timeout.disconnect(OnTimerChangeFlipH____________________Timeout);
	pass

func _tick(_delta: float) -> Status:
	ray__Cast3D.target_position = defaultTargetPosition;
	ray__Cast3D. force_raycast_update                   () ;
	if (shapeCast3D.is_colliding()):
		for i in range(shapeCast3D.collision_result.size()):
			var  targetCharacter3D:Object=        shapeCast3D.get_collider(i);
			if  (targetCharacter3D      !=  null
			&&   targetCharacter3D      is        Character3D
			&&	 targetCharacter3D.name ==  TargetCharacter3DName):
				var angle:float = clamp(
				currentCharacter3D.to_local
				(targetCharacter3D.global_position).signed_angle_to
				(                             defaultTargetPosition , Vector3.DOWN)
				, deg_to_rad(MinSeeableAngle)
				, deg_to_rad(MaxSeeableAngle)
				);
				# print(rad_to_deg(angle))
				ray__Cast3D.target_position = defaultTargetPosition . rotated(
					Vector3.UP,        angle);
				ray__Cast3D.       force_raycast_update ()  ;
				if (
				ray__Cast3D.get_collider_rid()
										==  targetCharacter3D
									.get_rid()):
					return SUCCESS;
	return RUNNING;

func OnTimerChangeFlipH____________________Timeout() -> void:
	flippable3DSpriteBase3DConsolidation.FlipH = not flippable3DSpriteBase3DConsolidation.FlipH;
	defaultTargetPosition.x *= -1 ;
	pass

func _get_configuration_warnings() -> PackedStringArray:
	return     PackedStringArray();



