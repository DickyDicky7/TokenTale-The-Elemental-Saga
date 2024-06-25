shader_type spatial ;
render_mode unshaded, cull_disabled, depth_draw_opaque, depth_prepass_alpha;
// Remove       unshaded if you want shading
// Replace cull_disabled if you want to only show one side (cull_front, cull_back)
// Reference for depth ::: https://docs.godotengine.org/en/stable/tutorials/shaders/shader_reference/spatial_shader.html#render-modes

// Sets pixels to flash color when trueee
uniform bool  active                    = false                   ;
// Thee colorr to useee _____ when active
uniform vec4  f_lashcolor: source_color = vec4(1.0, 1.0, 1.0, 1.0);
// Enables ___ Y-Billboarding when trueee
uniform bool  y_billboard               = false                   ;
// A copy of the texture for the Sprite3D or AnimatedSprite3D
uniform sampler2D     tex: source_color , filter_nearest          ;

/*
void vertex()
{
	// You can comment out this function if you don't need billboarding
	if (y_billboard == true)
	{
		MODELVIEW_MATRIX = VIEW_MATRIX * mat4(vec4(normalize(cross(vec3(0.0, 1.0, 0.0), INV_VIEW_MATRIX[2].xyz)), 0.0), vec4(0.0, 1.0, 0.0, 0.0), vec4(normalize(cross(INV_VIEW_MATRIX[0].xyz, vec3(0.0, 1.0, 0.0))), 0.0), MODEL_MATRIX[3]);
	}
	else
	{
		MODELVIEW_MATRIX = VIEW_MATRIX * mat4(
		 INV_VIEW_MATRIX[0],
		 INV_VIEW_MATRIX[1],
		 INV_VIEW_MATRIX[2],
		    MODEL_MATRIX[3]);
	}
	MODELVIEW_NORMAL_MATRIX = mat3(MODELVIEW_MATRIX);
}
*/

void fragment()
{
	vec4     col = texture(tex, UV);
	vec4 set_col =         col     ;
	if ( active )
	{
		 set_col = f_lashcolor     ;
	}
	ALBEDO = vec3(set_col.r ,
	              set_col.g ,
				  set_col.b);
	ALPHA  =          col.a ;
}

