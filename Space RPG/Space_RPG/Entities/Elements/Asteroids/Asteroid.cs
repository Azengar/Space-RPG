using AzEngine2D;
using AzEngine2D.Core;
using AzEngine2D.Graphics;
using AzEngine2D.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Space_RPG.Entities.Elements.Asteroids
{
    public class Asteroid : Entity
    {
        public static readonly Rectangle ASTEROID_1 = new Rectangle(0, 0, 36, 36);
        public static readonly Rectangle ASTEROID_2 = new Rectangle(36, 0, 68, 68);
        public static readonly Rectangle ASTEROID_3 = new Rectangle(104, 0, 132, 132);

        public static readonly Rectangle[] ASTEROIDS = new Rectangle[] { ASTEROID_1, ASTEROID_2, ASTEROID_3 };

        const float MAX_SPEED = 2.0f;
        const float MIN_SPEED = 0.5f;

        const float ROTATION = 0.01f;

        private AzRandom rand = new AzRandom();

        private Texture2D asteroids;
        private Rectangle sourceRect;

        public Vector2 Direction { get; set; }

        public Asteroid ()
        {
            sourceRect = genRandAsteroid();
            Position = genRandPosition();
            Direction = genRandDirection();
            Speed = 1f;
        }

        public Asteroid (Rectangle sourceRect, Vector2 position, Vector2 direction, float speed)
        {
            Scale = 2.0f;
            this.sourceRect = sourceRect;
            Position = position;
            Direction = direction;
            Speed = speed;
        }

        public Asteroid (Vector2 position, float speed, float rotation)
        {
            Scale = 2.0f;

            sourceRect = genRandAsteroid();

            Position = position;
            Speed = speed;
            Rotation = rotation;

            sourceRect = genRandAsteroid();
            Direction = genRandDirection();
        }

        public override void LoadContent(ContentManager content)
        {
            Scale = 2.0f;
            asteroids = content.Load<Texture2D>(@"Test\asteroids");
            createSprite(sourceRect);
            base.LoadContent(content);
        }

        private void createSprite (Rectangle sourceRect)
        {
            Texture2D asteroid = new Texture2D(AzGame.Instance.GraphicsDevice, sourceRect.Width, sourceRect.Height);
            Color[] data = new Color[sourceRect.Width * sourceRect.Height];
            asteroids.GetData(0, sourceRect, data, 0, data.Length);
            asteroid.SetData(data);

            Dimension = new Dimension(asteroid.Width, asteroid.Height);
            Sprites.Add(new Sprite(asteroid), Vector2.Zero);
        }

        public override void Update(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Rotation += ROTATION;

            Position += -Direction * Speed;
            base.Update(gameTime);
        }

        private Rectangle genRandAsteroid ()
        {
            return ASTEROIDS[rand.Next(ASTEROIDS.Length)];
        }

        private Vector2 genRandDirection ()
        {
            return new Vector2((float)rand.NextDouble(), (float)rand.NextDouble());
        }

        private Vector2 genRandPosition ()
        {
            return new Vector2(1100, 1100);
        }
    }
}
