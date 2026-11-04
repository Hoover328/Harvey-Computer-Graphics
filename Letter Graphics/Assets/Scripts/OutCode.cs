using UnityEngine;

public class OutCode
{
    public bool up;
    public bool down;
    public bool left;
    public bool right;

    //private Vector2 point;

    public OutCode(Vector2 point)
    {
        up = (point.y > 1);
        down = (point.y < -1);
        left = (point.x < -1);
        right = (point.x > 1);
    }

    public OutCode()
    {
        up =false;
        down=false;
        left=false;
        right=false;
    }

    public OutCode(bool up, bool down, bool left, bool right)
    {
        this.up = up;
        this.down = down;
        this.left = left;
        this.right = right;
    }

    public string displayOutcode()
    {
        return (up?"1":"0") + (down?"1":"0") + (left?"1":"0") + (right?"1":"0");
    }

    public static OutCode operator +(OutCode outCode1, OutCode outCode2) 
    {
        return new OutCode(outCode1.up || outCode2.up, outCode1.down || outCode2.down, outCode1.left || outCode2.left, outCode1.right || outCode2.right);
    }

    public static OutCode operator *(OutCode outCode1, OutCode outCode2)
    {
        return new OutCode(outCode1.up && outCode2.up, outCode1.down && outCode2.down, outCode1.left && outCode2.left, outCode1.right && outCode2.right);
    }

    public static bool operator ==(OutCode outCode1, OutCode outCode2)
    {
        return (outCode1.up == outCode2.up) && (outCode1.down == outCode2.down) && (outCode1.left == outCode2.left) && (outCode1.right == outCode2.right);
    }

    public static bool operator !=(OutCode outCode1, OutCode outCode2)
    {
        return (outCode1.up != outCode2.up) || (outCode1.down != outCode2.down) || (outCode1.left != outCode2.left) || (outCode1.right != outCode2.right);
    }

    public bool LineClip(ref Vector2 start, ref Vector2 end)
    {
        OutCode O_Start = new OutCode(start);
        OutCode O_End = new OutCode(end);
        OutCode inViewPort = new OutCode();

        if(O_Start + O_End == inViewPort)
        {
            return true;
        }

        if (O_Start * O_End != inViewPort)
        {
            return false;
        }

        if (O_Start == inViewPort)
        {
            return LineClip(ref end, ref start);
        }

        float m = GetM(ref start, ref end);

        if(O_Start.up == true)
        {
            Vector2 intersectionTop = new Vector2((start.x + (1 / m) * (1 - start.y)), 1);
            start = intersectionTop;

            LineClip(ref start, ref end);
        }

        if(O_Start.down == true)
        {
            Vector2 intersectionBottom = new Vector2((start.x + (1 / m) * (-1 - start.y)), -1);
            start = intersectionBottom;

            LineClip(ref start, ref end);
        }

        if (O_Start.left == true)
        {
            Vector2 intersectionLeft = new Vector2(-1, start.y + (m * (-1 - start.x)));
            start = intersectionLeft;

            LineClip(ref start, ref end);
        }

        if (O_Start.right == true)
        {
            Vector2 intersectionRight = new Vector2(1, start.y + (m * (1 - start.x)));
            start = intersectionRight;

            LineClip(ref start, ref end);

        }

        return false;

    }

    public static float GetM(ref Vector2 start, ref Vector2 end)
    {
        float m;
        if (start.x == end.x)
        {
            m = 1;
            return m;
        }

        if (start.y == end.y)
        {
            m = 1;
            return m;

        }

        else
        {
            m = (end.y - start.y) / (end.x - stadrt.x);
            return m;

        }
    }

}
