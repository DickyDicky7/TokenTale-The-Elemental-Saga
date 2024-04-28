shader_type spatial      ;
render_mode cull_disabled;

uniform vec3
model_dimensions = vec3(0.2, 0.2, 0.2);

uniform vec2     tile_size  = vec2(16.0, 16.0);
uniform float texture_scale     : hint_range(0.1, 10.0) = 1.0;
uniform bool    blend_tiles = false           ;
uniform float   blend_sharpness : hint_range(0.0, 10.0) = 2.0;
uniform int top   [10];
uniform int bottom[10];
uniform int front [10];
uniform int back  [10];
uniform int left  [10];
uniform int right [10];
uniform float animation_speed;
uniform sampler2D tileset_texture: source_color, filter_nearest, repeat_enable;
uniform sampler2D    trim_texture: source_color, filter_nearest, repeat_enable;
uniform vec2 trim_tile_size = vec2(16.0, 16.0);
uniform int  trim_front[10];
uniform int  trim_back [10];
uniform int  trim_left [10];
uniform int  trim_right[10];


varying vec3 instance_pos   ;
varying mat4    model_matrix;

void vertex()
{
    instance_pos    = MODEL_MATRIX[3].xyz; //Position of Instance, supports MultiMeshInstances in the use of GridMaps
       model_matrix = MODEL_MATRIX  ;
	COLOR = vec4(0.1, 0.1, 0.1, 0.0);
}

int getArraySize(int[10] arr)
{
    int size   = 0;
    for (int i = 0; i < arr.length(); i++)
	{
        if (arr[i] != 0) {
            size++;
        }
		else
		{
			break ;
		}
    }
    return  size  ;
}

vec4 get_base_tileset(vec3 world_position, vec3 normal)
{
	vec3 weights = abs(normal);
	weights  = pow(weights, vec3(blend_sharpness));
	weights /= dot(weights, vec3(1.0            ));
	if (!blend_tiles)
	{
		float threshold     = 0.7071;
		vec3  equal_weights = vec3(0.0, 1.0, 0.0); // Higher weight for top texture
		weights = mix(equal_weights, weights, step(threshold, max(weights.x, max(weights.y, weights.z))));
	}
	vec2 tileset_dimensions =             vec2(textureSize(tileset_texture,0)) / tile_size;
	vec2 tile_uv_scale      = tile_size / vec2(textureSize(tileset_texture,0))            ;
	vec2 tile_offset[6];

    int  frontSize = getArraySize(front );
    int   backSize = getArraySize(back  );
    int    topSize = getArraySize(top   );
    int bottomSize = getArraySize(bottom);
    int   leftSize = getArraySize(left  );
    int  rightSize = getArraySize(right );

    int  frontFrame = int(mod(TIME * animation_speed, float( frontSize)));
    int   backFrame = int(mod(TIME * animation_speed, float(  backSize)));
    int    topFrame = int(mod(TIME * animation_speed, float(   topSize)));
    int bottomFrame = int(mod(TIME * animation_speed, float(bottomSize)));
    int   leftFrame = int(mod(TIME * animation_speed, float(  leftSize)));
    int  rightFrame = int(mod(TIME * animation_speed, float( rightSize)));

    tile_offset[0] = vec2(mod(float(front [ frontFrame]), tileset_dimensions.x), floor(float(front [ frontFrame]) / tileset_dimensions.x)) * tile_uv_scale;
    tile_offset[1] = vec2(mod(float(back  [  backFrame]), tileset_dimensions.x), floor(float(back  [  backFrame]) / tileset_dimensions.x)) * tile_uv_scale;
    tile_offset[2] = vec2(mod(float(top   [   topFrame]), tileset_dimensions.x), floor(float(top   [   topFrame]) / tileset_dimensions.x)) * tile_uv_scale;
    tile_offset[3] = vec2(mod(float(bottom[bottomFrame]), tileset_dimensions.x), floor(float(bottom[bottomFrame]) / tileset_dimensions.x)) * tile_uv_scale;
    tile_offset[4] = vec2(mod(float(left  [  leftFrame]), tileset_dimensions.x), floor(float(left  [  leftFrame]) / tileset_dimensions.x)) * tile_uv_scale;
    tile_offset[5] = vec2(mod(float(right [ rightFrame]), tileset_dimensions.x), floor(float(right [ rightFrame]) / tileset_dimensions.x)) * tile_uv_scale;

	float margin = 0.001;
	vec4 colors[6];
	vec2 uv       ;
	uv = (-world_position.zy / model_dimensions.zy + 0.5 - vec2(-((model_dimensions.z - 1.0) / (2.0 * model_dimensions.z)))) * texture_scale;
	colors[0] = texture(tileset_texture, fract(uv) * tile_uv_scale + tile_offset[0]);
	uv = (-world_position.zy / model_dimensions.zy + 0.5 - vec2(-((model_dimensions.z - 1.0) / (2.0 * model_dimensions.z)))) * texture_scale;
	colors[1] = texture(tileset_texture, fract(uv) * tile_uv_scale + tile_offset[1]);
	uv = ( world_position.zx / model_dimensions.zx + 0.5 + vec2(-((model_dimensions.z - 1.0) / (2.0 * model_dimensions.z)), -((model_dimensions.x - 1.0) / (2.0 * model_dimensions.x)))) * texture_scale;
	colors[2] = texture(tileset_texture, fract(uv) * tile_uv_scale + tile_offset[2]);
	uv = ( world_position.zx / model_dimensions.zx + 0.5 + vec2(-((model_dimensions.z - 1.0) / (2.0 * model_dimensions.z)), -((model_dimensions.x - 1.0) / (2.0 * model_dimensions.x)))) * texture_scale;
	colors[3] = texture(tileset_texture, fract(uv) * tile_uv_scale + tile_offset[3]);
	uv = (-world_position.xy / model_dimensions.xy + 0.5 + vec2( ((model_dimensions.x - 1.0) / (2.0 * model_dimensions.x)),  ((model_dimensions.y - 1.0) / (2.0 * model_dimensions.y)))) * texture_scale;
	colors[4] = texture(tileset_texture, fract(uv) * tile_uv_scale + tile_offset[4]);
	uv = (-world_position.xy / model_dimensions.xy + 0.5 + vec2( ((model_dimensions.x - 1.0) / (2.0 * model_dimensions.x)),  ((model_dimensions.y - 1.0) / (2.0 * model_dimensions.y)))) * texture_scale;
	colors[5] = texture(tileset_texture, fract(uv) * tile_uv_scale + tile_offset[5]);

	vec4   color = weights.x * (normal.x > 0.0 ? colors[0] : colors[1]) +
				   weights.y * (normal.y > 0.0 ? colors[2] : colors[3]) +
				   weights.z * (normal.z > 0.0 ? colors[4] : colors[5]) ;
	return color;
}

