using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpriteBatches
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D background;
        private Texture2D shuttle;
        private Texture2D earth;

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
            // creates new SpriteBatch that can be used to draw textures
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            background = Content.Load<Texture2D>("stars");
            shuttle = Content.Load<Texture2D>("shuttle");
            earth = Content.Load<Texture2D>("earth");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // begins drawing sprites
            _spriteBatch.Begin();

            // first arg takes in texture (background)
            // second arg is a rectangle that indicates where the sprite should be drawn
            // first 2 args in rectangle are x & y coords, last 2 are width and height
            // 800 x 480 fills up entire window since it's 800 x 480 by default
            // last paramater is tint color. Color.White means no tint
            _spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            // second arg determines location of sprites
            // draw order matters, later sprites are placed on top
            _spriteBatch.Draw(earth, new Vector2(400, 240), Color.White);
            _spriteBatch.Draw(shuttle, new Vector2(450, 240), Color.White);

            // finishes drawing sprites
            _spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
