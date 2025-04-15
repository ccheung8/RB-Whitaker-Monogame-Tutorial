using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Matrices
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // matrices can be combined
        // this matrix rotates on x then translate
        // ORDER MATTERS IN 3D
        Matrix worldMatrix = Matrix.CreateRotationX(MathHelper.ToRadians(45)) *
                Matrix.CreateTranslation(new Vector3(10, 0, 0));

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


            // creating a world, view, and projection matrix
            Vector3 cameraPosition = new Vector3(30.0f, 30.0f, 30.0f);
            Vector3 cameraTarget = new Vector3(0.0f, 0.0f, 0.0f);   // look back at the origin

            float fovAngle = MathHelper.ToRadians(45);  // convert 45deg to radians
            float aspectRatio = (float)_graphics.PreferredBackBufferWidth / _graphics.PreferredBackBufferHeight;    // FORMULA FOR GETTING ASPECT RATIO
            float near = 0.01f; // near clipping plane distance
            float far = 100f;   // far clipping plane distance

            Matrix world = Matrix.CreateTranslation(10.0f, 0.0f, 10.0f);
            Matrix view = Matrix.CreateLookAt(cameraPosition, cameraTarget, Vector3.Up);
            Matrix projection = Matrix.CreatePerspectiveFieldOfView(fovAngle, aspectRatio, near, far);
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

            // TODO: Add your update logic here

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
