using AzEngine2D;
using AzEngine2D.Core;
using AzEngine2D.Graphics;
using AzEngine2D.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Space_RPG.Entities.Ships.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Space_RPG.Entities.Ships.Player
{
    class Player : Ship
    {
        #region ship parts
        public static readonly Vector2 SHIP_POSITION = Vector2.Zero;
        public static readonly Vector2 REACTOR_POSITION = new Vector2(26, 64);
        #endregion

        #region controls
        public static readonly Keys MOVE = Keys.W;
        #endregion

        public static readonly float MAX_SPEED = 10f;

        public static float ACCELERATION = 10f;
        public static float ROTATION_SPEED = 0.1f;
        

        public Player(Vector2 position, Dimension dimension)
            : base(position, dimension, ACCELERATION, MAX_SPEED, ROTATION_SPEED)
        {
        }

        public override void Initialize()
        {
            AzGame.Instance.KeyManager.ListenedKeys.Add(MOVE);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (AzGame.Instance.IsActive)
            {
                
                /*float newRotation = AzGame.Instance.Mouse.GetRotationViaCursor(Position);

                Rotation += MathHelper.Clamp((newRotation - Rotation), -RotationSpeed, RotationSpeed);*/
                Rotation = AzGame.Instance.Mouse.GetRotationViaCursor(Position);
                //Rotation = newRotation;
            }

            base.Update(gameTime);
        }

        private Vector2 getReactorPosition ()
        {
            Vector2 reactorRealPosition = AzGame.Instance.ToWorldCoordinates(Vector2.Zero);
            return Position - reactorRealPosition + REACTOR_POSITION;
        }

        public override void LoadContent(ContentManager content)
        {
            Scale = 2.0f;
            buildSprites(content);
            base.LoadContent(content);
        }

        private void buildSprites (ContentManager content)
        {
            Texture2D shipTex = content.Load<Texture2D>(@"Test\ship");
            Texture2D reactorTex = content.Load<Texture2D>(@"test\reactor");
            Texture2D reactorStartTex = content.Load<Texture2D>(@"test\reactorStart");

            ShipSprite = new Sprite(shipTex, SHIP_POSITION);
            ReactorSprite = new Sprite(reactorTex, 5, REACTOR_POSITION);
            ReactorStartSprite = new Sprite(reactorStartTex, 2, REACTOR_POSITION);

            //reactor = new Sprite(reactorTex, 5);
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            base.Render(spriteBatch);
        }

        public void HandleInput (Keys key, bool pressed)
        {
            State.HandleInput(key, pressed);
        }
    }
}
