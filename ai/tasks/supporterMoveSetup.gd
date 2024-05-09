@tool
extends BTAction

@export var Type: String
@export var SatelliteDistance: float
@export var PathRayCast3DMove: NodePath

var currentCharacter: Monster
var partner: Monster
var rayCast3DMove: RayCast3D
var moveDirection: Vector3
var moveDistance: float
var priorityAngle: float

func _generate_name() -> String:
	return "Supporter move: " + Type;

func _setup() -> void:
	match Type:
		"FOLLOW":
			priorityAngle = 0
		"SATELLITE":
			priorityAngle = 2 * PI / 5
	currentCharacter = agent
	rayCast3DMove = agent.get_node(PathRayCast3DMove)
	pass;

func _enter() -> void:
	moveDirection = Vector3(0, 0, 0)
	moveDistance = 0
	if (!is_instance_valid(blackboard.get_var(BBVariable.CurrentPartner))):
		blackboard.set_var(BBVariable.CurrentPartner, null)
	partner = blackboard.get_var(BBVariable.CurrentPartner)
	if (partner == null):
		return
	var distanceToPartner: float = Helper.ProjectVector3ToPlane(
		currentCharacter.position, Vector3.UP).distance_to(
			Helper.ProjectVector3ToPlane(
				partner.position, Vector3.UP))
	match Type:
		"FOLLOW":
			if (distanceToPartner >= SatelliteDistance):
				moveDirection = FindMoveDirection()
				moveDistance = FindMoveDistance(distanceToPartner)
		"SATELLITE":
			if (distanceToPartner < SatelliteDistance):
				moveDirection = FindMoveDirection()
				moveDistance = FindMoveDistance(distanceToPartner)
	pass;

func _exit() -> void:
	rayCast3DMove.target_position = rayCast3DMove.target_position
	pass;

func _tick(_delta: float) -> Status:
	if (moveDirection != null && moveDistance != null && 
		moveDirection != Vector3(0, 0, 0) && moveDistance != 0):
		blackboard.set_var(BBVariable.MoveDirection, moveDirection)
		blackboard.set_var(BBVariable.MoveDistance, moveDistance)
		return SUCCESS
	else: 
		return FAILURE

func FindMoveDirection() -> Vector3:
	rayCast3DMove.add_exception_rid(partner.get_rid())
	var clockwisePriority: bool = blackboard.get_var(BBVariable.ClockwisePriority)
	var mainVector: Vector3 = Helper.ProjectVector3ToPlane(
		currentCharacter.position.direction_to(partner.position)
		, Vector3.UP
	).normalized()
	var potentialDirections: Array = Helper.PossibleAngleToMoveWithPriority(
		mainVector
		, priorityAngle
		, clockwisePriority)
	var direction: Vector3 = Vector3(0, 0, 0)
	for i in range (potentialDirections.size()):
		rayCast3DMove.rotation_degrees.y = Helper.StandardizeDegree(
			rad_to_deg(mainVector.signed_angle_to(potentialDirections[i], Vector3.DOWN)) + 
			rad_to_deg(atan2(mainVector.z, mainVector.x))
		)
		rayCast3DMove.force_raycast_update()
		if (rayCast3DMove.is_colliding() == false):
			direction = potentialDirections[i]
			break;
		if (sin(mainVector.angle_to(potentialDirections[i])) >= 0):
			clockwisePriority = false;
		else:
			clockwisePriority = true;
	blackboard.set_var(BBVariable.ClockwisePriority, clockwisePriority)
	return direction;		
	
func FindMoveDistance(distanceToPartner: float) -> float:
	var temp: float = 0
	match Type:
		"FOLLOW":
			temp = distanceToPartner - SatelliteDistance
		"SATELLITE":
			temp = Helper.ProjectVector3ToPlane(
					rayCast3DMove.position, Vector3.UP).distance_to(
					Helper.ProjectVector3ToPlane(
					rayCast3DMove.target_position, Vector3.UP))
	return temp
