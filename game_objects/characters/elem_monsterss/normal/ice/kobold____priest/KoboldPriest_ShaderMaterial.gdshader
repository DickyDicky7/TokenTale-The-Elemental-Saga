shader_type canvas_item;

uniform sampler2D normal_map;

#include "res://SwapColor.gdshaderinc"

void fragment()
{
	NORMAL = 2.0 * texture(normal_map, UV).rgb - 1.0;
	swap_color(TEXTURE, UV, COLOR);
}
