using SFML.Graphics;
using SFML.System;

namespace Square_11._7
{
    public class PlayerSquare : Square
    {
        private static float SizeStep = 10;
        private static float MinSize = 30;
        private Vector2f size = new Vector2f(100, 100); // Размер объекта

        public PlayerSquare(Vector2f position, float movementSpeed, IntRect movementBounds, Texture texture)
            : base(position, movementSpeed, movementBounds, texture)
        {
            shape.Size = size;
        }

        protected override void OnClick()
        {
            Game.Scores++;

            shape.Size -= new Vector2f(SizeStep, SizeStep);

            if (shape.Size.X < MinSize)
            {
                IsActive = false;
                return;
            }

            // Обновление позиции объекта
            UpdateMovementTarget();
            shape.Position = movementTarget;
        }
    }
}
