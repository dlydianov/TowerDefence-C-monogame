using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class Level
    {
        private List<Texture2D> tileTextures = new List<Texture2D>();
        private Queue<Vector2> waypoints = new Queue<Vector2>();

        int[,] map = new int[,]
        {
            {0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0},
            {0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0},
            {0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,1,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0},
            {0,0,1,1,1,1,1,0,0,0,1,1,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0},
        };

        public Queue<Vector2> Waypoints
        {
            get { return waypoints; }
        }

        public int Width
        {
            get { return map.GetLength(1); }
        }
        public int Height
        {
            get { return map.GetLength(0); }
        }

        public Level()
        {
            waypoints.Enqueue(new Vector2(2, 0) * 32);
            waypoints.Enqueue(new Vector2(2, 1) * 32);
            waypoints.Enqueue(new Vector2(3, 1) * 32);
            waypoints.Enqueue(new Vector2(4, 1) * 32);
            waypoints.Enqueue(new Vector2(5, 1) * 32);
            waypoints.Enqueue(new Vector2(6, 1) * 32);
            waypoints.Enqueue(new Vector2(7, 1) * 32);
            waypoints.Enqueue(new Vector2(8, 1) * 32);
            waypoints.Enqueue(new Vector2(9, 1) * 32);
            waypoints.Enqueue(new Vector2(10, 1) * 32);
            waypoints.Enqueue(new Vector2(10, 2) * 32);
            waypoints.Enqueue(new Vector2(10, 3) * 32);
            waypoints.Enqueue(new Vector2(10, 4) * 32);
            waypoints.Enqueue(new Vector2(9, 4) * 32);
            waypoints.Enqueue(new Vector2(8, 4) * 32);
            waypoints.Enqueue(new Vector2(7, 4) * 32);
            waypoints.Enqueue(new Vector2(6, 4) * 32);
            waypoints.Enqueue(new Vector2(5, 4) * 32);
            waypoints.Enqueue(new Vector2(4, 4) * 32);
            waypoints.Enqueue(new Vector2(3, 4) * 32);
            waypoints.Enqueue(new Vector2(2, 4) * 32);
            waypoints.Enqueue(new Vector2(2, 5) * 32);
            waypoints.Enqueue(new Vector2(2, 6) * 32);
            waypoints.Enqueue(new Vector2(2, 7) * 32);
            waypoints.Enqueue(new Vector2(3, 7) * 32);
            waypoints.Enqueue(new Vector2(4, 7) * 32);
            waypoints.Enqueue(new Vector2(5, 7) * 32);
            waypoints.Enqueue(new Vector2(6, 7) * 32);
            waypoints.Enqueue(new Vector2(6, 6) * 32);
            waypoints.Enqueue(new Vector2(7, 6) * 32);
            waypoints.Enqueue(new Vector2(8, 6) * 32);
            waypoints.Enqueue(new Vector2(9, 6) * 32);
            waypoints.Enqueue(new Vector2(10, 6) * 32);
            waypoints.Enqueue(new Vector2(10, 7) * 32);
            waypoints.Enqueue(new Vector2(11, 7) * 32);
            waypoints.Enqueue(new Vector2(12, 7) * 32);
            waypoints.Enqueue(new Vector2(12, 8) * 32);
            waypoints.Enqueue(new Vector2(12, 9) * 32);
            waypoints.Enqueue(new Vector2(11, 9) * 32);
            waypoints.Enqueue(new Vector2(10, 9) * 32);
            waypoints.Enqueue(new Vector2(9, 9) * 32);
            waypoints.Enqueue(new Vector2(8, 9) * 32);
            waypoints.Enqueue(new Vector2(7, 9) * 32);
            waypoints.Enqueue(new Vector2(7, 10) * 32);
        }

        public int GetIndex(int cellX, int cellY)
        {
            // It needed to be Width - 1 and Height - 1.
            if (cellX < 0 || cellX > Width - 1 || cellY < 0 || cellY > Height - 1)
                return 0;

            return map[cellY, cellX];
        }

        public void AddTexture(Texture2D texture)
        {
            tileTextures.Add(texture);
        }

        public void Draw(SpriteBatch batch)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    int textureIndex = map[y, x];

                    if (textureIndex == -1)
                        continue;

                    Texture2D texture = tileTextures[textureIndex];

                    batch.Draw(texture, new Rectangle(x * 32, y * 32, 32, 32), Color.White);
                }
            }
        }
    }

}