using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceMiner
{
    public class WeaponSlot
    {
        public Vector2 slotPosition;
        public Weapon weapon;

        public WeaponSlot(Vector2 slotPosition, Weapon weapon)
        {
            this.slotPosition = slotPosition;
            this.weapon = weapon;
        }
    }
}
