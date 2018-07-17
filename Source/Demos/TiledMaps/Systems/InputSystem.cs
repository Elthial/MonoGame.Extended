using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.Input;

namespace TiledMaps.Systems
{
    public class InputSystem : UpdateSystem
    {
        private readonly MouseService _mouseService;
        private readonly KeyboardService _keyboardService;

        public InputSystem(MouseService mouseService, KeyboardService keyboardService)
        {
            _mouseService = mouseService;
            _keyboardService = keyboardService;
        }

        public override void Update(GameTime gameTime)
        {
            _mouseService.Update(gameTime);
            _keyboardService.Update(gameTime);
        }
    }
}