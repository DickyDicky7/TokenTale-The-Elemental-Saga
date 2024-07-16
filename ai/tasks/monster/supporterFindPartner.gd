@tool
extends BTAction;

func _generate_name() -> String:
	return   "Find Partner"    ;
	
@export var PathShapeCast3DFindPartner: NodePath;

var      currentCharacter:     Monster;
var shapeCast3DFinPartner: ShapeCast3D;

func _setup() -> void:
	currentCharacter      = agent;
	shapeCast3DFinPartner = agent.get_node(PathShapeCast3DFindPartner);
	blackboard.set_var(BBVariable.CurrentPartner, null);
	pass;
	
func _enter() -> void:
	pass;
	
func _exit () -> void:
	pass;
	
func _tick(_delta: float) -> Status:
	if (shapeCast3DFinPartner.is_colliding()):
		var nearestMonsterIndex: int   = -1  ;
		var    smallestDistance: float = INF ;
		for i in range (shapeCast3DFinPartner.collision_result.size()):
			var targetMonster:  Object = shapeCast3DFinPartner.get_collider(i);
			if (targetMonster != null && targetMonster is Monster):
				targetMonster  =         targetMonster as Monster ;
				# 0 as Distancer
				if (targetMonster.MonsterType  == 0):
					var distancetoTarget :float = currentCharacter.position.distance_to(targetMonster.position);
					if (distancetoTarget
					<   smallestDistance):
						nearestMonsterIndex = i               ;
						smallestDistance    = distancetoTarget;
		if (nearestMonsterIndex != -1):
			blackboard.set_var                    (
			BBVariable.CurrentPartner,
				shapeCast3DFinPartner.get_collider(
			nearestMonsterIndex                   ));
			return SUCCESS;
	return FAILURE;
