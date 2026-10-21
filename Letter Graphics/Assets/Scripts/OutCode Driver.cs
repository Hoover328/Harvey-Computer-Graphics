using UnityEngine;

public class OutCodeDriver : MonoBehaviour
{

    private void Start()
    {


        OutCode outCode1 = new OutCode(new Vector2(1.5f, 0.2f));
        OutCode outCode2 = new OutCode(new Vector2(-5f, -0.4f));

        string test = outCode1.displayOutcode();
        string test2 = outCode2.displayOutcode();

        OutCode or = outCode1 + outCode2;
        string test3 = or.displayOutcode();

        OutCode and = outCode1 * outCode2;
        string test4 = and.displayOutcode();

        bool isEqual = outCode1 == outCode2;
        string test5 = isEqual.ToString();



        print("OUTCODE TESTS################################");
        print(test);
        print(test2);
        print(test3);
        print(test4);
        print(test5);
    }
}
