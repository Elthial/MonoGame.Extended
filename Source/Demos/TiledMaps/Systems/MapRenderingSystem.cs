using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace TiledMaps.Systems
{
    public class MapRenderingSystem : DrawSystem
    {
        private readonly GraphicsDevice _graphicsDevice;
        private readonly Camera _camera;
        private readonly TiledMapRenderer _mapRenderer;

        public MapRenderingSystem(ContentManager contentManager, GraphicsDevice graphicsDevice, Camera camera)
        {
            _graphicsDevice = graphicsDevice;
            _camera = camera;

            var map = contentManager.Load<TiledMap>("test-map-1");
            _mapRenderer = new TiledMapRenderer(graphicsDevice, map);
        }

        public override void Draw(GameTime gameTime)
        {
            _graphicsDevice.Clear(Color.CornflowerBlue);
            _graphicsDevice.BlendState = BlendState.NonPremultiplied;
            _graphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            _graphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;

            _mapRenderer.Draw(layerIndex: 0, viewMatrix: _camera.GetViewMatrix());
        }
    }

}