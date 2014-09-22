using AzEngine2D.Core;
using AzEngine2D.Graphics;
using AzEngine2D.Rendering;
using AzEngine2D.States;
using AzEngine2D.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace AzEngine2D
{
    public abstract class Entity : AzGameComponent, IRenderable
    {
        public Vector2 Position { get; set; }
        public Dimension Dimension { get; set; }
        public SpriteGroup Sprites { get; set; }

        private State state;
        public State State 
        {
            get { return state; }
            set
            {
                if (state != null)
                {
                    state.Exit();
                    PreviousState = state;
                }

                state = value;
                state.Enter();
            }
        }

        public State PreviousState { get; private set; }

        public float Speed { get; set; }

        private float rotation = 0.0f;
        public float Rotation 
        { 
            get { return rotation; } 
            set
            {
                rotation = value;
                Sprites.Rotation = value;
            }
        }

        private float scale = 1.0f;
        public float Scale 
        {
            get { return scale; }
            set 
            { 
                scale = value;
                Sprites.Scale = value;
            }
        }

        public Entity ()
        {
            Position = Vector2.Zero;
            Dimension = Dimension.Zero;
            Sprites = new SpriteGroup(this);
        }

        public Entity(Vector2 position)
        {
            Position = position;
            Dimension = Dimension.Zero;
            Sprites = new SpriteGroup(this);
        }

        public Entity(Dimension dimension)
        {
            Position = Vector2.Zero;
            Dimension = dimension;
            Sprites = new SpriteGroup(this);
        }

        public Entity(Vector2 position, Dimension dimension)
        {
            Position = position;
            Dimension = dimension;
            Sprites = new SpriteGroup(this);
        }

        public Entity (Vector2 position, Dimension dimension, SpriteGroup sprites)
        {
            Position = position;
            Dimension = dimension;
            Sprites = sprites;
        }

        public virtual void Render(SpriteBatch spriteBatch)
        {
            Sprites.Animate(spriteBatch);
        }

        public bool CollidesWith (Entity other, bool pixelPerfect = false)
        {
            Rectangle thisRect = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Dimension.Width, this.Dimension.Height);
            Rectangle otherRect = new Rectangle((int)other.Position.X, (int)other.Position.Y, other.Dimension.Width, other.Dimension.Height);
            if (!thisRect.Intersects(otherRect))
            {
                if (pixelPerfect)
                    return collidesWithPerfect(this.Sprites, other.Sprites);
                else
                    return false;
            }
            else
                return true;
        }

        private bool collidesWithPerfect (SpriteGroup a, SpriteGroup b)
        {
            foreach (Sprite spriteA in a.Get())
            {
                foreach (Sprite spriteB in b.Get())
                {
                    if (PerPixelCollision(spriteA, spriteB))
                        return true;
                }
            }

            return false;
        }


        static bool PerPixelCollision(Sprite a, Sprite b)
        {
            // Get Color data of each Texture
            Color[] bitsA = new Color[a.ActualTexture.Width * a.ActualTexture.Height];
            a.ActualTexture.GetData(bitsA);
            Color[] bitsB = new Color[b.ActualTexture.Width * b.ActualTexture.Height];
            b.ActualTexture.GetData(bitsB);

            // Calculate the intersecting rectangle
            int x1 = Math.Max(a.ActualBounds.X, b.ActualBounds.X);
            int x2 = Math.Min(a.ActualBounds.X + a.ActualBounds.Width, b.ActualBounds.X + b.ActualBounds.Width);

            int y1 = Math.Max(a.ActualBounds.Y, b.ActualBounds.Y);
            int y2 = Math.Min(a.ActualBounds.Y + a.ActualBounds.Height, b.ActualBounds.Y + b.ActualBounds.Height);

            // For each single pixel in the intersecting rectangle
            for (int y = y1; y < y2; ++y)
            {
                for (int x = x1; x < x2; ++x)
                {
                    // Get the color from each texture
                    Color aColor = bitsA[(x - a.ActualBounds.X) + (y - a.ActualBounds.Y) * a.ActualTexture.Width];
                    Color bColor = bitsB[(x - b.ActualBounds.X) + (y - b.ActualBounds.Y) * b.ActualTexture.Width];

                    if (aColor.A != 0 && bColor.A != 0) // If both colors are not transparent (the alpha channel is not 0), then there is a collision
                    {
                        return true;
                    }
                }
            }
            // If no collision occurred by now, we're clear.
            return false;
        }

        public override void Update(GameTime gameTime)
        {
            Sprites.Update(gameTime);
            if (State != null)
                State.Update(gameTime);
        }

    }
}
