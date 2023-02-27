using SFML.Graphics;
using SFML.System;

namespace Square_11._7
{
    public class EnemySquare : Square
    {
        private static float MaxMomentSpeed = 10;
        private static float MovementStep = 0.4f;
        private static float MaxSize = 200;
        private static float SizeStep = 10;
        private Vector2f size = new Vector2f(100, 100); // Размер объекта

        public EnemySquare(Vector2f position, float movementSpeed, IntRect movementBounds, Texture texture)
            : base(position, movementSpeed, movementBounds, texture)
        {
            shape.Size = size;
        }
        protected override void OnClick()
        {
            Game.IsLost = true;    
        }

        protected override void OnReahedTarget()
        {
            if (movementSpeed < MaxMomentSpeed)
                movementSpeed += MovementStep;

            if (shape.Size.X < MaxSize)
                shape.Size += new Vector2f(SizeStep, SizeStep);
           
            if (shape.Size.X == MaxSize)
                Game.isBonus = false;
        }
    }
}
