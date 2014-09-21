using AzEngine2D.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzEngine2D.Graphics
{
    public class SpriteGroup : AzGameComponent, IUpdatable
    {
        public Entity Entity { get; set; }
        public float Scale { get; set; }
        public float Rotation { get; set; }

        private List<Sprite> sprites;

        public SpriteGroup (Entity entity)
        {
            sprites = new List<Sprite>();

            Entity = entity;
            Scale = 1.0f;
            Rotation = 0.0f;
        }

        public SpriteGroup(Entity entity, float scale, float rotation)
        {
            sprites = new List<Sprite>();

            Entity = entity;
            Scale = scale;
            Rotation = rotation;
        }

        public override void Initialize() { }

        public void Update (GameTime gameTime)
        {
            foreach (Sprite sprite in sprites)
            {
                sprite.Update(gameTime);
            }
        }

        public void Animate (SpriteBatch spriteBatch)
        {
            foreach (Sprite sprite in sprites)
            {
                sprite.Animate(spriteBatch, Entity.Position, Rotation, Scale);
            }
        }

        private Vector2 calculateOrigin (Vector2 spritePos)
        {
            Vector2 groupCenter = new Vector2(Entity.Position.X + Entity.Dimension.Width / 2, Entity.Position.Y + Entity.Dimension.Height / 2);
            return groupCenter - (spritePos + Entity.Position);
        }

        public void Add(Sprite sprite, Vector2 position)
        {
            sprite.Origin = calculateOrigin(position);
            sprites.Add(sprite);
        }

        public void Remove(Sprite sprite)
        {
            sprites.Remove(sprite);
        }

        public List<Sprite> Get ()
        {
            return sprites;
        }

        public void Set (List<Sprite> sprites)
        {
            this.sprites = sprites;
            foreach (Sprite sprite in sprites)
            {
                sprite.Origin = calculateOrigin(sprite.Position);
            }
        }

        public bool Contains (Sprite sprite)
        {
            return sprites.Contains(sprite);
        }
    }
}
