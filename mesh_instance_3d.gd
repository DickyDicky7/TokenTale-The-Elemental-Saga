@tool
extends MeshInstance3D


func _ready():
	var meshDataTool = MeshDataTool.new();
	#Get surface 0 into mesh data tool
	var meshArray    : ArrayMesh   = mesh;
	meshDataTool.create_from_surface(meshArray, 0)
	for       vertex in range(meshDataTool.get_vertex_count()):
		var   vertexColor  =  meshDataTool.get_vertex_color(vertex);
		print(vertexColor);

	pass;
