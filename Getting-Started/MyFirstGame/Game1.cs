using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyFirstGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;  // gives access to graphics device configs and render settings
        private SpriteBatch _spriteBatch;         // makes it easy to do 2d drawing

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        // this method can be removed if not needed
        // called after constructor is called before any method
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        // called after initialize but before game runs
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }
        
        // DON'T PUT ANY DRAWING CODE IN HERE
        protected override void Update(GameTime gameTime)
        {
            // end game when escape is pressed or back button on gamepad
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        // DON'T PUT ANY UPDATE CODE IN HERE
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
