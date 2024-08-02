shader_type sky;
render_mode use_debanding;

uniform vec4     sky_top_color : source_color = vec4(0.3, 0.5, 0.5, 1.0);
uniform vec4 sky_horizon_color : source_color = vec4(1.0, 1.0, 1.0, 1.0);
uniform float sky_curve : hint_range(0, 1) = 0.15;
uniform float sky_energy                   = 1.00; // In Lux.
uniform sampler2D      sky_cover          : filter_linear, source_color, hint_default_black;
uniform vec4           sky_cover_modulate :                source_color = vec4(1.0, 1.0, 1.0, 1.0);
uniform vec4 ground_bottom_color          :                source_color = vec4(0.1, 0.1, 0.1, 1.0);
uniform vec4                                                                                       ground_horizon_color : source_color = vec4(1.0, 1.0, 1.0, 1.0);
uniform float ground_curve : hint_range(0, 1) = 0.02;
uniform float ground_energy                   = 1.00;
uniform float sun_angle_max = 0.523598776;
uniform float sun_curve : hint_range(0, 1  ) = 0.15;
uniform float  exposure : hint_range(0, 128) = 1.00;

// Uniform for the dither pattern texture
uniform sampler2D dither_pattern   : filter_nearest, hint_default_black;
uniform     float dither_intensity :   hint_range(0, 1) = 0.1          ;

uniform bool cloud_on = false;
uniform sampler2D cloud_texture1;
uniform sampler2D cloud_texture2;
uniform vec2  cloud_direction1 = vec2(-1 ,  1 );
uniform vec2  cloud_direction2 = vec2( 1 , -1 );
uniform vec2  cloud_scale      = vec2(0.1, 0.1);
uniform float cloud_distance = 0.0;
uniform float cloud_speed1   = 1.0;
uniform float cloud_speed2   = 1.0;

void sky() {
    float            v_angle = acos(clamp(EYEDIR.y, -1.0, 1.0));
    float c = (1.0 - v_angle / (PI * 0.5));
    vec3 sky = mix(sky_horizon_color.rgb, sky_top_color.rgb, clamp(1.0 - pow(1.0 - c, 1.0 / sky_curve), 0.0, 1.0));
         sky*=     sky_energy;

    if (LIGHT0_ENABLED)
    {
        float sun_angle = acos(dot(LIGHT0_DIRECTION, EYEDIR));
        if   (sun_angle <          LIGHT0_SIZE)
        {
              sky = LIGHT0_COLOR * LIGHT0_ENERGY             ;
        }
        else
        if   (sun_angle < sun_angle_max)
        {
            float c2 =    (   sun_angle     - LIGHT0_SIZE)
                     /    (   sun_angle_max - LIGHT0_SIZE);
              sky    = mix(LIGHT0_COLOR   *   LIGHT0_ENERGY, sky, clamp(1.0 - pow(1.0 - c2, 1.0 / sun_curve), 0.0, 1.0));
        }
    }

    if (LIGHT1_ENABLED)
    {
        float sun_angle = acos(dot(LIGHT1_DIRECTION, EYEDIR));
        if   (sun_angle <          LIGHT1_SIZE)
        {
              sky = LIGHT1_COLOR * LIGHT1_ENERGY             ;
        }
        else
        if   (sun_angle < sun_angle_max)
        {
            float c2 =    (   sun_angle     - LIGHT1_SIZE)
                     /    (   sun_angle_max - LIGHT1_SIZE);
              sky    = mix(LIGHT1_COLOR   *   LIGHT1_ENERGY, sky, clamp(1.0 - pow(1.0 - c2, 1.0 / sun_curve), 0.0, 1.0));
        }
    }

    if (LIGHT2_ENABLED)
    {
        float sun_angle = acos(dot(LIGHT2_DIRECTION, EYEDIR));
        if   (sun_angle <          LIGHT2_SIZE)
        {
              sky = LIGHT2_COLOR * LIGHT2_ENERGY             ;
        }
        else
        if   (sun_angle < sun_angle_max)
        {
            float c2 =    (   sun_angle     - LIGHT2_SIZE)
                     /    (   sun_angle_max - LIGHT2_SIZE);
              sky    = mix(LIGHT2_COLOR   *   LIGHT2_ENERGY, sky, clamp(1.0 - pow(1.0 - c2, 1.0 / sun_curve), 0.0, 1.0));
        }
    }

    if (LIGHT3_ENABLED)
    {
        float sun_angle = acos(dot(LIGHT3_DIRECTION, EYEDIR));
        if   (sun_angle <          LIGHT3_SIZE)
        {
              sky = LIGHT3_COLOR * LIGHT3_ENERGY             ;
        }
        else
        if   (sun_angle < sun_angle_max)
        {
            float c2 =    (   sun_angle     - LIGHT3_SIZE)
                     /    (   sun_angle_max - LIGHT3_SIZE);
              sky    = mix(LIGHT3_COLOR   *   LIGHT3_ENERGY, sky, clamp(1.0 - pow(1.0 - c2, 1.0 / sun_curve), 0.0, 1.0));
        }
    }

    vec4    sky_cover_texture = texture(sky_cover, SKY_COORDS );
    sky += (sky_cover_texture.rgb   *   sky_cover_modulate.rgb) * sky_cover_texture.a * sky_cover_modulate.a * sky_energy;

       c = (v_angle - (PI * 0.5)) / (PI * 0.5);
    vec3 ground  = mix(ground_horizon_color.rgb, ground_bottom_color.rgb, clamp(1.0 - pow(1.0 - c, 1.0 / ground_curve), 0.0, 1.0));
         ground *=     ground_energy;

    if (cloud_on)
    {
        vec2 sky_uv = EYEDIR.xz / EYEDIR.y;
        vec3 clouds = texture(cloud_texture1, (sky_uv * cloud_scale) + (TIME * cloud_direction1 * cloud_speed1 * .01)).rgb
                    - texture(cloud_texture2, (sky_uv * cloud_scale) + (TIME * cloud_direction2 * cloud_speed2 * .01)).rgb;
             clouds =       clouds - smoothstep(0.0, EYEDIR.y, cloud_distance);
             clouds = clamp(clouds , 0,1) ;
      sky += clouds;
    }

    vec3   final_color = mix(ground, sky, step(0.0, EYEDIR.y)) * exposure;

    // Apply dithering
    vec2  dither_coords = mod(FRAGCOORD.xy / vec2(textureSize(dither_pattern, 0)), 1.0);
    float dither_value  =                         texture    (dither_pattern,
          dither_coords).r;
                 final_color += dither_intensity * (dither_value - 0.5);

//  COLOR = vec4(final_color, 1.0);
    COLOR =      final_color      ;
}
