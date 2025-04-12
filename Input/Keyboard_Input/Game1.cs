using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Keyboard_Input
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private KeyboardState oldState;

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

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // inputs are usually put in the update method
            KeyboardState newState = Keyboard.GetState();
            
            // handle input
            if (newState.IsKeyDown(Keys.Left) && oldState.IsKeyUp(Keys.Left)) {
                // DO SOMETHING
                // only called when key is first pressed
            }

            oldState = newState;    // set oldstate as newstate for next iteration

            // key modifiers
            if ((newState.IsKeyDown(Keys.LeftControl) || newState.IsKeyDown(Keys.RightControl)) &&
                    newState.IsKeyDown(Keys.C)) {
                // DO SOMETHING WHEN CTRL + C IS PRESSED
            }

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
