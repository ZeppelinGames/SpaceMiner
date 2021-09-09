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
        public Vector2 scale = Vector2.One;
        public float rotation = 0;
        public Sprite spr;

        public GameObject(Vector2 position, Vector2 scale, float rotation, Sprite spr)
        {
            this.position = position;
            this.scale = scale;
            this.rotation = rotation;
            this.spr = spr;
        }

        public void Draw()
        {
            Vector2 sprCenter = (this.spr.GetSpriteCenter() * this.scale);
            for (int i = 0; i < spr.spritePixels.Length; i++)
            {
                //Get rotated position
                Vector2 pixelPos = this.spr.spritePixels[i].position * this.scale;

                float dist = (int)(Vector2.Distance(sprCenter, (this.spr.spritePixels[i].position * this.scale))/this.scale.X) * this.scale.X;
                float angle = HelperFuncs.GetAngle(sprCenter, pixelPos);

                float rotAngle = MathF.Round(this.rotation).degreesToRadians() + angle;

                Vector2 drawPos = new Vector2(
                    MathF.Cos(rotAngle) * dist + (sprCenter.X + this.position.X),
                    MathF.Sin(rotAngle) * dist + (sprCenter.Y + this.position.Y));

                Vector2 roundedPos = new Vector2((int)(drawPos.X / this.scale.X) * this.scale.X, (int)(drawPos.Y / this.scale.Y) * this.scale.Y);
                Renderer.DrawRect(roundedPos, this.scale, this.spr.spritePixels[i].color);
            }
        }
    }
}
