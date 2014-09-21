using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzEngine2D.States
{
    public interface IState
    {
        void HandleInput(Keys key, bool pressed);
        void Update(GameTime gameTime);
        void Enter();
        void Exit();
    }
}
