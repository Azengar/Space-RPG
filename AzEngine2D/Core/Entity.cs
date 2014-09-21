using AzEngine2D.Core;
using AzEngine2D.Graphics;
using AzEngine2D.Rendering;
using AzEngine2D.States;
using AzEngine2D.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AzEngine2D
{
    public abstract class Entity : AzGameComponent, IUpdatable, IRenderable
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

        public virtual void Update(GameTime gameTime)
        {
            Sprites.Update(gameTime);
            if (State != null)
                State.Update(gameTime);
        }

    }
}
