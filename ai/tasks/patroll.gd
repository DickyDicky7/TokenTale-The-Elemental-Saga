@tool
extends BTAction

func _generate_name() -> String:
	return "PATROLL";

@export var TargetCharacter2DName: StringName
@export var MinSeeableAngle: float
@export var MaxSeeableAngle: float
@export var PathShapeCast2D: NodePath
@export var PathRay__Cast2D: NodePath
@export var PathTimer_ChangeLocalSeeingDirection: NodePath
@export var PathFlippable2DHLocalSeeingDirection: NodePath

var currentCharacter2D: Character2D
var shapeCast2D: ShapeCast2D
var ray__Cast2D:   RayCast2D
var timer_ChangeLocalSeeingDirection: Timer
var flippable2DHLocalSeeingDirection: Flippable2DHLocalSeeingDirection

func _setup() -> void:
	currentCharacter2D = agent;
	shapeCast2D = agent.get_node(PathShapeCast2D);
	ray__Cast2D = agent.get_node(PathRay__Cast2D);
	timer_ChangeLocalSeeingDirection = agent.get_node(PathTimer_ChangeLocalSeeingDirection);
	flippable2DHLocalSeeingDirection = agent.get_node(PathFlippable2DHLocalSeeingDirection);
	pass

func _enter() -> void:
	timer_ChangeLocalSeeingDirection.timeout.   connect(OnTimer_ChangeLocalSeeingDirectionTimeout);
	pass

func _exit () -> void:
	timer_ChangeLocalSeeingDirection.timeout.disconnect(OnTimer_ChangeLocalSeeingDirectionTimeout);
	pass

func _tick(_delta: float) -> Status:
	if (shapeCast2D.is_colliding()):
		for i in range(shapeCast2D.collision_result.size()):
			var  targetCharacter2D:Object=        shapeCast2D.get_collider(i);
			if  (targetCharacter2D      !=  null
			&&   targetCharacter2D      is        Character2D
			&&	 targetCharacter2D.name ==  TargetCharacter2DName):
				var angle:float = clamp(
				currentCharacter2D.to_local
				(targetCharacter2D.global_position).angle()
				, deg_to_rad(MinSeeableAngle)
				, deg_to_rad(MaxSeeableAngle)
				);
				ray__Cast2D.rotation  =  angle;
				if (
				ray__Cast2D.get_collider_rid()
										==  targetCharacter2D
									.get_rid()):
					return SUCCESS;
	return RUNNING;

func OnTimer_ChangeLocalSeeingDirectionTimeout() -> void:
	flippable2DHLocalSeeingDirection.LocalSeeingDirection *= - 1.0;
	pass

func _get_configuration_warnings() -> PackedStringArray:
	return     PackedStringArray();


