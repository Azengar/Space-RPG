using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzEngine2D.States
{
    interface IGameState
    {
        void Render(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
