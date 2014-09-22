using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzEngine2D.Core
{
    interface IGameComponent
    {
        void Initialize();
        void LoadContent(ContentManager content);
        void UnLoadContent();
        void Update(GameTime gameTime);
    }
}
