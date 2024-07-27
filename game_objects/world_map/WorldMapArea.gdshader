shader_type    canvas_item ;

uniform vec4 replaced_color: source_color;

void fragment()
{
	             COLOR = texture(TEXTURE , UV );
	if (distance(COLOR , replaced_color) < 0.1)
	{
	             COLOR = vec4(0);
	}
}
