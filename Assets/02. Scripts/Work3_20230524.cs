using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Point
{
    public int _x, _y;

    public void Print()
    {
        Debug.Log($"{_x}, {_y}");
    }

    public Point()
    {
        _x = 0;
        _y = 0;
    }
    public Point(int initialx, int initialY)
    {
        _x = initialx;
        _y = initialY;
    }
    public Point(Point pt)
    {
        _x = pt._x;
        _y = pt._y;
    }

    public Point CreatePoint()
    {

        return new Point();
    }
}

public class NeedConstructor
{
    public const int maxCount = 100;
    public int reff;
    public int sample;

    public NeedConstructor()
    {
        reff = sample; 
    }

}

public class Work3_20230524 : MonoBehaviour
{
    Point p1;
    public void Area(Point pt)
    {
        int area = pt._x * pt._y;
        Debug.Log(area);
    }

    private void Start()
    {
        p1 = p1.CreatePoint();

        p1.Print();
        //p1._x = 100;
        //p1._y = 100;

        Area(p1);
    }
}



