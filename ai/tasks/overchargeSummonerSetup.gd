@tool
extends BTAction;

func _generate_name() -> String:
	return "OVERCHARGE SUMMONER SETUP";

@export var PathScanboxx   :    NodePath;
@export var OverchargeScene: PackedScene;

var scanboxx: Area3D; var currentAbility: Ability3D;

func _setup() -> void:
	currentAbility = agent;
	scanboxx       = agent.get_node(PathScanboxx           );
	scanboxx.body_entered . connect(  OnScanboxxBodyEntered);
	pass;

func _enter() -> void:
	pass;

func _exit () -> void:
	pass;

func _tick(_delta : float) -> Status:
	return SUCCESS;

func _get_configuration_warnings() -> PackedStringArray:
	return     PackedStringArray();

func OnScanboxxBodyEntered(
	body : Node3D) -> void:
	if (body is Character3D
	&&  body != currentAbility.Caster):
		var overcharge:Ability3D  =  OverchargeScene  .  instantiate(
		);  overcharge.Attach(
		body ,  currentAbility.Caster ,
		Vector3.ZERO ,
		Vector3.ZERO);
	pass;
