using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TimeSteps
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Vector2 positionFixed = new Vector2(0, 0);  // position for FIXED time step example
        private Vector2 velocityFixed = new Vector2(0.246667f, 0);  // player's speed in units per frame

        private Vector2 positionVariable = new Vector2(0, 0);   // position for VARIABLE time step example
        private Vector2 velocityVariable = new Vector2(14.8f, 0);   // player speed in units per second

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // these are typically done in the constructor
            IsFixedTimeStep = false;    // sets game loop to variable instead of fixed time step
            //TargetElapsedTime = TimeSpan.FromMilliseconds(20); // elapsed time can be altered when time step is fixed - here it's 20ms or 50fps
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            positionFixed += velocityFixed; // move the player forward each frame in fixed time step

            // Moves player foward by amount that's weighted by amount of time that has passed
            // if using units per hours, or ms, etc. you'd use Totalhours or TotalMilliseconds
            // we use TotalSeconds here since we specified speed in units per second
            // STORING THINGS IN UNITS PER TIME IS PREFERRED TO UNITS PER FRAME
            positionVariable += velocityVariable * (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
