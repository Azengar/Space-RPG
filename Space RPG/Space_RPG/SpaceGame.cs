using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using AzEngine2D.Core;
using AzEngine2D.Camera;
using AzEngine2D.Graphics;
using Space_RPG.Entities.Ships.Player;
using AzEngine2D.Utils;
using Space_RPG.Entities.Elements.Asteroids;

namespace Space_RPG
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class SpaceGame : AzGame
    {
        // Le spriteBatch c'est le bien
        SpriteBatch spriteBatch;

        Player player;

        AsteroidsField AsteroidsField { get; set; }

        List<Asteroid> Asteroids { get; set; }

        public SpaceGame() : base ()
        {
            Content.RootDirectory = "Content";
            Asteroids = new List<Asteroid>();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            SetResolution(new Dimension(1280, 720));

            base.Initialize();
        }

        public override void HandleInput(Keys key, bool pressed)
        {
            player.HandleInput(key, pressed);
            base.HandleInput(key, pressed);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            cacheTextures();
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player = new Player(new Vector2(1000, 1000), new Dimension(64, 64));

            AsteroidsField = new AsteroidsField(new Rectangle(0, 0, 4000, 4000));
            AsteroidsField.LoadContent(Content);

            GameObjects.Add(player);
            GameObjects.Add(AsteroidsField);

            Camera = new EntityCenteredCamera(GetResolution(), player);

            // TODO: use this.Content to load your game content here
            base.LoadContent();
        }

        private void cacheTextures ()
        {
            Content.Load<Texture2D>(@"Test\asteroids");
            Content.Load<Texture2D>(@"Test\reactor");
            Content.Load<Texture2D>(@"Test\reactorStart");
            Content.Load<Texture2D>(@"Test\ship");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            base.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            AsteroidsField.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(0, 0, 20));

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, Camera.Transform);

            player.Render(spriteBatch);
            AsteroidsField.Render(spriteBatch);

            spriteBatch.End();

        }
    }
}
