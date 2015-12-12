using System;
using System.Collections.Generic;
using Game1.Enemy;
using Game1.GUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        Level level = new Level();
        WaveManager waveManager;
        Player.Player player;
        Toolbar toolBar;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Button arrowButton;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            // The width of the level in pixels
            graphics.PreferredBackBufferWidth = level.Width * 32;
            // The height of the toolbar + the height of the level in pixels
            graphics.PreferredBackBufferHeight = 32 + level.Height * 32;

            graphics.ApplyChanges();
            IsMouseVisible = true;

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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D topBar = Content.Load<Texture2D>("tool bar");
            SpriteFont font = Content.Load<SpriteFont>("Arial");

            toolBar = new Toolbar(topBar, font, new Vector2(0, level.Height * 32));

            Texture2D grass = Content.Load<Texture2D>("grass");
            Texture2D path = Content.Load<Texture2D>("path");

            level.AddTexture(grass);
            level.AddTexture(path);

            Texture2D enemyTexture = Content.Load<Texture2D>("enemy");

            waveManager = new WaveManager(level, 24, enemyTexture);

            Texture2D towerTexture = Content.Load<Texture2D>("arrow tower");
            Texture2D bulletTexture = Content.Load<Texture2D>("bullet");

            player = new Player.Player(level, towerTexture, bulletTexture);

            // The "Normal" texture for the arrow button.
            Texture2D arrowNormal = Content.Load<Texture2D>("GUI\\Arrow Tower\\arrow button");
            // The "MouseOver" texture for the arrow button.
            Texture2D arrowHover = Content.Load<Texture2D>("GUI\\Arrow Tower\\arrow hover");
            // The "Pressed" texture for the arrow button.
            Texture2D arrowPressed = Content.Load<Texture2D>("GUI\\Arrow Tower\\arrow pressed");

            // Initialize the arrow button.
            arrowButton = new Button(arrowNormal, arrowHover,
                arrowPressed, new Vector2(0, level.Height * 32));

            arrowButton.Clicked += new EventHandler(arrowButton_Clicked);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        private void arrowButton_Clicked(object sender, EventArgs e)
        {
            player.NewTowerType = "Arrow Tower";
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            waveManager.Update(gameTime);
            player.Update(gameTime, waveManager.Enemies);

            //Update the arrow button.
            arrowButton.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            level.Draw(spriteBatch);
            player.Draw(spriteBatch);
            waveManager.Draw(spriteBatch);

            // Draw the tool bar first,
            toolBar.Draw(spriteBatch, player);
            // and then our buttons.
            arrowButton.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}