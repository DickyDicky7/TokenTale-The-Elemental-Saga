shader_type spatial ;
render_mode unshaded;

uniform float TimeScale = 10.0;
uniform float StepScale = 10.0;
uniform float AmplitudeScale = 0.1;

void vertex  ()
{
	VERTEX.y += sin(TIME * TimeScale + VERTEX.x * StepScale) * AmplitudeScale;
}

void fragment()
{
	ALBEDO    = vec3(0.0, 0.5, 1.5);
}
