using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceMiner;
using System;
using System.IO;

namespace SpaceMiner
{
    public class Sprite
    {
        public Pixel[] spritePixels;
        public Color[] spriteIndexedColours;

        private static Color nullColor = new Color(255, 0, 255);
        private static Color[] defaultColourPalette = new Color[] {
            new Color(255,0,255) //Null colour
        };

        public static Sprite LoadSprite(Texture2D sprTexture)
        {
            Color[] sprColors = new Color[sprTexture.Width * sprTexture.Height];
            int[][] sprPixels = new int[sprTexture.Width][];
            sprTexture.GetData(sprColors);

            for (int x = 0; x < sprTexture.Width; x++)
            {
                sprPixels[x] = new int[sprTexture.Height];
                for (int y = 0; y < sprTexture.Height; y++)
                {
                    sprPixels[x][y] = y + (x * sprTexture.Width);
                }
            }

            return new Sprite(sprPixels, sprColors);
        }

        public Sprite(int[][] spritePixels, Color[] spriteIndexedColours)
        {
            this.spriteIndexedColours = spriteIndexedColours == null ? defaultColourPalette : spriteIndexedColours;
            this.spritePixels = new Pixel[HelperFuncs.ArraySize2D(spritePixels)];
            for (int i = 0; i < spritePixels.Length; i++)
            {
                for (int j = 0; j < spritePixels.Length; j++)
                {
                    Color indexedColour = spritePixels[i][j] < this.spriteIndexedColours.Length ? this.spriteIndexedColours[spritePixels[i][j]] : nullColor;
                    this.spritePixels[i + (j * spritePixels.Length)] = new Pixel(new Vector2(j, i), Vector2.Zero, indexedColour);
                }
            }
        }

        public void SetDefaultPalette(Color[] pal)
        {
            defaultColourPalette = pal;
        }

        public Vector2 GetSpriteCenter()
        {
            BoundingBox bounds = GetSpriteBounds();
            return (bounds.Max - bounds.Min).ToVector2() / 2;
        }

        public BoundingBox GetSpriteBounds()
        {
            Vector3 tlBound = Vector3.Zero;
            Vector3 brBound = Vector3.Zero;

            for (int i = 0; i < this.spritePixels.Length; i++)
            {
                tlBound = this.spritePixels[i].position.X < tlBound.X && this.spritePixels[i].position.Y < tlBound.Y ? this.spritePixels[i].position.ToVector3() : tlBound;
                brBound = this.spritePixels[i].position.X > brBound.X && this.spritePixels[i].position.Y > brBound.Y ? this.spritePixels[i].position.ToVector3() : brBound;
            }

            return new BoundingBox(tlBound, brBound);
        }
    }
}
