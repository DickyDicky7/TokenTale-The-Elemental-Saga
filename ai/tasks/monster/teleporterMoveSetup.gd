@tool
extends BTAction;

@export var Type: StringName;
@export var ActionDistance: float;
@export var PathRayCast3DTeleport: NodePath;
@export var PathNavigationAgent3D: NodePath;

var currentCharacter: Character3D;
var _targetCharacter: Character3D;
var navigationAgent3D: NavigationAgent3D;
var rayCast3DTeleport:         RayCast3D;
var finalDestination: Vector3;
var priorityAngle: float;

func _generate_name() -> String:
	return "Teleporter move: " + Type;

func _setup() -> void:
	priorityAngle = 0;
	currentCharacter  = agent;
	rayCast3DTeleport = agent.get_node(PathRayCast3DTeleport);
	navigationAgent3D = agent.get_node(PathNavigationAgent3D);
	pass;
	
func _enter() -> void:
	finalDestination = Vector3.ZERO;
	if (!is_instance_valid(
		blackboard.get_var(BBVariable.TargetCharacter    ))):
		blackboard.set_var(BBVariable.TargetCharacter, null);
	_targetCharacter =  blackboard.get_var(BBVariable.TargetCharacter);
	if (
	_targetCharacter == null):
		return;
	var distanceToTarget: float =    Helper.ProjectVector3ToPlane(
		currentCharacter.global_position, Vector3.UP).distance_to(
									 Helper.ProjectVector3ToPlane(
		_targetCharacter.global_position, Vector3.UP)            );
	match Type:
		"APPROACH" :
			if (distanceToTarget >  ActionDistance):
				finalDestination =  FindMoveDestination(distanceToTarget);
		"TELEPORT" :
			if (distanceToTarget <= ActionDistance):
				finalDestination  = FindTeleportDestination ();
		"TELEPORT2":
			if (distanceToTarget >  ActionDistance):
				finalDestination =  FindTeleportDestination2();
	pass;
	
func _exit () -> void:
	rayCast3DTeleport.target_position = (
	rayCast3DTeleport.target_position   );
	pass;
	
func _tick(_delta: float) -> Status:
	if (finalDestination != null
	&&  finalDestination != Vector3.ZERO):
		blackboard.set_var                      (
		BBVariable.Destination, finalDestination);
		return SUCCESS;
	else:
		return FAILURE;
		
func FindMoveDestination(distanceToTarget) -> Vector3:
	var destination: Vector3 =                Vector3.ZERO;
	var  mainVector: Vector3 =  Helper  .ProjectVector3ToPlane(
		currentCharacter.global_position.direction_to(
		_targetCharacter.global_position             ), 
					 Vector3.UP                               );
	var directionList : Array = Helper  .                       CalculateMoveDirectionList(
		 mainVector   ,
		priorityAngle);
	var distance: float = (
FindMoveDistance        (
		distanceToTarget) + navigationAgent3D.target_desired_distance);
	destination = Helper.                    CalculateMoveDestination(
		currentCharacter.global_position,
		distance      ,
		directionList);
	return destination;

func FindMoveDistance(distanceToTarget: float) -> float:
	return            distanceToTarget - ActionDistance;

func FindTeleportDestination () -> Vector3:
	var destination: Vector3 =     Vector3.ZERO;
	var  mainVector: Vector3 =   Helper .ProjectVector3ToPlane(
		_targetCharacter.global_position.direction_to(
		currentCharacter.global_position             ),
					 Vector3.UP                               ).normalized();
	var scaleXZ    : float = (mainVector.x
							 /mainVector.z);
	var additionalX: float = 0.2;
	var additionalZ: float = additionalX / scaleXZ;
	var destinationList: Array = Helper .                                    CalculateTeleportDestinationList(
					 Vector3(additionalX ,
									   0 ,
							 additionalZ),
		_targetCharacter .       position );
	for i in range (destinationList.size()):
		rayCast3DTeleport.target_position = destinationList[i];
		rayCast3DTeleport.       position = destinationList[i];
		rayCast3DTeleport.force_raycast_update();
		if (
		rayCast3DTeleport.                       is_colliding() == false):
			destination = destinationList[i];
			break;
	return  destination ;

func FindTeleportDestination2() -> Vector3:
	var destination: Vector3 =     Vector3.ZERO;
	rayCast3DTeleport.add_exception_rid(_targetCharacter.get_rid());
	var  mainVector: Vector3 = Helper.ProjectVector3ToPlane(
	 currentCharacter.global_position.direction_to(
	 _targetCharacter.global_position             ),
					 Vector3.UP                            );
	var directionList: Array = Helper.                       CalculateMoveDirectionList(
		mainVector    ,
		priorityAngle);
	for i in range (directionList.size()):
		var destinationTemp: Vector3 = currentCharacter.position + directionList[i] * currentCharacter.CurrentSpeed / 3;
		rayCast3DTeleport.target_position = destinationTemp;
		rayCast3DTeleport.       position = destinationTemp;
		rayCast3DTeleport.force_raycast_update();
		if (
		rayCast3DTeleport.                       is_colliding() == false):
			destination = destinationTemp;
			return        destination    ;
	return  destination ;
