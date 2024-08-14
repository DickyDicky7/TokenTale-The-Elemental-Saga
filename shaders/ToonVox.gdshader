// NOTE: Shader automatically converted from Godot Engine 4.3.beta3.mono's StandardMaterial3D.

shader_type spatial;
render_mode blend_mix, depth_draw_opaque, cull_back, specular_schlick_ggx;

#define DIFFUSE_TYPE    0

#if     DIFFUSE_TYPE == 0
render_mode diffuse_burley;
#endif

#if     DIFFUSE_TYPE == 1
                           render_mode diffuse_lambert;
#endif

#if     DIFFUSE_TYPE == 2
                                                       render_mode diffuse_lambert_wrap;
#endif

#if     DIFFUSE_TYPE == 3
                                                                                        render_mode diffuse_toon;
#endif

/*
render_mode ambient_light_disabled;
 */

uniform vec4              albedo : source_color = vec4(1.0f);
uniform sampler2D texture_albedo : source_color                         , filter_linear_mipmap, repeat_enable;
uniform float       point_size   :    hint_range(0.1, 128.0, 0.1);

uniform float             roughness : hint_range(0.0, 001.0     );
uniform sampler2D texture_metallic  : hint_default_white                , filter_linear_mipmap, repeat_enable;
uniform vec4              metallic_texture_channel               ;
uniform sampler2D texture_roughness :                   hint_roughness_r, filter_linear_mipmap, repeat_enable;

uniform float specular : hint_range(0.0, 1.0, 0.01);
uniform float metallic : hint_range(0.0, 1.0, 0.01);

uniform vec3 uv1_scale ;
uniform vec3 uv1_offset;
uniform vec3 uv2_scale ;
uniform vec3 uv2_offset;
/*
uniform vec4      albedo         : source_color = vec4(1.0f);
 */
uniform sampler2D albedo_texture : source_color;
uniform bool       clamp_diffuse_to_max = false;

uniform int   cuts      : hint_range( 1   , 8   ) = 3   ;
uniform float wrap      : hint_range(-2.0f, 2.0f) = 0.0f;
uniform float steepness : hint_range( 1.0f, 8.0f) = 1.0f;

uniform bool      use_attenuation = true ;

uniform bool      use_specular    = true ;
uniform float         specular_strength  : hint_range(00.0f, 01.0f) = 01.0f;
uniform float         specular_shininess : hint_range(00.0f, 32.0f) = 16.0f;
uniform sampler2D     specular_map   :   source_color                      ;

uniform bool  use_rim = true;
uniform float     rim_width :   hint_range(00.0f, 16.0f) =      8.0f ;
uniform vec4      rim_color : source_color               = vec4(1.0f);

uniform bool      use_ramp = false;
uniform sampler2D     ramp : source_color;

uniform bool use_borders      = false;
uniform float    border_width = 0.01f;

varying vec3 vertex_pos;
varying vec3 normal    ;

float split_specular(
float      _specular)
{
	return step(0.5f, _specular);
}

void vertex()
{
//   Vertex Color is sRGB: Enabled
	if (!OUTPUT_IS_SRGB)
	{
		COLOR.rgb = mix(
		            pow((
		COLOR.rgb + vec3(0.05500)) * (1.0 / (1.0 + 0.05500)), vec3(02.40)),
		COLOR.rgb                  * (1.0 /                        12.92) ,
		lessThan(
		COLOR.rgb , vec3(0.04045)));
	}

	UV = UV * uv1_scale.xy + uv1_offset.xy;
	
	vertex_pos = VERTEX;
	normal     = NORMAL;
}

