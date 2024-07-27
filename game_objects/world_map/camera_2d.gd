extends Camera2D;

func _process(_delta: float) -> void:
	if (Input.is_action_pressed("ui_up")):
		position.y -= 1;
	if (Input.is_action_pressed("ui_down")):
		position.y += 1;
	if (Input.is_action_pressed("ui_left")):
		position.x -= 1;
	if (Input.is_action_pressed("ui_right")):
		position.x += 1;
	if (Input.is_action_pressed("ZOOM_@IN")):
		zoom = clamp(zoom + Vector2(-0.1, -0.1), Vector2(0.1, 0.1), Vector2(10, 10));
	if (Input.is_action_pressed("ZOOM_OUT")):
		zoom = clamp(zoom + Vector2(+0.1, +0.1), Vector2(0.1, 0.1), Vector2(10, 10));
	pass;
