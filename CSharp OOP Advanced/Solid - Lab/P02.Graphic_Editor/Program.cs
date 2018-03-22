using System;

namespace P02.Graphic_Editor
{
    public class Program
    {
        public static void Main()
        {
            GraphicEditor graphicEditor = new GraphicEditor();
            Circle circle = new Circle();
            graphicEditor.DrawShape(circle);
        }
    }
}