void fragment()
{
	vec2 base_uv =
	          UV ;

	vec4 albedo_tex = texture(
 texture_albedo     , base_uv);

	//  Vertex    Color Use as Albedo: Enabled
	albedo_tex *= COLOR;

	ALBEDO         =
	albedo    .rgb *
	albedo_tex.rgb ;

	float      metallic_tex = dot(texture(texture_metallic, base_uv), metallic_texture_channel);
	METALLIC = metallic_tex * metallic;
	SPECULAR = specular               ;

	     vec4   roughness_texture_channel =        vec4( 1.0 , 0.0 , 0.0 , 0.0    );
	float       roughness_tex             = dot(texture(texture_roughness, base_uv)
	          , roughness_texture_channel);
	ROUGHNESS = roughness_tex
	          * roughness;
}

//dithering start
uniform sampler2D DitherMap;
uniform float     DitherStrength = 0.1;
uniform float         ColorDepth = 3.0;
//dithering cease

void light()
{
	//      Attenuation    .
	float   attenuation = 1.0f;
	if (use_attenuation)
	{
		    attenuation =
			ATTENUATION ;
	}
	
	// Diffuse lighting.
	float NdotL = dot(NORMAL, LIGHT);
	float diffuse_amount = NdotL + (attenuation - 1.0) + wrap;
//  float diffuse_amount = NdotL *  attenuation        + wrap;
	      diffuse_amount *= steepness  ;
	float cuts_inv = 1.0f / float(cuts);
	float diffuse_stepped = clamp(diffuse_amount + mod(1.0f - diffuse_amount, cuts_inv), 0.0f, 1.0f);

	// Calculate borders.
	float        border = 0.0f;
	if (     use_borders      )
	{
		float corr_border_width = length(cross(NORMAL, LIGHT))
		      *    border_width
		      *    steepness;
		border = step(diffuse_stepped - corr_border_width, diffuse_amount)
		       - step(    1.0         - corr_border_width, diffuse_amount);
	}
	
	// Apply diffuse result to different styles .
	vec3 diffuse = ALBEDO.rgb * LIGHT_COLOR / PI;
	if (use_ramp)
	{
		 diffuse *= texture(ramp, vec2(diffuse_stepped * (1.0f - border), 0.0f)).rgb;
	}
	else
	{
		 diffuse *=                    diffuse_stepped * (1.0f - border)            ;
	}
	
	if (clamp_diffuse_to_max)
	{
	//  Clamp diffuse to max for multiple light sources.
		DIFFUSE_LIGHT  = max(DIFFUSE_LIGHT, diffuse);
	} else {
		DIFFUSE_LIGHT +=                    diffuse ;
	}
	
	//      Specular lighting.
	if (use_specular)
	{
		vec3 H = normalize(LIGHT + VIEW);
		float NdotH = dot(NORMAL, H);
		float specular_amount =max(pow (
		      NdotH, specular_shininess
		           * specular_shininess), 0.0f) * texture(specular_map, UV).r * attenuation;
		specular_amount = split_specular(
		specular_amount                 );
		SPECULAR_LIGHT +=
		specular_strength
	*   specular_amount
	*            LIGHT_COLOR             ;
	}
	
	// Simple rim lighting.
	if (  use_rim  )
	{
		float  NdotV    = dot(NORMAL, VIEW);
		float rim_light = pow(
		1.0 - NdotV
		,     rim_width      );
		SPECULAR_LIGHT += rim_light     *
		                  rim_color.rgb *
		                  rim_color.a   *
		                LIGHT_COLOR / PI; //Changed DIFFUSE_LIGHT to SPECULAR_LIGHT while migrating for similar result
	}
	
	//dithering start
	float light = max(0.0, dot(NORMAL, LIGHT)) * ATTENUATION;
	vec2 ts = vec2(textureSize(DitherMap, 0 ));
	vec2 uv = mod(floor(FRAGCOORD.xy), ts)
	                                 / ts;
	light +=      (texture    (DitherMap, uv).r - 0.5)
	                       *   DitherStrength;
	light  =   round(light * ColorDepth)
	                       / ColorDepth;
	DIFFUSE_LIGHT += light * ALBEDO * LIGHT_COLOR;
	//dithering cease
}


