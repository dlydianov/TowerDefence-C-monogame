using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Enemyes
{
    public interface IEnemy
    {
        int BountyGiven { get; }
        float CurrentHealth { get; set; }
        float DistanceToDestination { get; }
        bool IsDead { get; }

        void Draw(SpriteBatch spriteBatch);
        void SetWaypoints(Queue<Vector2> waypoints);
        void Update(GameTime gameTime);
    }
}