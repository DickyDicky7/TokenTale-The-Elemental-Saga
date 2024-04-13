using Godot;
using System.Collections.Generic;

namespace TokenTaleTheElementalSaga.TidalWave;

//AUTHOR NOTE: CODE CHẠY 1 LẦN THÔI, KHI GENERATE RA RỒI, MÌNH SAVE LẠI THÀNH RESOURCE SAU ĐÓ CÓ THỂ REUSE

[Tool]
#pragma warning disable IDE1006 // Naming Styles
public partial class _Mesh_Instance3D : MeshInstance3D
#pragma warning restore IDE1006 // Naming Styles
{
    public override void _Ready()
    {
                    base._Ready();
        
        Godot.Collections.Array surfaceArray = [];
                                surfaceArray.Resize((int)Mesh.ArrayType.Max);
        List<Vector3> vertices = [];
        List<Vector3> normal_s = [];
        List<Vector3> uvs = [];
        List<Vector3> idx = [];

    #   region GENERATE BLOCK CODE
        for (float x = -1.0f; x <= 1.0f; x += 0.01f)
        {
        for (float z = -1.0f; z <= 1.0f; z += 0.01f)
            {
                vertices.Add(new(  x  , +0.0f,   z  ));
                normal_s.Add(new(+0.0f, +1.0f, +0.0f));
            }
        }
    #endregion

        if (vertices.Count > 0)
        surfaceArray[(int)Mesh.ArrayType.Vertex] = vertices.ToArray();
        if (normal_s.Count > 0)
        surfaceArray[(int)Mesh.ArrayType.Normal] = normal_s.ToArray();
        if (uvs.Count > 0)
        surfaceArray[(int)Mesh.ArrayType.TexUV] = uvs.ToArray();
        if (idx.Count > 0)
        surfaceArray[(int)Mesh.ArrayType.Index] = idx.ToArray();

        if (Mesh is ArrayMesh arrayMesh)
        {
            arrayMesh.ClearSurfaces();
            arrayMesh.AddSurfaceFromArrays(Mesh.PrimitiveType.Lines, surfaceArray);
        }
    }
}
