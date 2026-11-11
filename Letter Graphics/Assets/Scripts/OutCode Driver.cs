using NUnit.Framework.Internal;
using UnityEngine;

public class OutCodeDriver : MonoBehaviour
{

    private void Start()
    {
        Vector2 point1 = new Vector2(0f, -2f);
        Vector2 point2 = new Vector2(0f, 2f);

        Vector2 point3 = new Vector2(-2f, -2f);
        Vector2 point4 = new Vector2(2f, 2f);

        Vector2 point5 = new Vector2(-0.5f, -0.5f);
        Vector2 point6 = new Vector2(0.5f, 0.5f);

        Vector2 point7 = new Vector2(-2f, 2f);
        Vector2 point8 = new Vector2(-1.5f, 2.5f);

        Vector2 point9 = new Vector2(0.5f, -2f);
        Vector2 point10 = new Vector2(0.5f, 2f);

        Vector2 point11 = new Vector2(-2f, 0.5f);
        Vector2 point12 = new Vector2(2f, 0.5f);



        OutCode outCode1 = new OutCode(new Vector2(0f, -2f));   // "0100" (down)
        OutCode outCode2 = new OutCode(new Vector2(0f, 2f));    // "1000" (up)

        OutCode outCode3 = new OutCode(new Vector2(-2f, -2f)); // "0110" (down, left)
        OutCode outCode4 = new OutCode(new Vector2(2f, 2f));    // "1001" (up, right)

        OutCode outCode5 = new OutCode(new Vector2(-0.5f, -0.5f)); // "0000" (inside)
        OutCode outCode6 = new OutCode(new Vector2(0.5f, 0.5f));  // "0000" (inside)

        OutCode outCode7 = new OutCode(new Vector2(-2f, 2f));   // "1010" (up, left)
        OutCode outCode8 = new OutCode(new Vector2(-1.5f, 2.5f)); // "1010" (up, left)

        OutCode outCode9 = new OutCode(new Vector2(0.5f, -2f));  // "0100" (down)
        OutCode outCode10 = new OutCode(new Vector2(0.5f, 2f));  // "1000" (up)

        OutCode outCode11 = new OutCode(new Vector2(-2f, 0.5f)); // "0010" (left)
        OutCode outCode12 = new OutCode(new Vector2(2f, 0.5f));  // "0001" (right)

        string test = outCode1.displayOutcode();
        string test2 = outCode2.displayOutcode();

        OutCode or = outCode1 + outCode2;
        string test3 = or.displayOutcode();

        OutCode and = outCode1 * outCode2;
        string test4 = and.displayOutcode();

        bool isEqual = outCode1 == outCode2;
        string test5 = isEqual.ToString();

        bool test6 = outCode1.LineClip(ref point1, ref point2);
        bool test7 = outCode1.LineClip(ref point3, ref point4);
        bool test8 = outCode1.LineClip(ref point5, ref point6);
        bool test9 = outCode1.LineClip(ref point7, ref point8);
        bool test10 = outCode1.LineClip(ref point9, ref point10);
        bool test11 = outCode1.LineClip(ref point11, ref point12);



        print("OUTCODE TESTS################################");
        print(test);
        print(test2);
        print(test3);
        print(test4);
        print(test5);
        print("LINECLIPPING TESTS################################");
        print("Vertical line (point1 to point2): " + test6);
        print("Diagonal line (point3 to point4): " + test7);
        print("Inside viewport (point5 to point6): " + test8);
        print("Outside viewport (point7 to point8): " + test9);
        print("Vertical line (point9 to point10): " + test10);
        print("Horizontal line (point11 to point12): " + test11);


    }
}
