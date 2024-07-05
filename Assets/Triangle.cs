using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Triangle: MonoBehaviour
{
    void Start()
    {
        Debug.Log("TriangleMesh script started");

        // Create a new mesh
        Mesh mesh = new Mesh();
        Debug.Log("Mesh created");

        // Define the vertices of the triangle
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),   // Bottom left
            new Vector3(1, 0, 0),   // Bottom right
            new Vector3(0.5f, 1, 0) // Top middle
        };
        Debug.Log("Vertices defined");

        // Define the triangles (in clockwise order)
        int[] triangles = new int[]
        {
            0, 2, 1  // Note: The order of vertices matters (clockwise)
        };
        Debug.Log("Triangles defined");

        // Define the UVs for the vertices
        Vector2[] uvs = new Vector2[]
        {
            new Vector2(0, 0),  // Bottom left
            new Vector2(1, 0),  // Bottom right
            new Vector2(0.5f, 1) // Top middle
        };
        Debug.Log("UVs defined");

        // Assign the vertices, triangles, and UVs to the mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        // Recalculate the normals and bounds of the mesh
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        Debug.Log("Mesh recalculated");

        // Assign the mesh to the MeshFilter component
        GetComponent<MeshFilter>().mesh = mesh;
        Debug.Log("Mesh assigned to MeshFilter");
    }
}
