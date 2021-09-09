using Microsoft.Xna.Framework;

namespace SpaceMiner
{
    public class Pixel
    {
        public Vector2 position;
        public Vector2 velocity;
        public Color color;

        public Pixel(Vector2 position, Vector2 velocity, Color color)
        {
            this.position = position;
            this.velocity = velocity;
            this.color = color;
        }
    }
}
