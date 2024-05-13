shader_type spatial ;
render_mode unshaded;

uniform sampler2D TEXTURE : filter_nearest;

void fragment()
{
	vec4 color  = texture    (
		          TEXTURE, UV);
	ALBEDO *= color.rgb * vec3(2.0, 0.0, 2.0);
	ALPHA  *= color. a                       ;
}







