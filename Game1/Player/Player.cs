using System.Collections.Generic;
using Game1.Towers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.Player
{
    public class Player
    {
        // Player state.
        private int money = 50;
        private int lives = 30;

        // The texture used to draw our tower.
        private Texture2D towerTexture;
        // The texture used to draw bullets.
        private Texture2D bulletTexture;

        // A list of the players towers
        private List<Tower> towers = new List<Tower>();

        // Mouse state for the current frame.
        private MouseState mouseState;
        // Mouse state for the previous frame.
        private MouseState oldState;

        // Tower placement.
        private int cellX;
        private int cellY;

        private int tileX;
        private int tileY;

        // The type of tower to add.
        private string newTowerType;

        // A reference to the level.
        private Level level;

        public int Money
        {
            get { return money; }
        }
        public int Lives
        {
            get { return lives; }
        }

        public string NewTowerType
        {
            set { newTowerType = value; }
        }

        /// <summary>
        /// Construct a new player.
        /// </summary>
        public Player(Level level, Texture2D towerTexture, Texture2D bulletTexture)
        {
            this.level = level;

            this.towerTexture = towerTexture;
            this.bulletTexture = bulletTexture;
        }

        /// <summary>
        /// Returns wether the current cell is clear
        /// </summary>
        private bool IsCellClear()
        {
            // Make sure tower is within limits
            bool inBounds = cellX >= 0 && cellY >= 0 &&
                cellX < level.Width && cellY < level.Height;

            bool spaceClear = true;

            // Check that there is no tower in this spot
            foreach (Tower tower in towers)
            {
                spaceClear = (tower.Position != new Vector2(tileX, tileY));

                if (!spaceClear)
                {
                    break;
                }
            }

            bool onPath = (level.GetIndex(cellX, cellY) != 1);

            return inBounds && spaceClear && onPath; // If both checks are true return true
        }

        /// <summary>
        /// Adds a tower to the player's collection.
        /// </summary>
        public void AddTower()
        {
            Tower towerToAdd = null;

            switch (newTowerType)
            {
                case "Arrow Tower":
                    {
                        towerToAdd = new ArrowTower(towerTexture,
                            bulletTexture, new Vector2(tileX, tileY));
                        break;
                    }
            }

            // Only add the tower if there is a space and if the player can afford it.
            if (IsCellClear() == true && towerToAdd.Cost <= money)
            {
                towers.Add(towerToAdd);
                money -= towerToAdd.Cost;

                // Reset the newTowerType field.
                newTowerType = string.Empty;
            }
        }

        /// <summary>
        /// Updates the player.
        /// </summary>
        public void Update(GameTime gameTime, List<Enemy.Enemy> enemies)
        {
            mouseState = Mouse.GetState();

            cellX = (int)(mouseState.X / 32); // Convert the position of the mouse
            cellY = (int)(mouseState.Y / 32); // from array space to level space

            tileX = cellX * 32; // Convert from array space to level space
            tileY = cellY * 32; // Convert from array space to level space

            if (mouseState.LeftButton == ButtonState.Released
                && oldState.LeftButton == ButtonState.Pressed)
            {
                if (string.IsNullOrEmpty(newTowerType) == false)
                {
                    AddTower();
                }
            }

            foreach (Tower tower in towers)
            {
                if (tower.Target == null)
                {
                    tower.GetClosestEnemy(enemies);
                }

                tower.Update(gameTime);
            }

            oldState = mouseState; // Set the oldState so it becomes the state of the previous frame.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tower tower in towers)
            {
                tower.Draw(spriteBatch);
            }
        }
    }
}
