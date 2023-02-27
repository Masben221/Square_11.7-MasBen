using System;
using System.Collections.Generic;
using System.Threading;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Square_11._7
{
    public class SquaresList
    {
        private List<Square> squares; // Список объектов
        private Vector2f size = new Vector2f(80, 80); // Размер объекта

        public bool SquareHasRemoved; // Флаг на удаление объекта
        public Square RemovedSquare; // Запоминает последний удаленный объект
       
        public static Texture TexturePlayer; 
        public static Texture TextureEnemy; 
        public static Texture TextureBonus;

        public SquaresList()
        {            
            squares = new List<Square>();
        }
        // Сброс списка объектов.
        public void ResetSquarestList()
        {
            SquareHasRemoved = false;
            RemovedSquare = null;

            squares.Clear();
        }
        public void Update(RenderWindow win)
        {
            SquareHasRemoved = false;
            RemovedSquare = null;

            if (Mouse.IsButtonPressed(Mouse.Button.Left) == true)
            {
                for (int i = 0; i < squares.Count; i++)
                {
                    squares[i].CheckMousePosition(Mouse.GetPosition(win));
                }
            }
            for (int i = 0; i < squares.Count; i++)
            {
                squares[i].Move();
                squares[i].Draw(win);

                if(squares[i].IsActive == false)
                {
                    RemovedSquare = squares[i];

                    squares.Remove(squares[i]);

                    SquareHasRemoved = true;
                }
            }
        }
        // Создает игровой квадрат
        public void SpawnPlayerSquare()
        {
            squares.Add(new PlayerSquare(new Vector2f(Mathf.Random.Next(0, 800), (Mathf.Random.Next(0, 600))), 5, new IntRect(0, 0, 800, 600), TexturePlayer));
        }
        // Создает вражеский квадрат
        public void SpawnEnemySquare()
        {
            squares.Add(new EnemySquare(new Vector2f(Mathf.Random.Next(0, 800), (Mathf.Random.Next(0, 600))), 5, new IntRect(0, 0, 800, 600), TextureEnemy));
        }
        // Создает бонус
        public void SpawnBonusSquare()
        {
            squares.Add(new BonusSquare(new Vector2f(Mathf.Random.Next(0, 800), (Mathf.Random.Next(0, 600))), 10, new IntRect(0, 0, 800, 600), TextureBonus));
        }
               
        // Сброс размера врага.
        public void EnemyResetSize()
        {
            for (int i = 0; i < squares.Count; i++)
            {
                if (squares[i] is EnemySquare)
                {
                    squares[i].SetSize(size);
                    squares[i].SetSpeed(3);
                }
            }
        }
        public void SpawnTimeBonus()
        {
            Timer BonusTimerSquare = new Timer(ActionSpawnBonus, null, 10000, 10000);
        }

        private void ActionSpawnBonus(Object obj)
        {
          SpawnBonusSquare();
        }
    }
}
