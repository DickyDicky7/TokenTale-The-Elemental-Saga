shader_type spatial ;
render_mode unshaded;

uniform sampler2D  TEXTURE : filter_nearest;
uniform vec4      MODULATE : source_color  ;

void fragment()
{
	vec4 color  = texture    (
		          TEXTURE, UV);
	ALBEDO *= color.rgb * MODULATE.rgb;
	ALPHA  *= color. a  * MODULATE. a ;
}






