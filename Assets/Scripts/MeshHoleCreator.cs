using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshHoleCreator : MonoBehaviour
{
    public float holeRadius = 0.5f;
    public Vector2 holeCenter = new Vector2(0, 0);

    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;

        // Crear una lista para mantener los índices de triángulos válidos
        var newTriangles = new System.Collections.Generic.List<int>();

        for (int i = 0; i < triangles.Length; i += 3)
        {
            Vector3 v1 = vertices[triangles[i]];
            Vector3 v2 = vertices[triangles[i + 1]];
            Vector3 v3 = vertices[triangles[i + 2]];

            // Comprobar si los vértices están fuera del radio del hoyo
            if ((v1 - new Vector3(holeCenter.x, 0, holeCenter.y)).magnitude > holeRadius &&
                (v2 - new Vector3(holeCenter.x, 0, holeCenter.y)).magnitude > holeRadius &&
                (v3 - new Vector3(holeCenter.x, 0, holeCenter.y)).magnitude > holeRadius)
            {
                newTriangles.Add(triangles[i]);
                newTriangles.Add(triangles[i + 1]);
                newTriangles.Add(triangles[i + 2]);
            }
        }

        // Establecer los nuevos triángulos que evitan el área del hoyo
        mesh.triangles = newTriangles.ToArray();
        mesh.RecalculateNormals();
    }
}
