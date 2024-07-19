#@tool
extends Node3D;

@export var top_color: Color;
@export var bot_color: Color;

@export var   game_count: int;
@export var editor_count: int;
@export var area = Vector2(+010.000, +010.000);
@export var blade_height     = Vector2(+000.060, +000.080);
@export var blade_width      = Vector2(+000.010, +000.020);
@export var blade_rotation   = Vector2(-180.000, +180.000);
@export var blade_sway_yaw   = Vector2(-000.175, +000.175);
@export var blade_sway_pitch = Vector2(+000.000, +000.175);

@export var thread_count:  int          = 4 ;
var         threads     : Array[Thread] = [];

var        mesh_rid: RID                                                                          ;
var        material: RID            = preload("res://game_asset_s/grass/Grass.material").get_rid();
var shader_material: ShaderMaterial = preload("res://game_asset_s/grass/Grass.material")          ;

var x: float;
var y: float;
var z: float;

func _ready() -> void:
	shader_material.set_shader_parameter("color_top"   , top_color);
	shader_material.set_shader_parameter("color_bottom", bot_color);
	x = self.global_position.x;
	y = self.global_position.y;
	z = self.global_position.z;
	rebuild();
	pass     ;

func make_blade_mesh() -> ArrayMesh:
	var mesh: ArrayMesh = ArrayMesh.new();
	var arr             =              [];
	arr.resize(    Mesh.ARRAY_MAX    );
	
	var verts: PackedVector3Array = PackedVector3Array();
	var uvs  : PackedVector2Array = PackedVector2Array();
	
	verts.push_back(Vector3(-0.5, +0.0, +0.0));
	verts.push_back(Vector3(+0.5, +0.0, +0.0));
	verts.push_back(Vector3(+0.0, +1.0, +0.0));
	
	uvs  .push_back(Vector2(+0.0, +0.0      ));
	uvs  .push_back(Vector2(+1.0, +0.0      ));
	uvs  .push_back(Vector2(+0.5, +1.0      ));
	
	arr[Mesh.ARRAY_VERTEX] = verts;
	arr[Mesh.ARRAY_TEX_UV] = uvs  ;
	
	mesh.add_surface_from_arrays(Mesh.PRIMITIVE_TRIANGLES, arr);
	
	return                       mesh;

func rid_blade_mesh() -> RID:
	var mesh            :RID = RenderingServer.mesh_create();
	var arr                  =                            [];
	arr.resize(Mesh.ARRAY_MAX);
	
	var verts: PackedVector3Array = PackedVector3Array();
	var uvs  : PackedVector2Array = PackedVector2Array();
	
	verts.push_back(Vector3(-0.5, +0.0, +0.0));
	verts.push_back(Vector3(+0.5, +0.0, +0.0));
	verts.push_back(Vector3(+0.0, +1.0, +0.0));
	
	uvs  .push_back(Vector2(+0.0, +0.0      ));
	uvs  .push_back(Vector2(+1.0, +0.0      ));
	uvs  .push_back(Vector2(+0.5, +1.0      ));
	
	arr[Mesh.ARRAY_VERTEX] = verts;
	arr[Mesh.ARRAY_TEX_UV] = uvs  ;
	
	RenderingServer.mesh_add_surface_from_arrays(mesh,
	RenderingServer.       PRIMITIVE_TRIANGLES       , arr);
	
	return                                       mesh;

func rebuild() -> void:
	var multimesh: RID = RenderingServer.multimesh_create();

	RenderingServer.multimesh_allocate_data              (
					multimesh,          get_count(),
	RenderingServer.MULTIMESH_TRANSFORM_3D, false  , true);
	
	mesh_rid = rid_blade_mesh();
	RenderingServer.multimesh_set_mesh(multimesh, mesh_rid);
	
	var bpt = get_count() / thread_count;  # blades per thread
	threads =          []               ;
	for t:int in thread_count:
		threads   .append(Thread.new());
		threads[t].start (thread_worker.bind([multimesh, bpt * t, bpt * t + bpt]));
	
	for t:int in thread_count:
		threads[t].   wait_to_finish() ;
	
#	for i:int in get_count():
#		setup_blade(multimesh, i);
	
	var instance: RID = RenderingServer.instance_create();
	var scenario: RID =  get_world_3d().scenario         ;
	
	RenderingServer.instance_set_scenario(instance, scenario );
	RenderingServer.instance_set_base    (instance, multimesh);
	
	RenderingServer.instance_geometry_set_material_override(instance, material);
	
	pass;
	
func thread_worker(data: Array) -> void:
	var   rid = data[0];
	var start = data[1];
	var stop  = data[2];
	
	for i:int in range(start, stop): setup_blade(rid     , i     );
		
	pass;

func                                 setup_blade(rid: RID, i: int) -> void:
	var width  = randf_range(blade_width .x, blade_width .y);
	var height = randf_range(blade_height.x, blade_height.y);
	
	var position =                  Vector2(
				   randf_range(-area.x / 2.0, +area.x / 2.0) ,
				   randf_range(-area.y / 2.0, +area.y / 2.0));
	var rotation = randf_range(blade_rotation.x, blade_rotation.y);
	
	var sway_yaw   = randf_range(blade_sway_yaw  .x, blade_sway_yaw  .y);
	var sway_pitch = randf_range(blade_sway_pitch.x, blade_sway_pitch.y);
	
	var transform: Transform3D = Transform3D.IDENTITY;
	transform.origin           =    Vector3       (
									position.x + x ,
												 y ,
									position.y + z);
	transform.basis = Basis.IDENTITY.rotated(Vector3.UP, deg_to_rad(rotation));
	
	RenderingServer.multimesh_instance_set_transform  (rid, i, transform                                                         );
	RenderingServer.multimesh_instance_set_custom_data(rid, i, Color(width, height, deg_to_rad(sway_pitch), deg_to_rad(sway_yaw)));
	
	pass;

func get_count() -> int:
	if Engine.is_editor_hint():
		return   editor_count ;
	else:
		return     game_count ;
