using AzEngine2D;
using AzEngine2D.Core;
using AzEngine2D.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Space_RPG.Entities.Ships.States
{
    class MoveState : ShipState
    {

        public MoveState(Ship ship) : base(ship) { }

        public bool keyPressed = false;

        public override void HandleInput(Keys key, bool pressed)
        {
            if (pressed)
            {
                if (key == Player.Player.MOVE)
                    keyPressed = true;
            }
            else
            {
                keyPressed = false;
                Ship.State = new StoppedState(Ship);
            }

            base.HandleInput(key, pressed);
        }

        public override void Update(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyPressed)
                Ship.Move(delta);

            if (Ship.ReactorSprite.isFinished)
            {
                Ship.ReactorSprite.MinFrame = 2;
                Ship.ReactorSprite.MaxFrame = 3;
                Ship.ReactorSprite.Restart(3);
                Ship.ReactorSprite.Loop = true;
            }
        }

        public override void Enter()
        {
            Ship.ReactorSprite.Reset();
            Ship.ReactorSprite.MaxFrame = Ship.ReactorSprite.OriginalMaxFrame;
            Ship.ReactorSprite.MinFrame = Ship.ReactorSprite.OriginalMinFrame;
            Ship.ReactorSprite.Loop = false;

            Ship.Sprites.Set(Ship.MovementSprites);
        }

        public override void Exit()
        {

        }
    }
}
