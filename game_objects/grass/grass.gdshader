shader_type spatial;
render_mode cull_disabled;

uniform vec3 color1 : source_color;
uniform vec3 color2 : source_color;
uniform sampler2D noise;
uniform float noiseScale = 20.0;

varying vec3 worldPos;

void vertex() {
	worldPos = (MODEL_MATRIX * vec4(VERTEX, 1.0)).xyz;

VERTEX.x += sin(NODE_POSITION_WORLD.x + TIME * 1.25 + UV.y) * ( 1.0 - UV.y) * 0.2;
	VERTEX.z += cos(NODE_POSITION_WORLD.z + TIME * 0.45 + UV.y) * ( 1.0 - UV.y) * 0.15;
}

void fragment() {
	vec3 noiseLevel = texture(noise, worldPos.xz / noiseScale).rgb;
	ALBEDO = mix(color1, color2, 1.0- UV.y) * mix(color1, color2, noiseLevel.r);
	if (!FRONT_FACING) {
		NORMAL = -NORMAL;
	}
}