using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzEngine2D.Utils
{
    public class Dimension
    {
        public static readonly Dimension Zero = new Dimension(0, 0);

        public int Width { get; set; }
        public int Height { get; set; }

        public Dimension ()
        {
            Width = 0;
            Height = 0;
        }

        public Dimension(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
