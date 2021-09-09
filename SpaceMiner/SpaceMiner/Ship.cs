using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceMiner
{
    public class Ship : GameObject
    {
        public WeaponSlot[] weaponSlots; //Position that weapon sprite sits on ship (normalised pos)
       
        public float maxAcceleration = 2;
        public float acceleration = 1; //Affects how fast you move foward
        public float control = 1; //Affects braking + turning

        public Ship(Sprite shipSprite, WeaponSlot[] weaponSlots, float acceleration = 1, float maxAcceleration = 2, float control = 1)
        {
            this.spr = shipSprite;

            for (int i = 0; i < weaponSlots.Length; i++)
            {
                weaponSlots[i].weapon.SetTransforms(this.position, this.scale, this.rotation);
            }

            this.weaponSlots = weaponSlots;
            this.acceleration = acceleration;
            this.maxAcceleration = maxAcceleration;
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
