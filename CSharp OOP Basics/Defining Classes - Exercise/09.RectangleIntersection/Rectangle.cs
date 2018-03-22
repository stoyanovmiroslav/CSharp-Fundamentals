using System;
using System.Collections.Generic;
using System.Text;

class Rectangle
{
    private string id;
    private int width;
    private int height;
    private double x;
    private double y;

    public Rectangle(string id, int width, int height, double x, double y)
    {
        this.id = id;
        this.width = width;
        this.height = height;
        this.x = x;
        this.y = y;
    }

    public double Y
    {
        get { return y; }
        set { y = value; }
    }

    public double X
    {
        get { return x; }
        set { x = value; }
    }

    public int Height
    {
        get { return height; }
        set { height = value; }
    }

    public int Width
    {
        get { return width; }
        set { width = value; }
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
}

