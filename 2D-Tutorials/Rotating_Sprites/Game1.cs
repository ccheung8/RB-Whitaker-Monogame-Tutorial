using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Rotating_Sprites
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D arrow;    // stores texture for drawing
        private float angle = 0;    // store angle of rotation

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

            arrow = Content.Load<Texture2D>("arrow");   // loads arrow texture
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            angle += 0.01f;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // location of where we want sprite drawn
            Vector2 location = new Vector2(400, 240);
            // indicates what part of texture we want to draw, in this case, the entire texture
            Rectangle sourceRectangle = new Rectangle(0, 0, arrow.Width, arrow.Height);
            // sets origin to bottom middle
            Vector2 origin = new Vector2(arrow.Width / 2, arrow.Height);

            _spriteBatch.Draw(
                arrow,              // texture we want to draw
                location,           // location we want to draw at
                sourceRectangle,    // source rectangle
                Color.White,        // tint color (white for no tint)
                angle,              // rotation angle
                origin,             // origin
                1.0f,               // scale factor
                SpriteEffects.None, // type of SpriteEffect (e.g SpriteEffect.FlipHorizontally)
                1                   // depth
             );

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
