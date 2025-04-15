using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Using_3D_Models
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Model model;    // Model type for loading 3D models
        // matrices for drawing model
        private Matrix world = Matrix.CreateTranslation(new Vector3(0, 0, 0));  // place points around origin
        // places camera 10 units above origin, points it at 0, 0, 0 and sets up to negative so the ship is pointed up
        private Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 10), new Vector3(0, 0, 0), -Vector3.Up);
        // 45deg fov, default aspect ratio for monogame, near clipping plane of 0.1f, far clipping plane of 100f
        private Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 100f);

        private Vector3 position;   // position of our model
        private float angle;        // angle of our model

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

            position = new Vector3(0, 0, 0);    // initializes position at origin

            angle = 0;

            model = Content.Load<Model>("Ship");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            angle -= 0.03f; // adds 0.03 units of angle
            position -= new Vector3(0, 0.01f, 0);    // move object 0.01 unit in the y direction every update
            world = Matrix.CreateRotationY(angle) * Matrix.CreateTranslation(position); //updates world matrix to rotate around Y then translate

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            DrawModel(model, world, view, projection);

            base.Draw(gameTime);
        }

        private void DrawModel(Model model, Matrix world, Matrix view, Matrix projection) {
            foreach (ModelMesh mesh in model.Meshes) {
                foreach (BasicEffect effect in mesh.Effects) {
                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;
                }

                mesh.Draw();
            }
        }
    }
}
