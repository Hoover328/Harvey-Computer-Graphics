using System.Collections.Generic;
using UnityEngine;

public class Model
{
    List<Vector3Int> faces = new List<Vector3Int>();
    List<Vector3> vertices = new List<Vector3>();
    List<Vector2> texture_coordinates = new List<Vector2>();
    List<Vector3Int> texture_index_list = new List<Vector3Int>();
    List<Vector3> normals = new List<Vector3>();



    public Model()
    {
        addVertices();
        addFaces();
        addTextureCoords();
        addTexttureIndex();
        addNormals();
    }

    private void addNormals()
    {
        normals.Add(new Vector3(0, 0, -1)); //0
        normals.Add(new Vector3(0, 0, -1)); //1
        normals.Add(new Vector3(0, 0, -1)); //2
        normals.Add(new Vector3(0, 0, -1)); //3
        normals.Add(new Vector3(0, 0, -1)); //4
        normals.Add(new Vector3(0, 0, -1)); //5
        normals.Add(new Vector3(0, 0, -1)); //6
        normals.Add(new Vector3(0, 0, -1)); //7

        normals.Add(new Vector3(0, 0, 1)); //8
        normals.Add(new Vector3(0, 0, 1)); //9
        normals.Add(new Vector3(0, 0, 1)); //10
        normals.Add(new Vector3(0, 0, 1)); //11
        normals.Add(new Vector3(0, 0, 1)); //12
        normals.Add(new Vector3(0, 0, 1)); //13
        normals.Add(new Vector3(0, 0, 1)); //14
        normals.Add(new Vector3(0, 0, 1)); //15




    }
    private void addTexttureIndex()
    {
        texture_index_list.Add(new Vector3Int(4, 0, 12)); //0
        texture_index_list.Add(new Vector3Int(12, 0, 20)); //1
        texture_index_list.Add(new Vector3Int(16, 12, 20)); //2
        texture_index_list.Add(new Vector3Int(8, 12, 9)); //3
        texture_index_list.Add(new Vector3Int(13, 9, 12)); //4
        texture_index_list.Add(new Vector3Int(5, 13, 1)); //5
        /*
        texture_index_list.Add(new Vector3Int(, , )); //6
        texture_index_list.Add(new Vector3Int(, , )); //7
        texture_index_list.Add(new Vector3Int(, , )); //8
        texture_index_list.Add(new Vector3Int(, , )); //9
        texture_index_list.Add(new Vector3Int(, , )); //10
        texture_index_list.Add(new Vector3Int(, , )); //11
        texture_index_list.Add(new Vector3Int(, , )); //12
        texture_index_list.Add(new Vector3Int(, , )); //13
        texture_index_list.Add(new Vector3Int(, , )); //14
        texture_index_list.Add(new Vector3Int(, , )); //15
        texture_index_list.Add(new Vector3Int(, , )); //16
        texture_index_list.Add(new Vector3Int(, , )); //17
        texture_index_list.Add(new Vector3Int(, , )); //18
        texture_index_list.Add(new Vector3Int(, , )); //19
        texture_index_list.Add(new Vector3Int(, , )); //20
        texture_index_list.Add(new Vector3Int(, , )); //21
        texture_index_list.Add(new Vector3Int(, , )); //22
        texture_index_list.Add(new Vector3Int(, , )); //23
        */




    }

