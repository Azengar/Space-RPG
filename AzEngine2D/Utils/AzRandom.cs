using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzEngine2D.Utils
{
    public class AzRandom : Random
    {

        public AzRandom() : base() { }

        public float NextFloat(float min, float max)
        {
            return (float)this.NextDouble() * (max - min) + min; 
        }
    }
}
