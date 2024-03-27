uniform vec4 original_0: source_color = vec4(0, 0, 0, 0);
uniform vec4 original_1: source_color = vec4(0, 0, 0, 0);
uniform vec4 original_2: source_color = vec4(0, 0, 0, 0);
uniform vec4 original_3: source_color = vec4(0, 0, 0, 0);
uniform vec4 original_4: source_color = vec4(0, 0, 0, 0);

uniform vec4 replaced_0: source_color = vec4(0, 0, 0, 0);
uniform vec4 replaced_1: source_color = vec4(0, 0, 0, 0);
uniform vec4 replaced_2: source_color = vec4(0, 0, 0, 0);
uniform vec4 replaced_3: source_color = vec4(0, 0, 0, 0);
uniform vec4 replaced_4: source_color = vec4(0, 0, 0, 0);

const float precision = 0.1;

vec4 swap_color(vec4 color)
{
	vec4 original_colors[5] = vec4[5]
	(	 original_0,
		 original_1,
		 original_2,
		 original_3,
		 original_4
	);
	vec4 replaced_colors[5] = vec4[5]
	(
		 replaced_0,
		 replaced_1,
		 replaced_2,
		 replaced_3,
		 replaced_4
	);
	for (int i = 0; i < 5; i++)
	{
		if (distance(color, original_colors[i]) <= precision)
		{
			return replaced_colors[i];
		}
	}
	return color;
}