    private void addTextureCoords()
    {
        texture_coordinates.Add(new Vector2(118 , 101)); //0
        texture_coordinates.Add(new Vector2(268 , 101)); //1
        texture_coordinates.Add(new Vector2(353 , 101)); //2
        texture_coordinates.Add(new Vector2(503 , 101)); //3
        texture_coordinates.Add(new Vector2(148 , 133)); //4
        texture_coordinates.Add(new Vector2(238 , 133)); //5
        texture_coordinates.Add(new Vector2(383, 133)); //6
        texture_coordinates.Add(new Vector2(473, 133)); //7
        texture_coordinates.Add(new Vector2(148, 165)); //8
        texture_coordinates.Add(new Vector2(238, 165)); //9
        texture_coordinates.Add(new Vector2(383 , 165)); //10
        texture_coordinates.Add(new Vector2(473 , 165)); //11
        texture_coordinates.Add(new Vector2(148, 197)); //12
        texture_coordinates.Add(new Vector2(238, 197)); //13
        texture_coordinates.Add(new Vector2(383, 197)); //14
        texture_coordinates.Add(new Vector2(473, 197)); //15
        texture_coordinates.Add(new Vector2(148, 229)); //16
        texture_coordinates.Add(new Vector2(238, 229)); //17
        texture_coordinates.Add(new Vector2(383, 229)); //18
        texture_coordinates.Add(new Vector2(473, 229)); //19
        texture_coordinates.Add(new Vector2(118, 261)); //20
        texture_coordinates.Add(new Vector2(268, 261)); //21
        texture_coordinates.Add(new Vector2(353, 261)); //22
        texture_coordinates.Add(new Vector2(503, 261)); //23

        /*
        texture_coordinates.Add(new Vector3( , )); //24
        texture_coordinates.Add(new Vector3( , )); //25
        texture_coordinates.Add(new Vector3( , )); //26
        texture_coordinates.Add(new Vector3( , )); //27
        texture_coordinates.Add(new Vector3( , )); //28
        texture_coordinates.Add(new Vector3( , )); //29
        texture_coordinates.Add(new Vector3( , )); //30
        texture_coordinates.Add(new Vector3( , )); //31
        */



    }
    private void addVertices()
    {
        ///Front Verts
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

        ///Back Verts
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
        ///Front Faces
        faces.Add(new Vector3Int(2, 0, 6)); //0
        faces.Add(new Vector3Int(6, 0, 10)); //1
        faces.Add(new Vector3Int(8, 6, 10)); //2
        faces.Add(new Vector3Int(4, 6, 5)); //3
        faces.Add(new Vector3Int(7, 5, 6)); //4
        faces.Add(new Vector3Int(3, 7, 1)); //5
        faces.Add(new Vector3Int(7, 11, 1)); //6
        faces.Add(new Vector3Int(9, 11, 7)); //7

        ///Back Faces
        faces.Add(new Vector3Int(15, 13, 19)); //8
        faces.Add(new Vector3Int(19, 13, 23)); //9
        faces.Add(new Vector3Int(21, 19, 23)); //10
        faces.Add(new Vector3Int(17, 19, 16)); //11
        faces.Add(new Vector3Int(18, 16, 19)); //12
        faces.Add(new Vector3Int(14, 18,12)); //13
        faces.Add(new Vector3Int(18, 22, 12)); //14
        faces.Add(new Vector3Int(20, 22, 18)); //15

        ///Left Side Faces
        faces.Add(new Vector3Int(12, 22, 0)); //16
        faces.Add(new Vector3Int(10, 0, 22)); //17

        ///Right Side Faces
        faces.Add(new Vector3Int(1, 11, 13)); //18
        faces.Add(new Vector3Int(23, 13, 11)); //19

        ///Top Faces
        faces.Add(new Vector3Int(16, 4, 17)); //20
        faces.Add(new Vector3Int(5, 17, 4)); //21

        ///Bottom Faces
        faces.Add(new Vector3Int(6, 18, 7)); //22
        faces.Add(new Vector3Int(19, 7, 18)); //23

        ///Top Left Slant Faces
        faces.Add(new Vector3Int(0, 2, 12)); //24
        faces.Add(new Vector3Int(14, 12, 2)); //25

        ///Top Right Slant Faces
        faces.Add(new Vector3Int(13, 15, 1)); //26
        faces.Add(new Vector3Int(3, 1, 15)); //27

        ///Bottom Left Slant Faces
        faces.Add(new Vector3Int(8, 10, 20)); //28
        faces.Add(new Vector3Int(22, 20, 10)); //29

        ///Bottom Right Slant Faces
        faces.Add(new Vector3Int(21, 23, 9)); //30
        faces.Add(new Vector3Int(11, 9, 23)); //31

        ///Top Right Inside Side Faces
        faces.Add(new Vector3Int(15, 17, 3)); //32
        faces.Add(new Vector3Int(5, 3, 17)); //33

        ///Top Left Inside Sides Faces
        faces.Add(new Vector3Int(2, 4, 14)); //34
        faces.Add(new Vector3Int(16, 14, 4)); //35

        ///Bottom Right Inside Sides Faces
        faces.Add(new Vector3Int(19, 21, 7)); //36
        faces.Add(new Vector3Int(9, 7, 21)); //37

        ///Bottom Left Inside Sides Faces
        faces.Add(new Vector3Int(6, 8, 18)); //38
        faces.Add(new Vector3Int(20, 18, 8)); //39

    }

    public GameObject CreateUnityGameObject()
    {
        Mesh mesh = new Mesh();
        GameObject newGO = new GameObject();

        MeshFilter mesh_filter = newGO.AddComponent<MeshFilter>();
        MeshRenderer mesh_renderer = newGO.AddComponent<MeshRenderer>();

        List<Vector3> coords = new List<Vector3>();
        List<int> dummy_indices = new List<int>();
        List<Vector2> text_coords = new List<Vector2>();
        List<Vector3> normalz = new List<Vector3>();
        //fghfg
        for (int i = 0; i < faces.Count; i++)
        {
           // Vector3 normal_for_face = normals[i];

           // normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);

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
