shader_type spatial;
render_mode specular_schlick_ggx, unshaded, world_vertex_coords;

uniform sampler2D texture;
uniform vec4  base_color : source_color = vec4(1.00, 1.00, 1.00, 1.00);
uniform vec4   top_color : source_color = vec4(0.95, 0.62, 0.00, 1.00);
uniform vec4 right_color : source_color = vec4(0.54, 0.11, 0.94, 1.00);
uniform vec4 front_color : source_color = vec4(0.86, 0.18, 0.28, 1.00);
uniform float  intensity = 0.4;

varying vec3 true_normal;

vec4 blendAwithBFunc(vec4 _c0l0r_blendA_rgba, vec4 _c0l0r_blendB_rgba, float                        _fade_blend_c0l0r)
{
    return       mix(     _c0l0r_blendA_rgba,      _c0l0r_blendB_rgba,       _c0l0r_blendB_rgba.a * _fade_blend_c0l0r);
}

void vertex  ()
{
true_normal =
     NORMAL ;
}

void fragment()
{
    
    vec3 temp_albedo = texture(texture, UV.xy).rgb * base_color.rgb;

    vec3 dir_x = vec3(true_normal.x) * vec3(true_normal.x);
    vec3 dir_y = vec3(true_normal.y) * vec3(true_normal.y);
    vec3 dir_z = vec3(true_normal.z) * vec3(true_normal.z);

    vec3  dot_result = vec3(dot(dir_x, vec3(0.333333, 0.333333, 0.333333)), dot(dir_y, vec3(0.333333, 0.333333, 0.333333)), dot(dir_z, vec3(0.333333, 0.333333, 0.333333)));

    vec3 temp_output =                                ( base_color.rgb *   top_color.rgb ) ;
    vec3  mix_result = ( mix( mix( mix( temp_output , ( base_color.rgb * right_color.rgb ) , dot_result.x ) , temp_output , dot_result.y ) , ( base_color.rgb * front_color.rgb ) , dot_result.z ) );

    ALBEDO = blendAwithBFunc(vec4(temp_albedo, 1.0), vec4(mix_result, 1.0), intensity).rgb;

}
