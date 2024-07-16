@tool
extends BTAction;

func _generate_name(
	)   -> String:
	return "Stop";

var currentCharacter: Character3D;

func _setup() -> void:
	currentCharacter = agent     ;
	pass ;

func _enter() -> void:
	pass ;

func _exit () -> void:
	pass ;

func _tick(_delta : float) -> Status:
	currentCharacter.Stop(Vector3() , _delta);
	return SUCCESS;

func _get_configuration_warnings(
	)   -> PackedStringArray  :
	return PackedStringArray();