vec4 get_trim_tileset(vec3 world_position, vec3 world_normal)
{
    vec2 uv        ;
    int  trim_index;

    int frontSize = getArraySize(trim_front);
    int  backSize = getArraySize(trim_back );
    int  leftSize = getArraySize(trim_left );
    int rightSize = getArraySize(trim_right);

    int frontFrame = int(mod(TIME * animation_speed, float(frontSize)));
    int  backFrame = int(mod(TIME * animation_speed, float( backSize)));
    int  leftFrame = int(mod(TIME * animation_speed, float( leftSize)));
    int rightFrame = int(mod(TIME * animation_speed, float(rightSize)));

    if (abs(world_normal.x) > 0.5)
	{   // Left  or right face
        uv         = world_position.zy;
        trim_index = world_normal  . x > 0.0 ? trim_right[rightFrame] : trim_left[leftFrame];
    }
	else
	if (abs(world_normal.z) > 0.5)
	{   // Front or back  face
        uv         = world_position.xy;
        trim_index = world_normal  . z > 0.0 ? trim_front[frontFrame] : trim_back[backFrame];
    }

    uv   =       uv /
	model_dimensions.xy + 0.5;
    uv.y = 1.0 - uv . y ;
    uv  *= texture_scale;

    vec2   trim_tileset_dimensions = vec2(textureSize(trim_texture, 0)) / trim_tile_size;
    vec2   trim_tile_uv_scale      =                                      trim_tile_size/
	                                 vec2(textureSize(trim_texture, 0)) ;
    vec2   trim_tile_offset        = vec2(mod(float(trim_index) , trim_tileset_dimensions.x ) , floor
	                                         (float(trim_index) / trim_tileset_dimensions.x)) * trim_tile_uv_scale;
    vec4   trim_color              =      texture    (trim_texture, fract(uv)                 * trim_tile_uv_scale+
	       trim_tile_offset);
	return trim_color       ;
}

void fragment()
{
    vec3 world_position = (INV_VIEW_MATRIX * vec4(VERTEX, 1.0)).xyz - instance_pos;
    vec3 world_normal   = (INV_VIEW_MATRIX * vec4(NORMAL, 0.0)).xyz               ;
    vec4 albedo     = get_base_tileset(inverse(mat3(model_matrix)) * world_position, inverse(mat3(model_matrix)) * world_normal);
    vec4 trim_color = get_trim_tileset(inverse(mat3(model_matrix)) * world_position, inverse(mat3(model_matrix)) * world_normal);
    bool is_trim_fragment  = trim_color.a > 0.1;
    bool is_on_target_face =
	 abs(world_normal.x) >  0.5 ||
	 abs(world_normal.z) >  0.5  ;
    vec4 final_color = is_on_target_face && is_trim_fragment ? trim_color : albedo;
    if  (final_color.a   <= 0.1)
	{
        discard;
    }
ALBEDO = final_color.rgb;
}
