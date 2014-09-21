using AzEngine2D;
using AzEngine2D.Core;
using Microsoft.Xna.Framework.Input;
using System;
using Space_RPG.Entities.Ships.Player;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using AzEngine2D.Graphics;
using Microsoft.Xna.Framework;

namespace Space_RPG.Entities.Ships.States
{
    class StoppedState : ShipState
    {

        public StoppedState(Ship ship) : base(ship) { }

        public override void HandleInput(Keys key, bool pressed)
        {
            if (pressed)
            {
                if (key == Player.Player.MOVE)
                    Ship.State = new MoveState(Ship);
            }
            else

            base.HandleInput(key, pressed);
        }

        public override void Enter()
        {
            Ship.ReactorSprite.Reset();

            if (Ship.PreviousState is MoveState)
            {
                Ship.ReactorSprite.Loop = false;
                Ship.ReactorSprite.Reverse = true;
            }
            else
            {
                ReactorSlow();
            }
            

            Ship.Sprites.Set(Ship.StoppedSprites);
            base.Enter();
        }

        private void ReactorSlow ()
        {
            Ship.ReactorSprite.Reset();
            Ship.ReactorSprite.MaxFrame = 1;
            Ship.ReactorSprite.MinFrame = 0;
        }

        public override void Update(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (!Ship.IsStopped)
                Ship.Slow(delta);

            if (Ship.ReactorSprite.isFinished)
                ReactorSlow();

            base.Update(gameTime);
        }

        /*public override void Update(Entity entity);
        public override void enter(Entity entity);
        public override void exit(Entity entity);*/
    }
}
