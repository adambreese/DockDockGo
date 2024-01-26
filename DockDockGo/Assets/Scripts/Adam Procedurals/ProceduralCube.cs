using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralCube : MonoBehaviour
{
    Mesh mesh;
    MeshCollider meshCollider;
    List<Vector3> vertices;
    List<int> triangles;

    public float scale = 1f;
    float adjScale;

    public int posX, posY, posZ;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        meshCollider = GetComponent<MeshCollider>();
        adjScale = scale * 0.5f;
    }

    void Start()
    {
        MakeCube(adjScale, new Vector3(posX*scale, posY*scale, posZ*scale));
        UpdateMesh();
        UpdateMeshCollider();
    }

    void MakeCube(float cubeScale, Vector3 cubePos)
    {
        vertices = new List<Vector3>();
        triangles = new List<int>();

        for (int i = 0; i < 6; i++)
        {
            MakeFace(i, cubeScale, cubePos);
        }
    }

    void MakeFace(int dir, float faceScale, Vector3 facePos)
    {
        vertices.AddRange(CubeMeshData.faceVertices(dir, faceScale, facePos));
        int vCount = vertices.Count;

        triangles.Add(vCount - 4);
        triangles.Add(vCount - 4 + 1);
        triangles.Add(vCount - 4 + 2);
        triangles.Add(vCount - 4);
        triangles.Add(vCount - 4 + 2);
        triangles.Add(vCount - 4 + 3);
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
    }

    void UpdateMeshCollider()
    {
        // Assign the same vertices and triangles to the MeshCollider
        meshCollider.sharedMesh = mesh;
    }
}
