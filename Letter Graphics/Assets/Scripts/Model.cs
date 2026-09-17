using System.Collections.Generic;
using UnityEngine;

public class Model
{
    List<Vector3Int> faces = new List<Vector3Int>();
    List<Vector3> vertices = new List<Vector3>();

    public Model()
    {
        addVertices();
        addFaces();
    }

    private void addVertices()
    {
        vertices.Add(new Vector3(-2.5f, 2.5f, -1f)); //0
        vertices.Add(new Vector3(2.5f, 2.5f, -1f)); //1
        vertices.Add(new Vector3(-1.5f, 1.5f, -1f)); //2
        vertices.Add(new Vector3(1.5f, 1.5f, -1f)); //3
        vertices.Add(new Vector3(-1.5f, 0.5f, -1f)); //4
        vertices.Add(new Vector3(1.5f, 0.5f, -1f)); //5
        vertices.Add(new Vector3(-1.5f, -0.5f, -1f)); //6
        vertices.Add(new Vector3(1.5f, -0.5f, -1f)); //7
        vertices.Add(new Vector3(-1.5f, -1.5f, -1f)); //8
        vertices.Add(new Vector3(1.5f, -1.5f, -1f)); //9
        vertices.Add(new Vector3(-2.5f, -2.5f, -1f)); //10
        vertices.Add(new Vector3(2.5f, -2.5f, -1f)); //11

        vertices.Add(new Vector3(-2.5f, 2.5f, 1f)); //12
        vertices.Add(new Vector3(2.5f, 2.5f, 1f)); //13
        vertices.Add(new Vector3(-1.5f, 1.5f, 1f)); //14
        vertices.Add(new Vector3(1.5f, 1.5f, 1f)); //15
        vertices.Add(new Vector3(-1.5f, 0.5f, 1f)); //16
        vertices.Add(new Vector3(1.5f, 0.5f, 1f)); //17
        vertices.Add(new Vector3(-1.5f, -0.5f, 1f)); //18
        vertices.Add(new Vector3(1.5f, -0.5f, 1f)); //19
        vertices.Add(new Vector3(-1.5f, -1.5f, 1f)); //20
        vertices.Add(new Vector3(1.5f, -1.5f, 1f)); //21
        vertices.Add(new Vector3(-2.5f, -2.5f, 1f)); //22
        vertices.Add(new Vector3(2.5f, -2.5f, 1f)); //23


    }

    private void addFaces()
    {
        faces.Add(new Vector3Int(2, 0, 6)); //0
        faces.Add(new Vector3Int(6, 0, 10)); //1
        faces.Add(new Vector3Int(8, 6, 10)); //2
        faces.Add(new Vector3Int(4, 6, 5)); //3
        faces.Add(new Vector3Int(7, 5, 6)); //4
        faces.Add(new Vector3Int(3, 7, 1)); //5
        faces.Add(new Vector3Int(7, 11, 1)); //6
        faces.Add(new Vector3Int(9, 11, 7)); //7

        faces.Add(new Vector3Int(15, 13, 19)); //8
        faces.Add(new Vector3Int(19, 13, 23)); //9
        faces.Add(new Vector3Int(21, 19, 23)); //10
        faces.Add(new Vector3Int(17, 19, 16)); //11
        faces.Add(new Vector3Int(18, 16, 19)); //12
        faces.Add(new Vector3Int(14, 18,12)); //13
        faces.Add(new Vector3Int(18, 22, 12)); //14
        faces.Add(new Vector3Int(20, 22, 18)); //15

        faces.Add(new Vector3Int(12, 22, 0)); //16
        faces.Add(new Vector3Int(10, 0, 22)); //17

        faces.Add(new Vector3Int(1, 11, 13)); //18
        faces.Add(new Vector3Int(23, 13, 11)); //19

        faces.Add(new Vector3Int(16, 4, 17)); //20
        faces.Add(new Vector3Int(5, 17, 4)); //21

        faces.Add(new Vector3Int(6, 18, 7)); //22
        faces.Add(new Vector3Int(19, 7, 18)); //23

        faces.Add(new Vector3Int(0, 2, 12)); //24
        faces.Add(new Vector3Int(14, 12, 2)); //25

        faces.Add(new Vector3Int(13, 15, 1)); //26
        faces.Add(new Vector3Int(3, 1, 15)); //27








    }

    public GameObject CreateUnityGameObject()
    {
        Mesh mesh = new Mesh();
        GameObject newGO = new GameObject();

        MeshFilter mesh_filter = newGO.AddComponent<MeshFilter>();
        MeshRenderer mesh_renderer = newGO.AddComponent<MeshRenderer>();

        List<Vector3> coords = new List<Vector3>();
        List<int> dummy_indices = new List<int>();
        /*List<Vector2> text_coords = new List<Vector2>();
        List<Vector3> normalz = new List<Vector3>();*/
        //fghfg
        for (int i = 0; i < faces.Count; i++)
        {
            //Vector3 normal_for_face = normals[i];

            //normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);

            coords.Add(vertices[faces[i].x]); dummy_indices.Add(i * 3); //text_coords.Add(texture_coordinates[texture_index_list[i].x]); normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].y]); dummy_indices.Add(i * 3 + 2); //text_coords.Add(texture_coordinates[texture_index_list[i].y]); normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].z]); dummy_indices.Add(i * 3 + 1); //text_coords.Add(texture_coordinates[texture_index_list[i].z]); normalz.Add(normal_for_face);
        }

        mesh.vertices = coords.ToArray();
        mesh.triangles = dummy_indices.ToArray();
        /*mesh.uv = text_coords.ToArray();
        mesh.normals = normalz.ToArray();*/
        mesh_filter.mesh = mesh;

        return newGO;
    }
}
