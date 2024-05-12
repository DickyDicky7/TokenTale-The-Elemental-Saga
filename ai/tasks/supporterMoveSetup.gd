@tool
extends BTAction

@export var Type: String
@export var SatelliteDistance: float

var currentCharacter: Monster
var partner: Monster
var finalDestination: Vector3
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
	pass;

func _enter() -> void:
	finalDestination = Vector3.ZERO
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
				finalDestination = FindMoveDirection(distanceToPartner)
		"SATELLITE":
			if (distanceToPartner < SatelliteDistance):
				finalDestination = FindMoveDirection(distanceToPartner)
	pass;

func _exit() -> void:
	pass;

func _tick(_delta: float) -> Status:
	if (finalDestination != null && finalDestination != Vector3.ZERO):
		blackboard.set_var(BBVariable.Destination, finalDestination)
		return SUCCESS
	else: 
		return FAILURE

func FindMoveDirection(distanceToPartner:float) -> Vector3:
	var destination: Vector3 = Vector3.ZERO
	var mainVector: Vector3 = Helper.ProjectVector3ToPlane(
		currentCharacter.position.direction_to(partner.position), 
		Vector3.UP)
	var directionList: Array = Helper.CalculateMoveDirectionList(
		mainVector,
		priorityAngle)
	var distance: float = FindMoveDistance(distanceToPartner)
	destination = Helper.CalculateMoveDestination(
		currentCharacter.position,
		distance,
		directionList)
	return destination;		
	
func FindMoveDistance(distanceToPartner: float) -> float:
	var temp: float = 0
	match Type:
		"FOLLOW":
			temp = distanceToPartner - SatelliteDistance
		"SATELLITE":
			temp = SatelliteDistance - distanceToPartner
	return temp
