using AzEngine2D;
using AzEngine2D.Core;
using AzEngine2D.Rendering;
using AzEngine2D.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace AzEngine2D.Camera
{
    public class EntityCenteredCamera : Camera
    {
        private Vector2 _position;

        #region Properties

        public override Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public Entity Target { get; set; }

        #endregion

        public EntityCenteredCamera (Dimension viewPort, Entity target)
            : base(viewPort)
        {
            Target = target;
        }

        /// <summary>
        /// Called when the GameComponent needs to be initialized. 
        /// </summary>
        public override void Initialize()
        {
            Scale = 1;

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            Position = Target.Position;
            Origin = ScreenCenter / Scale;

            // Create the Transform used by any
            // spritebatch process
            /*Transform = Matrix.Identity *
                        Matrix.CreateTranslation(-Position.X, -Position.Y, 0) *
                        Matrix.CreateRotationZ(Rotation) *
                        Matrix.CreateTranslation(Origin.X, Origin.Y, 0) *
                        Matrix.CreateScale(Scale);*/

            Vector2 translation = -Position + ScreenCenter;
            Transform = Matrix.CreateTranslation(translation.X, translation.Y, 0);

            // Move the Camera to the position that it needs to go
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

           // _position.X += (Target.Position.X - Position.X) * (2f) * delta;
           // _position.Y += (Target.Position.Y - Position.Y) * (2f) * delta;

        }
    }
}