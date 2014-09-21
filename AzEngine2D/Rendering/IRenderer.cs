using AzEngine2D.Core;
using AzEngine2D.Utils;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzEngine2D.Rendering
{
    public interface IRenderer
    {
        void Render(IRenderable renderable, Vector2 onScreenPosition, Dimension onScreenDimension);
    }
}
