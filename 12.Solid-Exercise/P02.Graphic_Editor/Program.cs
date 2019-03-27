using System;
using System.Collections.Generic;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            List<GraphicEditor> editors = new List<GraphicEditor>();
            CircleDrawer drawer = new CircleDrawer();

            editors.Add(drawer);

            foreach (var editor in editors)
            {
                editor.Draw();
            }
        }
    }
}
