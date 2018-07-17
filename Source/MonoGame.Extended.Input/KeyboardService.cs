using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGame.Extended.Input
{
    public class KeyboardService
    {
        public KeyboardState CurrentKeyboardState { get; private set; }
        public KeyboardState PreviousKeyboardState { get; private set; }

        public bool CapsLock => CurrentKeyboardState.CapsLock;
        public bool NumLock => CurrentKeyboardState.NumLock;
        public bool IsShiftDown() => CurrentKeyboardState.IsKeyDown(Keys.LeftShift) || CurrentKeyboardState.IsKeyDown(Keys.RightShift);
        public bool IsControlDown() => CurrentKeyboardState.IsKeyDown(Keys.LeftControl) || CurrentKeyboardState.IsKeyDown(Keys.RightControl);
        public bool IsAltDown() => CurrentKeyboardState.IsKeyDown(Keys.LeftAlt) || CurrentKeyboardState.IsKeyDown(Keys.RightAlt);
        public bool IsKeyDown(Keys key) => CurrentKeyboardState.IsKeyDown(key);
        public bool IsKeyUp(Keys key) => CurrentKeyboardState.IsKeyUp(key);
        public Keys[] GetPressedKeys() => CurrentKeyboardState.GetPressedKeys();

        public bool WasKeyJustDown(Keys key) => PreviousKeyboardState.IsKeyDown(key) && CurrentKeyboardState.IsKeyUp(key);
        public bool WasKeyJustUp(Keys key) => PreviousKeyboardState.IsKeyUp(key) && CurrentKeyboardState.IsKeyDown(key);
        public bool WasAnyKeyJustDown() => PreviousKeyboardState.GetPressedKeys().Any();

        public void Update(GameTime gameTime)
        {
            PreviousKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = Keyboard.GetState();
        }
    }
}