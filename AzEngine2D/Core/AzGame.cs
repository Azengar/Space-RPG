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

        public List<AzGameComponent> GameObjects { get; set; }

        public List<IRenderable> WorldRenderables { get; set; }

        public List<IRenderable> FixedRenderables { get; set; }

        public IRenderer Renderer { get; set; }

        public AzGame ()
        {
            Instance = this;
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Renderer = new DefaultRenderer();
            KeyManager = new KeyManager();
            Mouse = new AzEngine2D.Controller.Mouse();
            GameObjects = new List<AzGameComponent>();
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

            foreach (AzGameComponent component in GameObjects)
            {
                component.Initialize();
            }
        }

        protected override void LoadContent()
        {
            foreach (AzGameComponent component in GameObjects)
            {
                component.LoadContent(Content);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            KeyManager.updateInput();
            Camera.Update(gameTime);

            foreach (AzGameComponent component in GameObjects)
            {
                component.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
    }
}
