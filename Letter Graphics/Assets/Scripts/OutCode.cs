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
        return (outCode1.up != outCode2.up) && (outCode1.down != outCode2.down) && (outCode1.left != outCode2.left) && (outCode1.right != outCode2.right);
    }


}
