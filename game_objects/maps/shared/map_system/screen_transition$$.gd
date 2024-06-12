extends Node;

func _ready():	
	$PostProcess.configuration = PostProcessingConfiguration.new();
	pass;

func switch_map_area() -> void:
	var twn : Tween = get_tree().create_tween();
	twn.tween_callback(func(): $PostProcess.configuration.ChromaticAberration =     true);
	twn.tween_property($PostProcess.configuration, "StrenghtCA", 10, 1.0);
	twn.tween_property($PostProcess.configuration, "StrenghtCA", 00, 1.0);
	twn.tween_callback(func(): $PostProcess.configuration.ChromaticAberration = not true);
	pass;
