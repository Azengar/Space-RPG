using AzEngine2D.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzEngine2D.Graphics
{
    public class Sprite
    {
        public const int DEFAULT_MS_PER_FRAME = 100;

        private int actualFrame;
        public int ActualFrame
        {
            get { return actualFrame; }
            set
            {
                if (value < maxFrame && value > -1)
                    actualFrame = value;

                if (Reverse)
                {
                    if (value == (MinFrame - 1))
                    {
                        if (Loop)
                            actualFrame = MaxFrame;
                        else
                        {
                            isFinished = true;
                            ActualFrame++;
                        }
                    }
                }
                else
                {
                    if (value == (MaxFrame + 1))
                    {
                        if (Loop)
                            actualFrame = MinFrame;
                        else
                        {
                            isFinished = true;
                        }
                    }
                }
            }
        }

        public int OriginalMaxFrame { get { return (maxFrame - 1); } }
        public int OriginalMinFrame { get { return 0; } }

        public Vector2 Position { get; set; }

        public int MaxFrame { get; set; }
        public int MinFrame { get; set; }

        public bool Loop { get; set; }
        public bool Reverse { get; set; }
        public bool isFinished { get; set; }
        public Vector2 Origin { get; set; }

        private Texture2D sprites;
        private Rectangle[] frames;
        private int maxFrame;

        private int msSinceLastFrame = 0;
        private int msPerFrame = DEFAULT_MS_PER_FRAME;

        private bool uniqueTexture = false;

        #region Constructors
        public Sprite (Texture2D uniqueTexture)
        {
            sprites = uniqueTexture;
            maxFrame = 1;
            frames = new Rectangle[] { new Rectangle(0, 0, sprites.Width, sprites.Height) };
            this.uniqueTexture = true;
            initDefault();
            Restart();
        }

        public Sprite(Texture2D uniqueTexture, Vector2 position)
        {
            maxFrame = 1;
            Position = position;
            sprites = uniqueTexture;
            frames = new Rectangle[] { new Rectangle(0, 0, sprites.Width, sprites.Height) };
            this.uniqueTexture = true;
            initDefault();
            Restart();
        }

        public Sprite(Texture2D sprites, int framesNb)
        {
            this.sprites = sprites;
            int width = sprites.Width / framesNb;

            frames = new Rectangle[framesNb];
            for (int i = 0; i < framesNb; i++)
                frames[i] = new Rectangle(i * width, 0, width, sprites.Height);

            maxFrame = frames.Length;

            initDefault();
            Restart();
        }

        public Sprite(Texture2D sprites, int framesNb, Vector2 position)
        {
            Position = position;
            this.sprites = sprites;
            int width = sprites.Width / framesNb;

            frames = new Rectangle[framesNb];
            for (int i = 0; i < framesNb; i++)
                frames[i] = new Rectangle(i * width, 0, width, sprites.Height);

            maxFrame = frames.Length;

            initDefault();
            Restart();
        }

        public Sprite(Texture2D sprites, Rectangle[] separations)
        {
            this.sprites = sprites;
            this.frames = separations;
            maxFrame = separations.Length;
            initDefault();
            Restart();
        }

        public Sprite(Texture2D sprites, Rectangle[] separations, Vector2 position)
        {
            Position = position;
            this.sprites = sprites;
            this.frames = separations;
            maxFrame = separations.Length;
            initDefault();
            Restart();
        }
        #endregion

        private void initDefault ()
        {
            MaxFrame = (maxFrame - 1);
            MinFrame = 0;
            Loop = true;
            Reverse = false;
            isFinished = false;
        }

        public void Reset ()
        {
            initDefault();
        }

        public void Update (GameTime gameTime)
        {
            if (uniqueTexture)
                return;

            msSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (msSinceLastFrame > msPerFrame)
            {
                msSinceLastFrame -= msPerFrame;
                if (Reverse)
                    ActualFrame--;
                else
                    ActualFrame++;
            }
        }

        public void Restart (int actualFrame = -1)
        {
            isFinished = false;
            if (actualFrame == -1)
                ActualFrame = MinFrame;
            else
                ActualFrame = actualFrame;
        }

        public void Animate (SpriteBatch spriteBatch, Vector2 position, float rotation, float scale)
        {
            spriteBatch.Draw(sprites, position, frames[ActualFrame], Color.White, rotation, Origin, scale, SpriteEffects.None,0f);
        }
    }
}
