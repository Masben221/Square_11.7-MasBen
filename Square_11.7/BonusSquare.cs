using SFML.Graphics;
using SFML.System;

namespace Square_11._7
{
    public class BonusSquare : Square
    {
        private static float SizeStep = 0.3f;
        private static float MaxSize = 100;
        private static float MinSize = 20;
        private Vector2f size = new Vector2f(100, 100); // Размер объекта

        public BonusSquare(Vector2f position, float movementSpeed, IntRect movementBounds, Texture texture)
            : base(position, movementSpeed, movementBounds, texture)
        {
            shape.Size = size;
        }
        protected override void OnClick()
        {
           Game.Scores+=5;
           Game.isBonus = true;          
           IsActive = false;
        }
       
        protected override void ReducingTheSizeBonus() // уменьшение размера бонуса
        {
           if (shape.Size.X <= MaxSize)
               shape.Size -= new Vector2f(SizeStep, SizeStep);

            if (shape.Size.X < MinSize)
            {                
                IsActive = false;
                return;
            }            
        }      
    }
}