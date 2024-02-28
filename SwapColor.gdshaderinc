uniform vec4[10] old_colors : source_color;
uniform vec4[10] new_colors : source_color;

void swap_color(in sampler2D sampler, in vec2 coords, out vec4 color)
{
	vec4 current_color = texture(sampler, coords);
	for (int i = 0; i < 10; ++i)
	{
		if (current_color == old_colors[i])
		{
			color = new_colors[i];
		}
	}
}
