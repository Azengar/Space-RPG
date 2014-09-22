using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzEngine2D.Core
{
   public abstract class AzGameComponent : IGameComponent
    {
        public virtual void Initialize() { }
        public virtual void LoadContent(ContentManager content) { }
        public virtual void UnLoadContent() { }

        public virtual void Update (GameTime gameTime) { }
    }
}
