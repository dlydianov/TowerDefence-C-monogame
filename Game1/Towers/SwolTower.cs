using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game1.BulletMain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Towers
{
    public class SlowTower : Tower
    {
        // Defines how fast an enemy will move when hit.
        private float speedModifier;
        // Defines how long this effect will last.
        private float modifierDuration;
        private const int slowTowerDamage = 5; // Set the damage
        private const int slowTowerCost = 25;   // Set the initial cost

        private const int slowTowerRadius = 80; // Set the radius
        private const float slowTowerSpeedModifier = 0.6f;
        private const float slowTowerModifierDuration = 2.0f;
        private const float slowTowerBulletTime = 2.75f;
       

        public SlowTower(Texture2D texture, Texture2D bulletTexture, Vector2 position)
            : base(texture, bulletTexture, position)
        {
            this.damage = slowTowerDamage; 
            this.cost = slowTowerCost;  

            this.radius = slowTowerRadius; 

            this.speedModifier = slowTowerSpeedModifier;
            this.modifierDuration = slowTowerModifierDuration;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (bulletTimer >= slowTowerBulletTime && target != null)
            {
                Bullet bullet = new Bullet(bulletTexture, Vector2.Subtract(center,
                    new Vector2(bulletTexture.Width / 2)), rotation, 6, damage);

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

                // If the bullet hits a target,
                if (target != null && Vector2.Distance(bullet.Center, target.Center) < 12)
                {
                    // destroy the bullet and hurt the target.
                    target.CurrentHealth -= bullet.Damage;
                    bullet.Kill();

                    // Apply our speed modifier if it is better than
                    // the one currently affecting the target :
                    if (target.SpeedModifier <= speedModifier)
                    {
                        target.SpeedModifier = speedModifier;
                        target.ModifierDuration = modifierDuration;
                    }
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
