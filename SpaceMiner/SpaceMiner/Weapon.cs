using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceMiner
{
    public class Weapon : GameObject
    {
        public Sprite bulletSprite;

        public float damage;
        public float fireRate;
        public float coolDown;
        public float reloadTime;

        public Weapon(Sprite weaponSprite, Sprite bulletSprite = null, float damage = 0, float fireRate = 0, float coolDown = 0, float reloadTime = 0)
        {
            this.spr = weaponSprite;
            this.bulletSprite = bulletSprite;
            this.damage = damage;
            this.fireRate = fireRate;
            this.coolDown = coolDown;
            this.reloadTime = reloadTime;
        }
    }
}
