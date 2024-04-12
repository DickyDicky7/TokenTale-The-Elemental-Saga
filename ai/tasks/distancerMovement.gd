@tool
extends BTAction

func _generate_name() -> String:
	return "DistancerMovement";
	
@export var MinSafeDistance: float
@export var MaxSafeDistance: float
@export var PathRayCast3DCheck: NodePath

var currentCharacter: Character3D
var targetCharacter: Character3D
var rayCast3DCheck: RayCast3D
var mainVector: Vector3
var distanceToTarget: float
var potentialDirections: Array
var clockwisePriority: bool

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
	clockwisePriority = blackboard.get_var(BBClockwisePriority)
	rayCast3DCheck.add_exception_rid(targetCharacter.get_rid())
	distanceToTarget = helper.ProjectVector3ToPlane(
		currentCharacter.position, Vector3.UP).distance_to(
			helper.ProjectVector3ToPlane(
				targetCharacter.position, Vector3.UP))
	mainVector = helper.ProjectVector3ToPlane(
		currentCharacter.position.direction_to(targetCharacter.position)
		, Vector3.UP
	).normalized()
	#determine what to do
	if (distanceToTarget > MaxSafeDistance):
		potentialDirections = helper.PossibleAngleToMoveWithPriority(mainVector, 0, clockwisePriority)
	else: if (distanceToTarget < MinSafeDistance):
		potentialDirections = helper.PossibleAngleToMoveWithPriority(mainVector, PI, clockwisePriority)
	else:
		potentialDirections = helper.PossibleAngleToMoveWithPriority(mainVector, 2*PI/5, clockwisePriority)
		#potentialDirections = []
	pass;
	
func _exit() -> void:
	
	pass;
	
func _tick(_delta: float) -> Status:
	for i in range (potentialDirections.size()):
		rayCast3DCheck.rotation_degrees.y = helper.StandardizeDegree(
			rad_to_deg(mainVector.signed_angle_to(potentialDirections[i], Vector3.DOWN)) + 
			rad_to_deg(atan2(mainVector.z, mainVector.x))
		)
		rayCast3DCheck.force_raycast_update()
		
		if (rayCast3DCheck.is_colliding() == false):
			currentCharacter.Move(potentialDirections[i], _delta)
			break;
		if (sin(mainVector.angle_to(potentialDirections[i])) >= 0):
			clockwisePriority = false;
		else:
			clockwisePriority = true;
	blackboard.set_var(BBClockwisePriority, clockwisePriority)		
	return SUCCESS;
