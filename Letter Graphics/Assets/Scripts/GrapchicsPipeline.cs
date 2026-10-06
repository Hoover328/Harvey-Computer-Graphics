using UnityEngine;
using System.Collections.Generic;
using System;



public class GrapchicsPipeline : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Model myModel = new Model();
        myModel.CreateUnityGameObject();

        List<Vector4> verts = Homage(myModel.vertices);

      //  Display(verts);

        ///First Rotation
        ///Rotation by 39 degrees about (21, -2, -2).normalised
        ///

        Vector3 axis = (new Vector3(21, -2, -2));

        Matrix4x4 rotationMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(39, axis), Vector3.one);

        List<Vector4> imageAfterRotation = MatrixTransform(rotationMatrix, verts);
        //Display(imageAfterRotation);


        ///2nd Transformation Scale by (3, 5, 4)
        ///

        Matrix4x4 scaleMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(3, 5, 4));
      //  Display(scaleMatrix);

        List<Vector4> imageAfterScale = MatrixTransform(scaleMatrix, imageAfterRotation);
       // Display(imageAfterScale);

        ///3rd Transformation Translation by (4, 3, -1)

        Matrix4x4 translationMatrix = Matrix4x4.TRS(new Vector3(4, 3, -1), Quaternion.identity, Vector3.one);
        //Display(translationMatrix);

        List<Vector4> imageAfterTranslation = MatrixTransform(translationMatrix, verts);
        Display(imageAfterTranslation);
    }

    private List<Vector4> Homage(List<Vector3> vertices)
    {
        List<Vector4> result = new List<Vector4>();

        foreach(Vector3 v in vertices)
        {
            result.Add(new Vector4(v.x, v.y, v.z, 1f));
        }

        return result;
    }

    private List<Vector4> MatrixTransform(Matrix4x4 matrix, List<Vector4> verts)
    {
        List<Vector4> hold = new List<Vector4>();
        foreach (Vector4 v in verts)
        {
            hold.Add(matrix * v);
        }

        return hold;
    }

    private void Display(Matrix4x4 matrix)
    {
        for( int i=0; i<4; i++)
        {
            print(matrix.GetRow(i));
        }
    }

    void Display(List<Vector4> verts)
    {
        foreach (Vector3 v in verts)
        {
            print(v);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
