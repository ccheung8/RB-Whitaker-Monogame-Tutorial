using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AdditiveBlending
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // instance vars to store textures
        private Texture2D blue;
        private Texture2D green;
        private Texture2D red;

        // stores what angle the sprites are at in circle
        private float blueAngle = 0;
        private float greenAngle = 0;
        private float redAngle = 0;

        // stores speed the sprites move around circle
        private float blueSpeed = 0.025f;
        private float greenSpeed = 0.017f;
        private float redSpeed = 0.022f;

        // radius of circle our sprites will move around in
        private float distance = 100;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            blue = Content.Load<Texture2D>("blue");
            green = Content.Load<Texture2D>("green");
            red = Content.Load<Texture2D>("red");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // updates angles of sprites in accordance to speed
            blueAngle += blueSpeed;
            greenAngle += greenSpeed;
            redAngle += redSpeed;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // calculates location for each sprite
            Vector2 bluePosition = new Vector2(
                (float)Math.Cos(blueAngle) * distance,
                (float)Math.Sin(blueAngle) * distance);
            Vector2 greenPosition = new Vector2(
                (float)Math.Cos(greenAngle) * distance,
                (float)Math.Sin(greenAngle) * distance);
            Vector2 redPosition = new Vector2(
                (float)Math.Cos(redAngle) * distance,
                (float)Math.Sin(redAngle) * distance);

            // store where we want sprites centered
            // this is so they go in circles around the center rather than top left corner
            Vector2 center = new Vector2(300, 140);

            // this version of begin indicates that we want to do additive blending
            // Alternative BlendStates:
            // BlendState.AlphaBlend - the default blend mode
            // BlendState.Opaque - ignores alpha channels altogether
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);

            _spriteBatch.Draw(blue, center + bluePosition, Color.White);
            _spriteBatch.Draw(green, center + greenPosition, Color.White);
            _spriteBatch.Draw(red, center + redPosition, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
