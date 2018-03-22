using System;
using System.Collections.Generic;
using System.Text;


class Rectangle
{
    public Point TopLeft { get; set; }
    public Point BottomRight { get; set; }

    public Rectangle(Point topLeft, Point bottomRight)
    {
        TopLeft = topLeft;
        BottomRight = bottomRight;
    }

    public bool Contains(Point point)
    {
        return point.X >= TopLeft.X && point.X <= BottomRight.X &&
               point.Y >= TopLeft.Y && point.Y <= BottomRight.Y;
    }
}

