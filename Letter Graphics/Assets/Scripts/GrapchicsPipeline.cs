using NUnit;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class GrapchicsPipeline : MonoBehaviour
{
    Texture2D screen;
    public GameObject screenGo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screen = new Texture2D(1024, 1024);
        
        Model myModel = new Model();
       // myModel.CreateUnityGameObject();

        List<Vector4> verts = Homage(myModel.vertices);

        print("Verts");
        Display(verts);

        ///First Rotation
        ///Rotation by 39 degrees about (21, -2, -2).normalised
        ///

        Vector3 axis = (new Vector3(21, -2, -2).normalized);

        Matrix4x4 rotationMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(39, axis), Vector3.one);
        print("Rotation Matrix");
        Display(rotationMatrix);

        List<Vector4> imageAfterRotation = MatrixTransform(rotationMatrix, verts);
        print("After Rotation");
        Display(imageAfterRotation);


        ///2nd Transformation Scale by (3, 5, 4)
        ///

        Matrix4x4 scaleMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(3, 5, 4));
        print("Scale Matrix");
        Display(scaleMatrix);

        List<Vector4> imageAfterScale = MatrixTransform(scaleMatrix, imageAfterRotation);
        print("After Scale");
        Display(imageAfterScale);

        ///3rd Transformation Translation by (4, 3, -1)

        Matrix4x4 translationMatrix = Matrix4x4.TRS(new Vector3(4, 3, -1), Quaternion.identity, Vector3.one);
        print("Translation Matrix");
        Display(translationMatrix);


        List<Vector4> imageAfterTranslation = MatrixTransform(translationMatrix, imageAfterScale);
        print("After Translate");
        Display(imageAfterTranslation);


        Matrix4x4 singleMatrixOfTransformations = translationMatrix * scaleMatrix * rotationMatrix;
        print("Single Matrix");
         Display(singleMatrixOfTransformations);

        List<Vector4> imageAfterSingleMatrix = MatrixTransform(singleMatrixOfTransformations, verts);
        print("After Single");
         Display(imageAfterSingleMatrix);

        Vector3 camPosition = new Vector3(23, 1, 48);
        Vector3 camLookAt = new Vector3(-2, 3, 4);
        Vector3 camUp = new Vector3(-1, -2, 21).normalized;
        print("Look at");

        Matrix4x4 lookAtMatrix = Matrix4x4.LookAt(camPosition, camLookAt, camUp);
        Display(lookAtMatrix);

        print("After Look at");
        List<Vector4> imageAfterLookAtMatrix = MatrixTransform(lookAtMatrix, imageAfterTranslation);
        Display(imageAfterLookAtMatrix);

        ///Projection
        Matrix4x4 perspectiveMatrix = Matrix4x4.Perspective(100, 1, 1, 1000);
        print("Perspective Matrix");
        Display(perspectiveMatrix);

        List<Vector4> imageAfterPerspective = MatrixTransform(perspectiveMatrix, imageAfterLookAtMatrix);
        print("Image After Perspective");
        Display(imageAfterPerspective);

        Matrix4x4 everythingMatrix = perspectiveMatrix * lookAtMatrix * singleMatrixOfTransformations;
        print("Everything Matrix");
        Display(everythingMatrix);

        List<Vector4> imageAfterEverything = MatrixTransform(everythingMatrix, verts);
        print("Image After Everything");
        Display(imageAfterEverything);

        print("VERTS DIVIDED#############################");
        Display(VertsDividedByZ(imageAfterEverything));




        Draw(bresh(new Vector2Int(0,0), new Vector2Int(512,512)));
        screenGo.GetComponent<Renderer>().material.mainTexture = screen;
        screen.Apply();

    }

    private void Draw(List<Vector2Int> vector2Ints)
    {
        foreach (Vector2Int v in vector2Ints)
        {
            screen.SetPixel(v.x, v.y, Color.red);
        }
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
        foreach (Vector4 v in verts)
        {
            print(v);
        }
    }

    private List<Vector4> VertsDividedByZ(List<Vector4> verts)
    {
        List<Vector4> vertsDivided = new List<Vector4>();
        foreach (Vector4 v in verts)
        {
             vertsDivided.Add(new Vector3(v.x / v.z, v.y / v.z, v.z));
        }

        return vertsDivided;
    }

    public List<Vector2Int> bresh(Vector2Int s, Vector2Int e)
    {
        List<Vector2Int> output = new List<Vector2Int>();
        int dx = e.x - s.x;

        if (dx < 0)
        {
            return bresh(e, s);
        }

        int dy = e.y - s.y;

        if (dy < 0)
        {
            return NegY(bresh(NegY(s), NegY(e)));
        }

        if(dy > dx)
        {
            return SwapXY(bresh(SwapXY(s), SwapXY(e)));
        }

        int D = dy - dx;

        int N = 2 * D;

        int P = 2 * dy;

        int P0 = P - dx;

        output.Add(new Vector2Int(s.x, s.y));
        while (s.x != e.x)
        {
            s.x++;

            if(P0 < 0)
            {
                P0 += P; 
            }

            else
            {
                s.y++;
                P0 += N;
            }

            output.Add(new Vector2Int(s.x, s.y));
        }

        return output;
    }

    public List<Vector2Int> SwapXY(List<Vector2Int> vector2Ints)
    {
        List<Vector2Int> swappedList = new List<Vector2Int>();

        foreach (var v in vector2Ints)
        {
            swappedList.Add(SwapXY(v));
        }

        return swappedList;
    }

    public Vector2Int SwapXY(Vector2Int v)
    {
        return new Vector2Int(v.y, v.x);
    }


    public List<Vector2Int> NegY(List<Vector2Int> vector2Ints)
    {
        List<Vector2Int> negativeList = new List<Vector2Int>();

        foreach (var v in vector2Ints)
        {
            negativeList.Add(NegY(v));
        }

        return negativeList;
    }

    public Vector2Int NegY(Vector2Int v)
    {
        return new Vector2Int(v.x, -v.y);
    }



    // Update is called once per frame
    void Update()
    {

        screen = new Texture2D(1024, 1024);

        Model myModel = new Model();
       // myModel.CreateUnityGameObject();

        List<Vector4> verts = Homage(myModel.vertices);

        Matrix4x4 world = Matrix4x4.TRS(new Vector3(0, 0, 4), Quaternion.identity, Vector3.one);

        Matrix4x4 view = Matrix4x4.LookAt(Vector3.zero, new Vector3(0, 0, 4), Vector3.up);

        Matrix4x4 proj = Matrix4x4.Perspective(90, 1, 1, 1000);


        Matrix4x4 supermatrix = proj * view * world;

        List<Vector4> pts = MatrixTransform(supermatrix, verts);

        List<Vector4> projpts = VertsDividedByZ(pts);

        List<Vector2Int> pixelPts = convertTo2D(projpts);

        foreach (Vector3Int face in myModel.faces)
        {
            Vector2Int v1 = pixelPts[face.x];
            Vector2Int v2 = pixelPts[face.y];
            Vector2Int v3 = pixelPts[face.z];


            Draw(bresh(v1, v2));

            Draw(bresh(v2, v3));
            Draw(bresh(v3, v1));

        }
        screenGo.GetComponent<Renderer>().material.mainTexture = screen;
        screen.Apply();

    }

    private List<Vector2Int> convertTo2D(List<Vector4> projpts)
    {
      List<Vector2Int> hold = new List<Vector2Int>();

        foreach (Vector4 p in projpts) 

            hold.Add(new Vector2Int( Mathf.RoundToInt((p.x - 1)*1023/2) , Mathf.RoundToInt((p.y-1) * 1023/2   ) ));

         return hold;
    }
}
