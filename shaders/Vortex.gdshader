shader_type spatial ;
render_mode unshaded;

uniform sampler2D    noise_texture;
uniform sampler2D gradient_texture;

void vertex()
{
	float     radius_amplitude = 02.0;
	float procession_amplitude = 20.0;

	float procession_level = (float(INSTANCE_ID) / 1080.0) * 128.0;

	float procession_x = texture(noise_texture, vec2(TIME / 64.0,       procession_level / 1080.0)).x * procession_amplitude;
	float procession_z = texture(noise_texture, vec2(TIME / 64.0, 0.2 + procession_level / 1080.0)).x * procession_amplitude;

	float
	radius = abs               (texture(noise_texture, vec2(TIME, float(INSTANCE_ID) / 1080.0)).x * radius_amplitude);
	float rotation_base_angle = texture(noise_texture, vec2(      float(INSTANCE_ID) / 1080.0,
	                                                              float(INSTANCE_ID) / 1080.0)).x * 8.0              ;
	float rotation______angle =(
	      rotation_base_angle * 03.14)
	                          + TIME
	                          * 32.00;
	radius =
	radius + (float(INSTANCE_ID) / 1080.0)
	       * (float(INSTANCE_ID) / 1080.0) * 10.0;

	VERTEX.y = VERTEX.y + float(INSTANCE_ID) * 0.03;
	VERTEX.x = VERTEX.x + radius * cos(rotation______angle + (VERTEX.z / 0.5)) + procession_x;
	VERTEX.z = VERTEX.z + radius * sin(rotation______angle + (VERTEX.z / 0.5)) + procession_z;

	float color = texture(noise_texture, vec2(TIME / 64.0, (procession_level / 1080.0))).x - 0.4;
	      COLOR =
	vec4( color,
	      color,
	      color, 1.0);
}

void fragment()
{
	//ALBEDO = COLOR.rgb;
	vec4 color = texture(gradient_texture, UV);
	  ALBEDO = color.rgb;
	  ALPHA  = color. a ;
}
