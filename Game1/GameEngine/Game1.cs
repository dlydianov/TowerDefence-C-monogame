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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Level level = new Level();

        WaveManager waveManager;

        Player.Player player;

        Button arrowButton;
        Button spikeButton;
        Button slowButton;

        Toolbar toolBar;

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
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D topBar = Content.Load<Texture2D>("tool bar");
            SpriteFont font = Content.Load<SpriteFont>("Arial");

            toolBar = new Toolbar(topBar, font, new Vector2(0, level.Height * 32));

            Texture2D grass = Content.Load<Texture2D>("grass");
            Texture2D path = Content.Load<Texture2D>("path");

            level.AddTexture(grass);
            level.AddTexture(path);

            Texture2D bulletTexture = Content.Load<Texture2D>("bullet");

            Texture2D[] towerTextures = new Texture2D[]
            {
                Content.Load<Texture2D>("arrow tower"),
                Content.Load<Texture2D>("spike tower"),
                Content.Load<Texture2D>("slow tower"),
            };

            player = new Player.Player(level, towerTextures, bulletTexture);

            Texture2D enemyTexture = Content.Load<Texture2D>("enemy");
            waveManager = new WaveManager(player, level, 24, enemyTexture);

            // The "Normal" texture for the arrow button.
            Texture2D arrowNormal = Content.Load<Texture2D>("GUI\\Arrow Tower\\arrow button");
            // The "MouseOver" texture for the arrow button.
            Texture2D arrowHover = Content.Load<Texture2D>("GUI\\Arrow Tower\\arrow hover");
            // The "Pressed" texture for the arrow button.
            Texture2D arrowPressed = Content.Load<Texture2D>("GUI\\Arrow Tower\\arrow pressed");

            // The "Normal" texture for the spike button.
            Texture2D spikeNormal = Content.Load<Texture2D>("GUI\\Spike Tower\\spike button");
            // The "MouseOver" texture for the spike button.
            Texture2D spikeHover = Content.Load<Texture2D>("GUI\\Spike Tower\\spike hover");
            // The "Pressed" texture for the spike button.
            Texture2D spikePressed = Content.Load<Texture2D>("GUI\\Spike Tower\\spike pressed");

            // The "Normal" texture for the slow button.
            Texture2D slowNormal = Content.Load<Texture2D>("GUI\\Slow Tower\\slow button");
            // The "MouseOver" texture for the slow button.
            Texture2D slowHover = Content.Load<Texture2D>("GUI\\Slow Tower\\slow hover");
            // The "Pressed" texture for the slow button.
            Texture2D slowPressed = Content.Load<Texture2D>("GUI\\Slow Tower\\slow pressed");

            // Initialize the arrow button.
            arrowButton = new Button(arrowNormal, arrowHover,
                arrowPressed, new Vector2(0, level.Height * 32));

            // Initialize the spike button.
            spikeButton = new Button(spikeNormal, spikeHover,
                spikePressed, new Vector2(32, level.Height * 32));

            // Initialize the slow button.
            slowButton = new Button(slowNormal, slowHover,
                slowPressed, new Vector2(32 * 2, level.Height * 32));

            //arrowButton.Clicked += new EventHandler(arrowButton_Clicked);
            //spikeButton.Clicked += new EventHandler(spikeButton_Clicked);
            //slowButton.Clicked += new EventHandler(slowButton_Clicked);

            arrowButton.OnPress += new EventHandler(arrowButton_OnPress);
            spikeButton.OnPress += new EventHandler(spikeButton_OnPress);
            slowButton.OnPress += new EventHandler(slowButton_OnPress);
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
        private void spikeButton_Clicked(object sender, EventArgs e)
        {
            player.NewTowerType = "Spike Tower";
        }
        private void arrowButton_OnPress(object sender, EventArgs e)
        {
            player.NewTowerType = "Arrow Tower";
            player.NewTowerIndex = 0;
        }
        private void spikeButton_OnPress(object sender, EventArgs e)
        {
            player.NewTowerType = "Spike Tower";
            player.NewTowerIndex = 1;
        }
        private void slowButton_OnPress(object sender, EventArgs e)
        {
            player.NewTowerType = "Slow Tower";
            player.NewTowerIndex = 2;
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
            //Update the spike button.
            spikeButton.Update(gameTime);
            //Update the slow button.
            slowButton.Update(gameTime);

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
            spikeButton.Draw(spriteBatch);
            slowButton.Draw(spriteBatch);

            player.DrawPreview(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}