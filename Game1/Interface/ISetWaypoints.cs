using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Game1.Interface
{
    public interface ISetWaypoints
    {
        void SetWaypoints(Queue<Vector2> waypoints);
    }
}
