shader_type spatial ;
render_mode unshaded;

uniform sampler2D SCREEN_TEXTURE : hint_screen_texture, filter_linear_mipmap;

const int pixel_size = 4; //resolution must be divisible by pixel_size

uniform float TimeScale = 10.0;
uniform float StepScale = 10.0;
uniform float AmplitudeScale = 0.1;

void vertex  ()
{
	VERTEX.y += sin(TIME * TimeScale + VERTEX.x * StepScale) * AmplitudeScale;
}

void fragment()
{
	float x = float(int(FRAGCOORD.x) % pixel_size);
	float y = float(int(FRAGCOORD.y) % pixel_size);

	x = FRAGCOORD.x + floor(float(pixel_size) / 2.0) - x;
	y = FRAGCOORD.y + floor(float(pixel_size) / 2.0) - y;

	ALBEDO = texture(SCREEN_TEXTURE, vec2(x, y) / VIEWPORT_SIZE).xyz;
}