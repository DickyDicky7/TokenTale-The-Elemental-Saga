@tool
extends BTAction;

func _generate_name()  ->  String :
	return "ChangeSeeingDirection";

@export var PathFlipSprite3D: NodePath;
@export var PathEyeSight    : NodePath;

var flipSprite3D: Flippable3DSpriteBase3DConsolidation;
var    eyeSight : EyeSight3D;
var seeingAngle :      float;

func _setup() -> void:
	eyeSight     = agent.get_node(PathEyeSight    );
	flipSprite3D = agent.get_node(PathFlipSprite3D);
	pass;
	
func _enter() -> void:
	seeingAngle = blackboard.get_var(BBVariable.SeeingAngle);
	seeingAngle =     Helper.StandardizeDegree (seeingAngle);
	pass;

func _exit () -> void:
	pass;
	
func _tick (  _delta  :  float   ) -> Status:
	eyeSight.FollowRotationDegreesY(seeingAngle + 45);
	if (    flipSprite3D != null )          :
		if (seeingAngle >= 090
		&&  seeingAngle <  270):
			flipSprite3D.FlipH =  true;
		else:
			flipSprite3D.FlipH = false;
	return SUCCESS;














