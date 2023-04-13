using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Topic_1_Monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Random r = new Random();

        Texture2D spaceShipTexture;
        Texture2D backgroundTexture;
        Random generator = new Random();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

            this.Window.Title = "Topic 1";

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            spaceShipTexture = Content.Load<Texture2D>("player");

            int num = generator.Next(0, 2);

            if (num == 1)
            {
                backgroundTexture = Content.Load<Texture2D>("Background");
            }
            else
            {
                backgroundTexture = Content.Load<Texture2D>("Background2");
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);

            for (int coords_x = 0; coords_x < _graphics.PreferredBackBufferWidth; coords_x += 100)
            {
                    for (int coords_y = 0; coords_y < _graphics.PreferredBackBufferHeight; coords_y +=100)
                    {
                        _spriteBatch.Draw(spaceShipTexture, new Vector2(coords_x, coords_y), Color.White);
                    }
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}