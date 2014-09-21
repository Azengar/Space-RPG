using AzEngine2D;
using AzEngine2D.Core;
using AzEngine2D.Graphics;
using AzEngine2D.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Space_RPG.Entities.Ships.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Space_RPG.Entities.Ships
{
    public class Ship : Entity
    {
        public Sprite ShipSprite { get; set; }
        public Sprite ReactorStartSprite { get; set; }
        public Sprite ReactorSprite { get; set; }

        public float Acceleration { get; set; }

        public float RotationSpeed { get; set; }

        public float MaximumSpeed { get; set; }

        public bool IsStopped { get; set; }


        public List<Sprite> StoppedSprites { get; private set; }

        public List<Sprite> MovementSprites { get; private set; }

        public Ship (Vector2 position, Dimension dimension, float acceleration, float maximumSpeed, float rotationSpeed) 
            : base (position, dimension)
        {
            Acceleration = acceleration;
            RotationSpeed = rotationSpeed;
            MaximumSpeed = maximumSpeed;
            Speed = 0f;
            IsStopped = true;
        }

        public override void Initialize()
        {
            initSprites();

            State = new StoppedState(this);

            

 	        base.Initialize();
        }

        private void initSprites ()
        {
            StoppedSprites = new List<Sprite>()
            {
                ShipSprite, ReactorSprite
            };

            MovementSprites = new List<Sprite>()
            {
                ShipSprite, ReactorSprite
            };
        }

        public override void LoadContent(ContentManager content)
        {
            // Properties that are the same to all ships
            ReactorSprite.Loop = false;

            base.LoadContent(content);
        }

        public void Move (float delta)
        {
            IsStopped = false;
            Vector2 direction = Position - AzGame.Instance.ToWorldCoordinates(AzGame.Instance.Mouse.Position);
            direction.Normalize();

            Speed += Acceleration * delta;
            if (Speed > MaximumSpeed)
                Speed = MaximumSpeed;

            move(direction);
            Console.WriteLine(Speed);
        }

        private void move (Vector2 direction)
        {
            Position += -direction * Speed;
        }

        public void Slow (float delta)
        {
            Speed -= Acceleration * delta;

            Vector2 direction = Position - AzGame.Instance.ToWorldCoordinates(AzGame.Instance.Mouse.Position);
            direction.Normalize();

            move(direction);
            Console.WriteLine(Speed);

            if (Speed < 0f)
            {
                Speed = 0f;
                IsStopped = true;
            }
        }
    }
}
