using SFML.Graphics;
using SFML.System;

namespace Square_11._7
{
    public class Square
    {
        public static Vector2f DefaultSize = new Vector2f(100, 100);        

        public bool IsActive = true; // Флаг жизни объекта

        protected RectangleShape shape;       

        protected float movementSpeed; // Скорость перемещения
        protected Vector2f movementTarget; // Позиция цели передвижения
        protected IntRect movementBounds; // Границы передвижения

        public Square(Vector2f position, float movementSpeed, IntRect movementBounds, Texture texture)
        {
            shape = new RectangleShape(DefaultSize);

            shape.Texture = texture;

            shape.Position = position;

            this.movementSpeed = movementSpeed;
            this.movementBounds = movementBounds;

            UpdateMovementTarget();
        }
        public void Move()
        {
            shape.Position = Mathf.MoveTowards(shape.Position, movementTarget, movementSpeed);
            
            if (shape.Position == movementTarget)
            {
                OnReahedTarget();

                UpdateMovementTarget();
            }

            ReducingTheSizeBonus();
        }

        // Отрисовка объекта
        public void Draw(RenderWindow win)
        {
            if (IsActive == false) return;

            win.Draw(shape);
        }

        // Проверка было ли попадание в объект
        public void CheckMousePosition(Vector2i mousePos)
        {
            if (IsActive == false) return;

            if (mousePos.X > shape.Position.X && mousePos.X < shape.Position.X + shape.Size.X &&
                mousePos.Y > shape.Position.Y && mousePos.Y < shape.Position.Y + shape.Size.Y)
                
                // Обработка нажатия
                OnClick();
        }

        // Обновление позиции цели
        protected void UpdateMovementTarget()
        {
            movementTarget.X = Mathf.Random.Next(movementBounds.Left, movementBounds.Left + movementBounds.Width);
            movementTarget.Y = Mathf.Random .Next(movementBounds.Top, movementBounds.Top + movementBounds.Height);
        }

        // Обработка нажатия
        protected virtual void OnClick() { }

        // Перенацеливание врага
        protected virtual void OnReahedTarget() { }

        // Уменьшение бонусного квадрата
        protected virtual void ReducingTheSizeBonus() { }
        
        // Задание размера
        public void SetSize(Vector2f size)
        {
            shape.Size = size;
        }

        // Задание скорости
        public void SetSpeed(int speed)
        {
            movementSpeed = speed;
        }    
    }
}
