using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceMiner
{
    public class Ship : GameObject
    {
        public WeaponSlot[] weaponSlots; //Position that weapon sprite sits on ship (normalised pos)

        public float acceleration = 1; //Affects how fast you move foward
        public float control = 1; //Affects braking + turning

        public Ship(Sprite shipSprite, WeaponSlot[] weaponSlots, float acceleration = 1, float control = 1)
        {
            this.spr = shipSprite;
            this.weaponSlots = weaponSlots;
            this.acceleration = acceleration;
            this.control = control;
        }

        public void DrawShip()
        {
            this.Draw();
            foreach (WeaponSlot weapon in weaponSlots)
            {
                weapon.weapon.Draw();
            }
        }
    }
}
