using AzEngine2D.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzEngine2D.States
{
    public abstract class State : AzGameComponent, IState
    {

        public State () {}

        public virtual void HandleInput(Keys key, bool pressed) { }
        public virtual void Enter() { }
        public virtual void Exit() { }

    }
}
