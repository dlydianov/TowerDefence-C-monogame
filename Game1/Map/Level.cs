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
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,2,2,2,2,2,2,0,0,0,0,0,0},
            {0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,2,0,0,0,0,0,0},
            {0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,2,0,0,0,0,0,0},
            {0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,2,0,0,0,0,0,0},
            {0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,0,0,2,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0},
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
            waypoints.Enqueue(new Vector2(19, 10) * 32);
            waypoints.Enqueue(new Vector2(19, 11) * 32);
            waypoints.Enqueue(new Vector2(19, 12) * 32);
            waypoints.Enqueue(new Vector2(18, 12) * 32);
            waypoints.Enqueue(new Vector2(17, 12) * 32);
            waypoints.Enqueue(new Vector2(16, 12) * 32);
            waypoints.Enqueue(new Vector2(15, 12) * 32);
            waypoints.Enqueue(new Vector2(14, 12) * 32);
            waypoints.Enqueue(new Vector2(13, 12) * 32);
            waypoints.Enqueue(new Vector2(12, 12) * 32);
            waypoints.Enqueue(new Vector2(11, 12) * 32);
            waypoints.Enqueue(new Vector2(10, 12) * 32);
            waypoints.Enqueue(new Vector2(9, 12) * 32);
            waypoints.Enqueue(new Vector2(8, 12) * 32);
            waypoints.Enqueue(new Vector2(7, 12) * 32);
            waypoints.Enqueue(new Vector2(6, 12) * 32);
            waypoints.Enqueue(new Vector2(5, 12) * 32);
            waypoints.Enqueue(new Vector2(5, 13) * 32);
            waypoints.Enqueue(new Vector2(5, 14) * 32);
            waypoints.Enqueue(new Vector2(5, 15) * 32);
            waypoints.Enqueue(new Vector2(5, 16) * 32);
            waypoints.Enqueue(new Vector2(6, 16) * 32);
            waypoints.Enqueue(new Vector2(7, 16) * 32);
            waypoints.Enqueue(new Vector2(8, 16) * 32);
            waypoints.Enqueue(new Vector2(9, 16) * 32);
            waypoints.Enqueue(new Vector2(10, 16) * 32);
            waypoints.Enqueue(new Vector2(11, 16) * 32);
            waypoints.Enqueue(new Vector2(12, 16) * 32);
            waypoints.Enqueue(new Vector2(13, 16) * 32);
            waypoints.Enqueue(new Vector2(14, 16) * 32);
            waypoints.Enqueue(new Vector2(15, 16) * 32);
            waypoints.Enqueue(new Vector2(16, 16) * 32);
            waypoints.Enqueue(new Vector2(17, 16) * 32);
            waypoints.Enqueue(new Vector2(18, 16) * 32);
            waypoints.Enqueue(new Vector2(19, 16) * 32);
            waypoints.Enqueue(new Vector2(20, 16) * 32);
            waypoints.Enqueue(new Vector2(21, 16) * 32);
            waypoints.Enqueue(new Vector2(22, 16) * 32);
            waypoints.Enqueue(new Vector2(23, 16) * 32);
            waypoints.Enqueue(new Vector2(24, 16) * 32);
            waypoints.Enqueue(new Vector2(25, 16) * 32);
            waypoints.Enqueue(new Vector2(26, 16) * 32);
            waypoints.Enqueue(new Vector2(26, 15) * 32);
            waypoints.Enqueue(new Vector2(26, 14) * 32);
            waypoints.Enqueue(new Vector2(26, 13) * 32);
            waypoints.Enqueue(new Vector2(26, 12) * 32);
            waypoints.Enqueue(new Vector2(27, 12) * 32);
            waypoints.Enqueue(new Vector2(28, 12) * 32);
            waypoints.Enqueue(new Vector2(29, 12) * 32);
            waypoints.Enqueue(new Vector2(30, 12) * 32);
            waypoints.Enqueue(new Vector2(31, 12) * 32);
            waypoints.Enqueue(new Vector2(31, 13) * 32);
            waypoints.Enqueue(new Vector2(31, 14) * 32);
            waypoints.Enqueue(new Vector2(31, 15) * 32);
            waypoints.Enqueue(new Vector2(31, 16) * 32);
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
                    if (textureIndex != 0)
                    {
                        Texture2D texture = tileTextures[textureIndex];
                        batch.Draw(texture, new Rectangle(x * 32, y * 32, 32, 32), Color.White);
                    }
                    

                    
                }
            }
        }
    }

}