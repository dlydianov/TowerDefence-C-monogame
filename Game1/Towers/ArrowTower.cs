using Game1.BulletMain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Towers
{
    public class ArrowTower : Tower
    {

        private const int arrowTowerDamage = 15;  // Set the damage
        private const int arrowTowerCoast = 15; // Set the initial cost
        private const int arrowTowerRadius = 80;  // Set the radius

        public ArrowTower(Texture2D texture, Texture2D bulletTexture, Vector2 position)
            : base(texture, bulletTexture, position)
        {
            this.damage = arrowTowerDamage; 
            this.cost = arrowTowerCoast; 

            this.radius = arrowTowerRadius;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (bulletTimer >= 0.75f && target != null)
            {
                Bullet bullet = new Bullet(bulletTexture, Vector2.Subtract(center,
                    new Vector2(bulletTexture.Width/2)), rotation, 6, damage);

                bulletList.Add(bullet);
                bulletTimer = 0;
            }

            for (int i = 0; i < bulletList.Count; i++)
            {
                Bullet bullet = bulletList[i];

                bullet.SetRotation(rotation);
                bullet.Update(gameTime);

                if (!IsInRange(bullet.Center))
                    bullet.Kill();

                if (target != null && Vector2.Distance(bullet.Center, target.Center) < 12)
                {
                    target.CurrentHealth -= bullet.Damage;
                    bullet.Kill();
                }

                if (bullet.IsDead())
                {
                    bulletList.Remove(bullet);
                    i--;
                }
            }
        }
    }
}
