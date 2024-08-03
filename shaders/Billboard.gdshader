shader_type spatial ;
render_mode unshaded, cull_front;

uniform sampler2D          tex : filter_nearest;

uniform      vec4 albedo_color : source_color  =  vec4(1.0);

uniform float   angle_in_degrees;

void vertex  ()
{
    MODELVIEW_MATRIX = VIEW_MATRIX * mat4(
     INV_VIEW_MATRIX[0]
    ,INV_VIEW_MATRIX[1]
    ,INV_VIEW_MATRIX[2]
    ,   MODEL_MATRIX[3]);
    MODELVIEW_MATRIX[0][0] *=  sin(radians(angle_in_degrees));
    MODELVIEW_MATRIX[0][1] +=  cos(radians(angle_in_degrees));
    MODELVIEW_MATRIX[1][0] +=  cos(radians(angle_in_degrees));
    MODELVIEW_MATRIX[1][1] *= -sin(radians(angle_in_degrees));
}

void fragment()
{
      vec4   tex_samp = texture(tex, UV);
    ALBEDO = tex_samp.rgb * albedo_color.rgb;
    ALPHA  = tex_samp.a   * albedo_color.a  ;
}
