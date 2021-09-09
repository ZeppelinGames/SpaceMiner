using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceMiner;

namespace SpaceMiner
{
    public class GameObject
    {
        public Vector2 position = Vector2.Zero;
        public float scale = 0;
        public float rotation = 0;
        public Sprite spr = null;

        public GameObject(Vector2 position, float scale = 1, float rotation = 0, Sprite spr = null)
        {
            this.position = position;
            this.scale = scale;
            this.rotation = rotation;
            this.spr = spr;
        }

        public GameObject(float posX = 0, float posY = 0, float scale = 1, float rotation = 0, Sprite spr = null)
        {
            this.position = new Vector2(posX, posY);
            this.scale = scale;
            this.rotation = rotation;
            this.spr = spr;
        }

        public void Draw()
        {
            Renderer.DrawSprite(this.spr, this.position, this.scale, this.rotation);
        }
    }
}
