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
        void Render(SpriteBatch spriteBatch);
    }
}
