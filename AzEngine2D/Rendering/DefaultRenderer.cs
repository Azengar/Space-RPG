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
    public class DefaultRenderer : IRenderer
    {
        public DefaultRenderer() {}

        public void Render (IRenderable renderable, Vector2 onScreenPosition, Dimension onScreenDimension)
        {
            //renderable.Render(onScreenPosition, onScreenDimension);
        }
    }
}
