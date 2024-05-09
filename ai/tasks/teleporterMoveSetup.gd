@tool
extends BTAction

@export var Type: StringName
@export var ActionDistance: float
@export var PathRayCast3DMove: NodePath
@export var PathRayCast3DTeleport: NodePath

var currentCharacter: Character3D
var targetCharacter: Character3D
var rayCast3DMove: RayCast3D
var rayCast3DTeleport: RayCast3D
var moveDirection: Vector3
var moveDistance: float
var teleportLocation: Vector3
var priorityAngle: float

func _generate_name() -> String:
	return "Teleporter move: " + Type;

func _setup() -> void:
	priorityAngle = 0
	currentCharacter = agent
	rayCast3DMove = agent.get_node(PathRayCast3DMove)
	rayCast3DTeleport = agent.get_node(PathRayCast3DTeleport)
	pass;
	
func _enter() -> void:
	teleportLocation = Vector3(0, 0, 0)
	moveDirection = Vector3(0, 0, 0)
	moveDistance = 0
	if (!is_instance_valid(blackboard.get_var(BBVariable.TargetCharacter))):
		blackboard.set_var(BBVariable.TargetCharacter, null)
	targetCharacter = blackboard.get_var(BBVariable.TargetCharacter)
	if (targetCharacter == null):
		return
	var distanceToTarget: float = Helper.ProjectVector3ToPlane(
		currentCharacter.position, Vector3.UP).distance_to(
			Helper.ProjectVector3ToPlane(
				targetCharacter.position, Vector3.UP))
	match Type:
		"APPROACH":
			if (distanceToTarget > ActionDistance):
				moveDirection = FindMoveDirection()
				moveDistance = FindMoveDistance(distanceToTarget)
		"TELEPORT":
			if (distanceToTarget <= ActionDistance):
				teleportLocation = FindTeleportLocation()
		"TELEPORT2":
			if (distanceToTarget > ActionDistance):
				teleportLocation = FindTeleportLocation2(distanceToTarget - ActionDistance)
	pass;
	
func _exit() -> void:
	rayCast3DMove.target_position = rayCast3DMove.target_position
	rayCast3DTeleport.target_position = rayCast3DTeleport.target_position
	pass;
	
func _tick(_delta: float) -> Status:
	match Type:
		"APPROACH":
			if (moveDirection != null && moveDistance != null &&
				moveDirection != Vector3(0, 0, 0) && moveDistance != 0):
				blackboard.set_var(BBVariable.MoveDirection, moveDirection)
				blackboard.set_var(BBVariable.MoveDistance, moveDistance)
				return SUCCESS
		"TELEPORT":
			if (teleportLocation != null && teleportLocation != Vector3(0, 0, 0)):
				blackboard.set_var(BBVariable.TeleportLocation, teleportLocation)
				return SUCCESS
		"TELEPORT2":
			if (teleportLocation != null && teleportLocation != Vector3(0, 0, 0)):
				blackboard.set_var(BBVariable.TeleportLocation, teleportLocation)
				return SUCCESS
	return FAILURE;
func FindMoveDirection() -> Vector3:
	rayCast3DMove.add_exception_rid(targetCharacter.get_rid())
	var clockwisePriority: bool = blackboard.get_var(BBVariable.ClockwisePriority)
	var mainVector: Vector3 = Helper.ProjectVector3ToPlane(
		currentCharacter.position.direction_to(targetCharacter.position)
		, Vector3.UP
	).normalized()
	var potentialDirections: Array = Helper.PossibleAngleToMoveWithPriority(
		mainVector
		, priorityAngle
		, clockwisePriority)
	var direction: Vector3
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

func FindMoveDistance(distanceToTarget: float) -> float:
	return distanceToTarget - ActionDistance;

func FindTeleportLocation() -> Vector3:
	var mainVector: Vector3 = Helper.ProjectVector3ToPlane(
		targetCharacter.position.direction_to(currentCharacter.position)
		, Vector3.UP
	).normalized()
	var scaleXZ: float = mainVector.x / mainVector.z
	var additionalX: float = 0.2
	var additionalZ: float = additionalX / scaleXZ
	var potentialLocation: Array = Helper.PossibleTeleportLocation(
		Vector3(additionalX, 0, additionalZ)
		, targetCharacter.position)
	var location: Vector3 = Vector3(0, 0, 0)
	for i in range (potentialLocation.size()):
		rayCast3DTeleport.target_position = potentialLocation[i]
		rayCast3DTeleport.position = potentialLocation[i]
		rayCast3DTeleport.force_raycast_update()
		if (rayCast3DTeleport.is_colliding() == false):
			location = potentialLocation[i]
			break;
	return location;

func FindTeleportLocation2(distanceToAction: float) -> Vector3:
	rayCast3DTeleport.add_exception_rid(targetCharacter.get_rid())
	var clockwisePriority: bool = blackboard.get_var(BBVariable.ClockwisePriority)
	var mainVector: Vector3 = Helper.ProjectVector3ToPlane(
		currentCharacter.position.direction_to(targetCharacter.position)
		, Vector3.UP
	).normalized()
	var potentialDirections: Array = Helper.PossibleAngleToMoveWithPriority(
		mainVector
		, priorityAngle
		, clockwisePriority)
	var teleportDistance: float = 0
	var rayCastLength: float = Helper.ProjectVector3ToPlane(
			rayCast3DMove.position, Vector3.UP).distance_to(
			Helper.ProjectVector3ToPlane(
			rayCast3DMove.target_position, Vector3.UP))
	if (rayCastLength <= distanceToAction):
		teleportDistance = rayCastLength
	else:
		teleportDistance = distanceToAction
	var location: Vector3 = Vector3(0, 0 ,0)
	for i in range (potentialDirections.size()):
		rayCast3DMove.rotation_degrees.y = Helper.StandardizeDegree(
			rad_to_deg(mainVector.signed_angle_to(potentialDirections[i], Vector3.DOWN)) +
			rad_to_deg(atan2(mainVector.z, mainVector.x))
		)
		var locationTemp: Vector3 = Vector3(0, 0, 0)
		locationTemp.x = currentCharacter.position.x + cos(deg_to_rad(rayCast3DMove.rotation_degrees.y)) * teleportDistance
		locationTemp.z = currentCharacter.position.z + sin(deg_to_rad(rayCast3DMove.rotation_degrees.y)) * teleportDistance
		locationTemp.y = currentCharacter.position.y
		rayCast3DTeleport.target_position = locationTemp
		rayCast3DTeleport.position = locationTemp
		rayCast3DTeleport.force_raycast_update()
		if (rayCast3DTeleport.is_colliding() == false):
			location = locationTemp
			break;
		if (sin(mainVector.angle_to(potentialDirections[i])) >= 0):
			clockwisePriority = false;
		else:
			clockwisePriority = true;
	blackboard.set_var(BBVariable.ClockwisePriority, clockwisePriority)
	return location
