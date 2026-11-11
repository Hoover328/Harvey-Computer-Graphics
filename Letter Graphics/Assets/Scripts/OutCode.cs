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

        Vector2 intersection = Intersect(ref start, ref end);

        if (float.IsNaN(intersection.x) || float.IsNaN(intersection.y))
        {
            float m = (end.y - start.y) / (end.x - start.x);

            if (O_Start.up == true)
            {
                intersection = new Vector2(start.x + (1f / m) * (1f - start.y), 1f);
            }

            if (O_Start.down == true)
            {
                intersection = new Vector2(start.x + (1f / m) * (-1f - start.y), -1f);
            }

            if (O_Start.left == true)
            {
                intersection = new Vector2(-1f, start.y + (m * (-1f - start.x)));

            }

            if (O_Start.right == true)
            {
                intersection = new Vector2(1f, start.y + (m * (1f - start.x)));
            }
        }
        start = intersection;
        return LineClip(ref start, ref end);
    }

    public static Vector2 Intersect(ref Vector2 start, ref Vector2 end)
    {
        OutCode O_Start = new OutCode(start);
        OutCode O_End = new OutCode(end);

        if (start.x == end.x)
        {
            if(O_Start.displayOutcode() == "1000")
            {
                return new Vector2(start.x, 1);
            }

            else if (O_End.displayOutcode() == "1000")
            {
                return new Vector2(start.x, 1);
            }

            if (O_Start.displayOutcode() == "0100")
            {
                return new Vector2(start.x, -1);
            }

            else if (O_End.displayOutcode() == "0100")
            {
                return new Vector2(start.x, -1);
            }
        }

        if(start.y == end.y)
        {
            if (O_Start.displayOutcode() == "0010")
            {
                return new Vector2(-1, start.y);
            }

            else if (O_End.displayOutcode() == "0010")
            {
                return new Vector2(-1, start.y);
            }

            if (O_Start.displayOutcode() == "0001")
            {
                return new Vector2(1, start.y);
            }

            else if (O_End.displayOutcode() == "0001")
            {
                return new Vector2(1, start.y);
            }
        }
        return new Vector2(float.NaN, float.NaN);
    }

}
