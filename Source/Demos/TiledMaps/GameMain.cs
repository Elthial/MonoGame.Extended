using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Input;
using TiledMaps.Systems;

namespace TiledMaps
{
    public class MainGame : Game
    {
        // ReSharper disable once NotAccessedField.Local
        private GraphicsDeviceManager _graphicsDeviceManager;
        private World _world;

        public MainGame()
        {
            _graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void LoadContent()
        {
            //var font = Content.Load<BitmapFont>("Sensation");
            var camera = new OrthographicCamera(GraphicsDevice);
            var keyboardService = new KeyboardService();
            var mouseService = new MouseService();

            _world = new WorldBuilder()
                .AddSystem(new InputSystem(mouseService, keyboardService))
                .AddSystem(new MapRenderingSystem(Content, GraphicsDevice, camera))
                .AddSystem(new CameraSystem(camera, keyboardService, mouseService))
                .Build();
        }

        protected override void UnloadContent()
        {
            _world.Dispose();
        }

        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
                Exit();

            _world.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _world.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
