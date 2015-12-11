using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;
using Game1;

namespace TowerDefenseTutorial
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Level level = new Level();

        Enemy enemy1;

        Player player;

        public Level Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }

        public Enemy Enemy1
        {
            get
            {
                return enemy1;
            }

            set
            {
                enemy1 = value;
            }
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = Level.Width * 32;
            graphics.PreferredBackBufferHeight = Level.Height * 32;
            graphics.ApplyChanges();

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D grass = Content.Load<Texture2D>("grass");
            Texture2D path = Content.Load<Texture2D>("path");

            Level.AddTexture(grass);
            Level.AddTexture(path);

            Texture2D enemyTexture = Content.Load<Texture2D>("enemy");

            Enemy1 = new Enemy(enemyTexture, Vector2.Zero, 100, 10, 0.5f);
            Enemy1.SetWaypoints(Level.Waypoints);

            Texture2D towerTexture = Content.Load<Texture2D>("arrow tower");
            player = new Player(Level, towerTexture);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            Enemy1.Update(gameTime);

            List<Enemy> enemies = new List<Enemy>();
            enemies.Add(Enemy1);

            player.Update(gameTime, enemies);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            Level.Draw(spriteBatch);
            Enemy1.Draw(spriteBatch);
            player.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
