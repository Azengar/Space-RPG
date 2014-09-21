using AzEngine2D.Core;
using AzEngine2D.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzEngine2D.Rendering
{
    public interface IRenderable
    {
        Vector2 Position { get; set; }
        Dimension Dimension { get; set; }
        float Scale { get; set; }
        float Rotation { get; set; }

        void Render(SpriteBatch spriteBatch);
    }
}
