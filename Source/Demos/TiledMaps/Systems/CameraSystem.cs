using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.Input;

namespace TiledMaps.Systems
{
    public class CameraSystem : UpdateSystem
    {
        private readonly OrthographicCamera _camera;
        private readonly KeyboardService _keyboardService;
        private readonly MouseService _mouseService;

        public CameraSystem(OrthographicCamera camera, KeyboardService keyboardService, MouseService mouseService)
        {
            _camera = camera;
            _keyboardService = keyboardService;
            _mouseService = mouseService;
        }

        private const float _cameraSpeed = 100;

        public override void Update(GameTime gameTime)
        {
            var elapsedSeconds = gameTime.GetElapsedSeconds();

            if (_keyboardService.IsKeyDown(Keys.Left))
                _camera.Move(new Vector2(-_cameraSpeed, 0) * elapsedSeconds);

            if (_keyboardService.IsKeyDown(Keys.Right))
                _camera.Move(new Vector2(_cameraSpeed, 0) * elapsedSeconds);

            if (_keyboardService.IsKeyDown(Keys.Up))
                _camera.Move(new Vector2(0, -_cameraSpeed) * elapsedSeconds);

            if (_keyboardService.IsKeyDown(Keys.Down))
                _camera.Move(new Vector2(0, _cameraSpeed) * elapsedSeconds);

            _camera.ZoomOut(_mouseService.DeltaScrollWheelValue * 0.001f);
        }
    }
}