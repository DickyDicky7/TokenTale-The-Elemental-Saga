shader_type canvas_item;

void fragment()
{
    COLOR = vec4(UV.x, UV.y, 0, 1);
}
