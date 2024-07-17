@tool
extends BTAction;

@export var Type: String;
@export var FallBackDistance: float;
@export var    ChaseDistance: float;
@export var PathNavigationAgent3D: NodePath;

var currentCharacter: Character3D;
var  targetCharacter: Character3D;
var navigationAgent3D: NavigationAgent3D;
var finalDestination: Vector3;
var   priorityAngle  : float ;

func _generate_name() -> String:
	return "Distancer move: " + Type;
	
func _setup() -> void:
	match Type:
		"CHASE"   :
			priorityAngle = 0         ;
		"FALLBACK":
			priorityAngle =     PI    ;
		"PROBE"   :
			priorityAngle = 2 * PI / 5;
	currentCharacter  = agent;
	navigationAgent3D = agent.get_node(PathNavigationAgent3D);
	pass;

func _enter() -> void:
	finalDestination = Vector3.ZERO;
	if (!is_instance_valid(
		blackboard.get_var(BBVariable.TargetCharacter))):
		blackboard.set_var(BBVariable.TargetCharacter, null);
	targetCharacter = blackboard.get_var(BBVariable.TargetCharacter);
	if (targetCharacter == null):
		return;
	var distanceToTarget: float = Helper.ProjectVector3ToPlane(
		currentCharacter.global_position, Vector3.UP).distance_to(
								  Helper.ProjectVector3ToPlane(
		 targetCharacter.global_position, Vector3.UP));
	match Type:
		"CHASE"   :
			if (distanceToTarget >     ChaseDistance):
				finalDestination = FindDestination(distanceToTarget);
		"FALLBACK":
			if (distanceToTarget <  FallBackDistance):
				finalDestination = FindDestination(distanceToTarget);
		"PROBE"   :
			if (distanceToTarget <=    ChaseDistance
			&&  distanceToTarget >= FallBackDistance):
				finalDestination = FindDestination(distanceToTarget);
	pass;

func _exit () -> void:
	pass;
	
func _tick(_delta: float) -> Status:
	if (finalDestination != null
	&&  finalDestination != Vector3.ZERO):
		blackboard.set_var(
		BBVariable.Destination,
		finalDestination  );
		return SUCCESS;
	else: 
		return FAILURE;
	
func FindDestination(distanceToTarget: float) -> Vector3:
	var destination: Vector3 =                   Vector3.ZERO;
	var  mainVector: Vector3 = Helper   .ProjectVector3ToPlane(
		currentCharacter.global_position.direction_to(
		 targetCharacter.global_position             ), 
					 Vector3.UP                               );
	var directionList: Array = Helper   .                       CalculateMoveDirectionList(
		mainVector    ,
		priorityAngle);
	var distance: float =                                            (
FindMoveDistance        (
		distanceToTarget) + navigationAgent3D.target_desired_distance);
	destination = Helper.                    CalculateMoveDestination(
		currentCharacter.global_position,
		distance      ,
		directionList);
	return destination;

func FindMoveDistance(distanceToTarget: float) -> float:
	var   temp: float = 0;
	match Type:
		"CHASE"   :
			temp = distanceToTarget -    ChaseDistance;
		"FALLBACK":
			temp = FallBackDistance - distanceToTarget;
		"PROBE"   :
			temp = distanceToTarget - FallBackDistance + 0.15;
	return  temp  ;
