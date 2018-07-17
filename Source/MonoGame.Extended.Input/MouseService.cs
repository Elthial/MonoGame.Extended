using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGame.Extended.Input
{
    public class MouseService
    {
        public MouseState CurrentMouseState { get; private set; }
        public MouseState PreviousMouseState { get; private set; }

        public void SetPosition(int x, int y) => Mouse.SetPosition(x, y);
        public void SetPosition(Point point) => Mouse.SetPosition(point.X, point.Y);
        public void SetCursor(MouseCursor cursor) => Mouse.SetCursor(cursor);

        public IntPtr WindowHandle
        {
            get => Mouse.WindowHandle;
            set => Mouse.WindowHandle = value;
        }

        public int X => CurrentMouseState.X;
        public int Y => CurrentMouseState.Y;
        public Point Position => CurrentMouseState.Position;
        public bool PositionChanged => CurrentMouseState.Position != PreviousMouseState.Position;

        public int DeltaX => PreviousMouseState.X - CurrentMouseState.X;
        public int DeltaY => PreviousMouseState.Y - CurrentMouseState.Y;
        public Point DeltaPosition => new Point(DeltaX, DeltaY);

        public int ScrollWheelValue => CurrentMouseState.ScrollWheelValue;
        public int DeltaScrollWheelValue => PreviousMouseState.ScrollWheelValue - CurrentMouseState.ScrollWheelValue;

        public ButtonState LeftButton => CurrentMouseState.LeftButton;
        public ButtonState MiddleButton => CurrentMouseState.MiddleButton;
        public ButtonState RightButton => CurrentMouseState.RightButton;
        public ButtonState XButton1 => CurrentMouseState.XButton1;
        public ButtonState XButton2 => CurrentMouseState.XButton2;

        public bool IsButtonDown(MouseButton button)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (button)
            {
                case MouseButton.Left: return IsPressed(m => m.LeftButton);
                case MouseButton.Middle: return IsPressed(m => m.MiddleButton);
                case MouseButton.Right: return IsPressed(m => m.RightButton);
                case MouseButton.XButton1: return IsPressed(m => m.XButton1);
                case MouseButton.XButton2: return IsPressed(m => m.XButton2);
            }

            return false;
        }

        public bool IsButtonUp(MouseButton button)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (button)
            {
                case MouseButton.Left: return IsReleased(m => m.LeftButton);
                case MouseButton.Middle: return IsReleased(m => m.MiddleButton);
                case MouseButton.Right: return IsReleased(m => m.RightButton);
                case MouseButton.XButton1: return IsReleased(m => m.XButton1);
                case MouseButton.XButton2: return IsReleased(m => m.XButton2);
            }

            return false;
        }

        public bool WasButtonJustDown(MouseButton button)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (button)
            {
                case MouseButton.Left: return WasJustPressed(m => m.LeftButton);
                case MouseButton.Middle: return WasJustPressed(m => m.MiddleButton);
                case MouseButton.Right: return WasJustPressed(m => m.RightButton);
                case MouseButton.XButton1: return WasJustPressed(m => m.XButton1);
                case MouseButton.XButton2: return WasJustPressed(m => m.XButton2);
            }

            return false;
        }

        public bool WasButtonJustUp(MouseButton button)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (button)
            {
                case MouseButton.Left: return WasJustReleased(m => m.LeftButton);
                case MouseButton.Middle: return WasJustReleased(m => m.MiddleButton);
                case MouseButton.Right: return WasJustReleased(m => m.RightButton);
                case MouseButton.XButton1: return WasJustReleased(m => m.XButton1);
                case MouseButton.XButton2: return WasJustReleased(m => m.XButton2);
            }

            return false;
        }

        private bool IsPressed(Func<MouseState, ButtonState> button) => button(CurrentMouseState) == ButtonState.Pressed;
        private bool IsReleased(Func<MouseState, ButtonState> button) => button(CurrentMouseState) == ButtonState.Released;
        private bool WasJustPressed(Func<MouseState, ButtonState> button) => button(PreviousMouseState) == ButtonState.Released && button(CurrentMouseState) == ButtonState.Pressed;
        private bool WasJustReleased(Func<MouseState, ButtonState> button) => button(PreviousMouseState) == ButtonState.Pressed && button(CurrentMouseState) == ButtonState.Released;

        public void Update(GameTime gameTime)
        {
            PreviousMouseState = CurrentMouseState;
            CurrentMouseState = Mouse.GetState();
        }
    }
}