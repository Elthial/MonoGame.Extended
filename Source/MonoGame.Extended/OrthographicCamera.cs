using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ViewportAdapters;

namespace MonoGame.Extended
{
    public class OrthographicCamera : Camera
    {
        public OrthographicCamera(GraphicsDevice graphicsDevice)
            : this(new DefaultViewportAdapter(graphicsDevice))
        {
        }

        public OrthographicCamera(ViewportAdapter viewportAdapter)
            : base(viewportAdapter)
        {
        }
    }
}