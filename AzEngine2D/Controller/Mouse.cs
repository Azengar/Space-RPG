using AzEngine2D.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzEngine2D.Controller
{
    public class Mouse : AzGameComponent
    {
        public Vector2 Position
        {
            get
            {
                MouseState mouse = Microsoft.Xna.Framework.Input.Mouse.GetState();
                return new Vector2(mouse.X, mouse.Y);
            }
        }

        public Mouse ()
        {

        }

        public float GetRotationViaCursor (Vector2 position)
        {
            Vector2 mousePosition = AzGame.Instance.ToWorldCoordinates(Position);
            Vector2 direction = mousePosition - position;
            direction.Normalize();

            return (float)Math.Atan2(direction.Y, direction.X) + ((float)Math.PI * 0.5f);
        }
    }
}
