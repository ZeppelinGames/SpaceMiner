using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using SpaceMiner;

namespace SpaceMiner
{
    public static class Renderer
    {
        private static int _windowWidth;
        private static int _windowHeight;
        private static int _pixelScale; //How many pixels per pixel

        private static Texture2D _canvas;
        private static Color[] _canvasPixels;

        private static int[] _framePixels = new int[_windowWidth * _windowHeight];
        private static int _framePixelIndex = 0;

        private static bool _dirtyCanvas;

        public static void SetupRenderer(this GraphicsDeviceManager _graphics, int windowWidth, int windowHeight, int pixelScale=1)
        {
            _pixelScale = pixelScale;

            _windowWidth = windowWidth;
            _windowHeight = windowHeight;

            _framePixels = new int[_windowWidth * _windowHeight];

            _canvas = new Texture2D(_graphics.GraphicsDevice, _windowWidth, _windowHeight); //Create canvas using window bounds on graphics device
            _canvasPixels = new Color[_windowWidth * _windowHeight]; //Fill pixel array using window size

            _dirtyCanvas = true;
        }

        public static void RenderCanvas(this SpriteBatch _spriteBatch)
        {
            if (_dirtyCanvas)
            {
                //Update canvas data
                _canvas.SetData(_canvasPixels, 0, _canvasPixels.Length);
                _dirtyCanvas = false;
            }
            _spriteBatch.Draw(_canvas, new Rectangle(0, 0, _windowWidth, _windowHeight), Color.White);
        }

        public static void ClearScreen()
        {
            for (int i = 0; i < _framePixelIndex; i++)
            {
                _canvasPixels[_framePixels[i]] = Color.Black;
            }
            _framePixels = new int[_windowHeight * _windowWidth];
            _framePixelIndex = 0;
        }

        public static void DrawDebugScreen()
        {
            for (int x = 0; x < _windowWidth; x+=_pixelScale)
            {
                for (int y = 0; y < _windowHeight; y+=_pixelScale)
                {
                    DrawRect(x, y,_pixelScale,_pixelScale, new Color(HelperFuncs.RandomRange(0,255), HelperFuncs.RandomRange(0, 255), HelperFuncs.RandomRange(0, 255)));
                }
            }
        }

        public static void DrawSprite(int x, int y, GameObject spr)
        {
            for(int i=0; i < spr.spr.spritePixels.Length; i++)
            {
                DrawRect(spr.spr.spritePixels[i].position + spr.position, Vector2.One * _pixelScale, spr.spr.spritePixels[i].color);
            }
        }

        public static void SetPixel(int x, int y, Color c)
        {
            int pos = x + (y * _windowWidth);
            //Make sure pixel is on screen
            if (pos >= 0 && pos < (_canvasPixels.Length))
            {
                _canvasPixels[pos] = c;

                _framePixels[_framePixelIndex] = pos;
                _framePixelIndex++;

                _dirtyCanvas = true;
            }
        }
        public static void SetPixel(Vector2 pos, Color c)
        {
            SetPixel((int)pos.X, (int)pos.Y, c);
        }

        public static void DrawRect(int x, int y, int width, int height, Color c)
        {
            for (int pX = x; pX < x + width; pX++)
            {
                for (int pY = y; pY < y + height; pY++)
                {
                    SetPixel(pX, pY, c);
                }
            }
        }
        public static void DrawRect(Vector2 pos, Vector2 size, Color c)
        {
            DrawRect((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y, c);
        }

        public static void DrawRectOutline(int x, int y, int width, int height, Color c)
        {
            for (int pX = x; pX < x + width; pX++)
            {
                for (int pY = y; pY < y + height; pY++)
                {
                    if ((pX == x || pX == (x + width)-1) || (pY == y || pY == (y + height)-1)) { SetPixel(pX, pY, c); }
                }
            }
        }
        public static void DrawRectOutline(Vector2 pos, Vector2 size, Color c)
        {
            DrawRectOutline((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y, c);
        }
    }
}
