shader_type spatial ;
render_mode unshaded, cull_disabled, depth_draw_opaque, depth_prepass_alpha;

uniform sampler2D TEXTURE:filter_nearest;

void fragment()
{
vec4 color=texture(TEXTURE,UV);
ALBEDO*=color.rgb*vec3(1.5,1,1);
ALPHA*=color.a;
}