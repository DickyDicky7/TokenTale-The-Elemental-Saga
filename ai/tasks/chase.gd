@tool
extends BTAction

func _generate_name() -> String:
	return "Chase";
	
@export var ChaseDistance: float
@export var PathRayCast3DCheck: NodePath

var currentCharacter: Character3D
var targetCharacter: Character3D
var rayCast3DCheck: RayCast3D
var moveDirection: Vector3

var BBTargetCharacter: StringName = "TargetCharacter"
var BBClockwisePriority: StringName = "ClockwisePriority"
var helper: Helper = Helper.GetInstance()

func _setup() -> void:
	currentCharacter = agent
	rayCast3DCheck = agent.get_node(PathRayCast3DCheck)
	blackboard.set_var(BBClockwisePriority, true)
	pass;
	
func _enter() -> void:
	targetCharacter = blackboard.get_var(BBTargetCharacter)
	var distanceToTarget: float = helper.ProjectVector3ToPlane(
		currentCharacter.position, Vector3.UP).distance_to(
			helper.ProjectVector3ToPlane(
				targetCharacter.position, Vector3.UP))
	moveDirection = Vector3(0, 0, 0)
	if (distanceToTarget > ChaseDistance):
		moveDirection = FindMoveDirection()
	pass;
	
func _exit() -> void:
	pass;

func _tick(_delta: float) -> Status:
	if (moveDirection != Vector3(0, 0, 0)):
		currentCharacter.Move(moveDirection, _delta)
		return SUCCESS
	else: 
		return FAILURE

func FindMoveDirection() -> Vector3:
	rayCast3DCheck.add_exception_rid(targetCharacter.get_rid())
	var clockwisePriority: bool = blackboard.get_var(BBClockwisePriority)
	var mainVector: Vector3 = helper.ProjectVector3ToPlane(
		currentCharacter.position.direction_to(targetCharacter.position)
		, Vector3.UP
	).normalized()
	var potentialDirections: Array = helper.PossibleAngleToMoveWithPriority(
		mainVector
		, 0
		, clockwisePriority)
	var direction: Vector3
	for i in range (potentialDirections.size()):
		rayCast3DCheck.rotation_degrees.y = helper.StandardizeDegree(
			rad_to_deg(mainVector.signed_angle_to(potentialDirections[i], Vector3.DOWN)) + 
			rad_to_deg(atan2(mainVector.z, mainVector.x))
		)
		rayCast3DCheck.force_raycast_update()
		if (rayCast3DCheck.is_colliding() == false):
			direction = potentialDirections[i]
			break;
		if (sin(mainVector.angle_to(potentialDirections[i])) >= 0):
			clockwisePriority = false;
		else:
			clockwisePriority = true;
	blackboard.set_var(BBClockwisePriority, clockwisePriority)
	return direction;
