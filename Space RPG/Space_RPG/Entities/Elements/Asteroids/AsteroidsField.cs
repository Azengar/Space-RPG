using AzEngine2D.Core;
using AzEngine2D.Rendering;
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
    public class AsteroidsField : AzGameComponent, IUpdatable
    {


        public List<Asteroid> Asteroids { get; set; }

        public Rectangle Boundary {get; set;}

        public float Density { get; set; }

        public float MaxSpeed { get; set; }

        public float MinSpeed { get; set; }

        private AzRandom rand;

        public AsteroidsField (Rectangle boundary, float density = 1f, float minAsteroidsSpeed = 0.1f, float maxAsteroidsSpeed = 0.3f)
        {
            Asteroids = new List<Asteroid>();

            Boundary = boundary;
            Density = density;

            MinSpeed = minAsteroidsSpeed;
            MaxSpeed = maxAsteroidsSpeed;

            rand = new AzRandom();

            fillField();
        }

        private void fillField ()
        {
            int i = (int)(((Boundary.Width + Boundary.Height) / 2) / (20 * Density));
            do
            {
                Vector2 asteroidPos = new Vector2(rand.Next(Boundary.X, Boundary.X + Boundary.Width), rand.Next(Boundary.Y,Boundary.Y + Boundary.Height));
                float asteroidSpeed = rand.NextFloat(MinSpeed, MaxSpeed);
                float asteroidRotation = 0.025f;
                Asteroids.Add(new Asteroid(asteroidPos, asteroidSpeed, asteroidRotation));
            }
            while (--i > 0);

        }

        public override void Initialize()
        {
            foreach (Asteroid asteroid in Asteroids)
            {
                asteroid.Initialize();
            }
            base.Initialize();
        }

        public override void LoadContent(ContentManager content)
        {
            foreach (Asteroid asteroid in Asteroids)
            {
                asteroid.LoadContent(content);
            }
            base.LoadContent(content);
        }

        public void Update (GameTime gameTime)
        {
            foreach (Asteroid asteroid in Asteroids)
            {
                asteroid.Update(gameTime);
            }
        }

        public void Render (SpriteBatch spriteBatch)
        {
            foreach (Asteroid asteroid in Asteroids)
            {
                asteroid.Render(spriteBatch);
            }
        }
    }
}
