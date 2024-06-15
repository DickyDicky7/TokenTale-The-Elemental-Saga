extends Node;

@export var bleed_amplitude = 3.0;

func _ready():	
	$PostProcess.configuration = PostProcessingConfiguration.new();
	$PostProcess.configuration.Vignette          = true;
	$PostProcess.configuration.VignetteIntensity = 0.00;
	$PostProcess.configuration.VignetteR_G_B     = Color.CRIMSON  ;
	pass;

func switch_map_area() -> void:
	var twn : Tween = get_tree().create_tween();
	twn.tween_callback(func(): $PostProcess.configuration.ChromaticAberration =     true);
	twn.tween_property($PostProcess.configuration, "StrenghtCA", 10, 1.0);
	twn.tween_property($PostProcess.configuration, "StrenghtCA", 00, 1.0);
	twn.tween_callback(func(): $PostProcess.configuration.ChromaticAberration = not true);
	pass;

func bleed(bleed_ratio:float) -> void:
	var twn : Tween = get_tree().create_tween();
	twn.tween_property($PostProcess.configuration, "VignetteIntensity", bleed_ratio * bleed_amplitude, 0.5);
	pass;
	
