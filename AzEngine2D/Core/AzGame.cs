using AzEngine2D.Camera;
using AzEngine2D.Controller;
using AzEngine2D.Rendering;
using AzEngine2D.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzEngine2D.Core
{
    public class AzGame : Microsoft.Xna.Framework.Game, IKeyHandler
    {
        private static AzGame instance;
        public static AzGame Instance 
        {
            get 
            {
                if (instance == null)
                    instance = new AzGame();

                return instance;
            }
            set { instance = value; }
        }

        public Camera.Camera Camera { get; set; }
        public KeyManager KeyManager { get; set; }
        public AzEngine2D.Controller.Mouse Mouse { get; set; }

        public GraphicsDeviceManager GraphicsDeviceManager;

        public List<Entity> Entities { get; set; }

        private IRenderer renderer;

        public AzGame ()
        {
            Instance = this;
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            renderer = new DefaultRenderer();
            KeyManager = new KeyManager();
            Mouse = new AzEngine2D.Controller.Mouse();
            Entities = new List<Entity>();
        }

        public Dimension GetResolution()
        {
            return new Dimension(
                GraphicsDeviceManager.PreferredBackBufferWidth,
                GraphicsDeviceManager.PreferredBackBufferHeight);
        }

        public void SetResolution(Dimension resolution, bool fullscreen = false)
        {
            GraphicsDeviceManager.IsFullScreen = fullscreen;
            GraphicsDeviceManager.PreferredBackBufferWidth = resolution.Width;
            GraphicsDeviceManager.PreferredBackBufferHeight = resolution.Height;
            GraphicsDeviceManager.ApplyChanges();
        }

        public Vector2 ToWorldCoordinates (Vector2 position)
        {
            return new Vector2((Camera.Position.X - Camera.ViewPort.Width/2) + position.X, (Camera.Position.Y - Camera.ViewPort.Height/2) + position.Y);
        }

        public virtual void HandleInput(Keys key, bool pressed) { }

        protected override void Initialize()
        {
            base.Initialize();

            KeyManager.Initialize();
            Camera.Initialize();

            foreach (Entity e in Entities)
            {
                e.Initialize();
            }
        }

        protected override void LoadContent()
        {
            foreach (Entity e in Entities)
            {
                e.LoadContent(Content);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            KeyManager.updateInput();
            Camera.Update(gameTime);

            foreach (Entity e in Entities)
            {
                e.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected void RenderWorld (SpriteBatch spriteBatch)
        {
            foreach (Entity e in Entities)
            {
                e.Render(spriteBatch);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            if (Camera == null)
            {
                Console.WriteLine("Camera not set ! Please set one in your basegame class with this.Camera in order to draw");
                return;
            }

            foreach (Entity e in Entities)
            {
                //e.Render(SpriteBatch);
            }

            /*foreach (IRenderable renderable in Entities)
            {
                renderable.Render(renderable.Position, renderable.Dimension);
            }*/

            //Camera.RenderView(renderer, Entities.Cast<IRenderable>().ToList());
            base.Draw(gameTime);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
    }
}
