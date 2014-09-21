using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzEngine2D.States
{
    class GameState : IGameState
    {

        public GameState() { }

        public virtual void Update(GameTime gameTime) { }

        public virtual void Render(SpriteBatch spriteBatch) { }
    }
}
