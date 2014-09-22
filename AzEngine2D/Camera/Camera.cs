using AzEngine2D.Core;
using AzEngine2D.Rendering;
using AzEngine2D.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzEngine2D.Camera
{
    public abstract class Camera : AzGameComponent, ICamera
    {
        public virtual Vector2 Position { get; set; }
        public Dimension ViewPort { get; set; }
        public float Scale { get; set; }
        public float Rotation { get; set; }
        public Vector2 Origin { get; protected set; }
        public Vector2 ScreenCenter { get; protected set; }
        public Matrix Transform { get; protected set; }

        public Camera (Dimension viewPort)
        {
            ViewPort = viewPort;
        }

        public override void Initialize()
        {
            ScreenCenter = new Vector2(ViewPort.Width / 2, ViewPort.Height / 2);
        }

        public bool IsInView(Vector2 position, Texture2D texture)
        {
            // If the object is not within the horizontal bounds of the screen

            if ((position.X + texture.Width) < (Position.X - Origin.X) || (position.X) > (Position.X + Origin.X))
                return false;

            // If the object is not within the vertical bounds of the screen
            if ((position.Y + texture.Height) < (Position.Y - Origin.Y) || (position.Y) > (Position.Y + Origin.Y))
                return false;

            // In View
            return true;
        }
    }
}
