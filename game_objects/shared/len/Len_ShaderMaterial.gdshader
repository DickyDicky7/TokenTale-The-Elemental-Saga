shader_type spatial ;
render_mode unshaded;

uniform sampler2D colorTexture;

void fragment()
{
	vec4 color = texture(colorTexture, UV);
	ALBEDO = color.rgb;
	ALPHA  = color. a ;
}
