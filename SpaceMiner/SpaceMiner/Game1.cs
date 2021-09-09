using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceMiner;

namespace SpaceMiner
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private int _windowWidth = 512;
        private int _windowHeight = 512;

        private GameObject shipGO;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true; //Set mouse invisible
        }

        protected override void Initialize()
        {
            Debug.WriteLine("Initialising");
            // TODO: Add your initialization logic here
            this.Window.Title = "Space Miner";

            _graphics.PreferredBackBufferWidth = _windowWidth;
            _graphics.PreferredBackBufferHeight = _windowHeight;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();

            _graphics.SetupRenderer(_windowWidth, _windowHeight, 4);

            base.Initialize();

            Debug.WriteLine("Initialisation complete");
        }

        protected override void LoadContent()
        {
            Debug.WriteLine("Loading content");

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Sprite ship = Sprite.LoadSprite(Content.Load<Texture2D>("Ship"));
            shipGO = new GameObject(new Vector2(_windowWidth / 2 - 100, _windowHeight / 2), Vector2.One * 2, 0, ship);

            Debug.WriteLine("Load content complete");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) //Quit game on escape key or back button
                Exit();

            // TODO: Add your update logic here
            Vector2 mousePos = Mouse.GetState().Position.ToVector2();
            shipGO.rotation = HelperFuncs.GetAngle(mousePos, shipGO.position).radiansToDegrees() - 90;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Black);
            Renderer.ClearScreen(); //Clears the screen

            // TODO: Add your drawing code here
            //Renderer.DrawRect(new Vector2(50, 50), new Vector2(10, 10), new Color(255, 0, 0));
            shipGO.Draw();
          //  Renderer.DrawRect(shipGO.spr.GetSpriteCenter() * shipGO.scale + shipGO.position, Vector2.One*8, Color.Red);
          //  Renderer.DrawRectOutline(shipGO.position, (shipGO.spr.GetSpriteBounds().Max.ToVector2() - shipGO.spr.GetSpriteBounds().Min.ToVector2()) * shipGO.scale, Color.Yellow);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            _spriteBatch.RenderCanvas();
            _spriteBatch.End();

            //Draw
            base.Draw(gameTime);
        }
    }
}
