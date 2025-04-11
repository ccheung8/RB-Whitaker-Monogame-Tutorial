using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Texture_Atlases
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private AnimatedSprite animatedSprite;  // instance variable of AnimatedSprite class

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

            Texture2D texture = Content.Load<Texture2D>("SmileyWalk");  // loads texture
            animatedSprite = new AnimatedSprite(texture, 4, 4);         // creates AnimatedSprite from texture
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            animatedSprite.Update();    // updated animatedSprite

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            animatedSprite.Draw(_spriteBatch, new Vector2(400, 200));    // draws animatedSprite

            base.Draw(gameTime);
        }
    }
}
