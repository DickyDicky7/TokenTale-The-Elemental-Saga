@tool
extends BTAction

@export var Type: String
@export var CombatDistance: float
@export var ProbeDistance: float
@export var PathNavigationAgent3D: NodePath

var currentCharacter: Character3D
var targetCharacter: Character3D
var navigationAgent3D: NavigationAgent3D
var finalDestination: Vector3
var priorityAngle: float
var readyToStrike: bool

func _generate_name() -> String:
	return "Chaser move: " + Type;
	
func _setup() -> void:
	match Type:
		"APPROACH":
			priorityAngle = 0
		"RETREAT":
			priorityAngle = PI
		"PROBE":
			priorityAngle = 2 * PI / 5
	currentCharacter = agent
	navigationAgent3D = agent.get_node(PathNavigationAgent3D)
	pass;
	
func _enter() -> void:
	finalDestination = Vector3.ZERO
	if (!is_instance_valid(blackboard.get_var(BBVariable.TargetCharacter))):
		blackboard.set_var(BBVariable.TargetCharacter, null)
	targetCharacter = blackboard.get_var(BBVariable.TargetCharacter)
	if (targetCharacter == null):
		return
	var distanceToTarget: float = Helper.ProjectVector3ToPlane(
		currentCharacter.position, Vector3.UP).distance_to(
			Helper.ProjectVector3ToPlane(
				targetCharacter.position, Vector3.UP))
	readyToStrike = blackboard.get_var(BBVariable.ReadyToStrike)
	match Type:
		"APPROACH":
			if (readyToStrike == true && distanceToTarget > CombatDistance
			|| readyToStrike == false && distanceToTarget > ProbeDistance + 0.25):
				finalDestination = FindMoveDestination(distanceToTarget)
		"RETREAT":
			if (readyToStrike == false && distanceToTarget < ProbeDistance - 0.25):
				finalDestination = FindMoveDestination(distanceToTarget)
		"PROBE":
			if (readyToStrike == false 
			&& distanceToTarget >= ProbeDistance - 0.25 
			&& distanceToTarget <= ProbeDistance + 0.25):
				finalDestination = FindMoveDestination(distanceToTarget)
	pass;
	
func _exit() -> void:
	pass;
	
func _tick(_delta: float) -> Status:
	if (finalDestination != null && finalDestination != Vector3.ZERO):
		blackboard.set_var(BBVariable.Destination, finalDestination)
		return SUCCESS
	else: 
		return FAILURE

func FindMoveDestination(distanceToTarget: float) -> Vector3:
	var destination: Vector3 = Vector3.ZERO
	var mainVector: Vector3 = Helper.ProjectVector3ToPlane(
		currentCharacter.position.direction_to(targetCharacter.position), 
		Vector3.UP)
	var directionList: Array = Helper.CalculateMoveDirectionList(
		mainVector,
		priorityAngle)
	var distance: float = FindMoveDistance(distanceToTarget) + navigationAgent3D.target_desired_distance
	destination = Helper.CalculateMoveDestination(
		currentCharacter.position,
		distance,
		directionList)
	return destination;	

func FindMoveDistance(distanceToTarget: float) -> float:
	var temp: float = 0
	match Type:
		"APPROACH":
			if (readyToStrike == true):
				temp = distanceToTarget - CombatDistance + 0.05
			else:
				temp = distanceToTarget - ProbeDistance
		"RETREAT":
			temp = ProbeDistance - distanceToTarget
		"PROBE":
			temp = distanceToTarget - (ProbeDistance - 0.25)
	return temp
