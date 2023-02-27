using System;
using SFML.System;

namespace Square_11._7
{
    public static class Mathf
    {
        public static Random Random = new Random();

        public static Vector2f MoveTowards(Vector2f current, Vector2f target, float maxDistanceDelta)
        {
            Vector2f dir = target - current;
            float magnitude = (float) Math.Sqrt(dir.X * dir.X + dir.Y * dir.Y);

            if (magnitude <= maxDistanceDelta || magnitude == 0f)
            {
                return target;

            }
                return current + dir / magnitude * maxDistanceDelta;
        }
    }
}
