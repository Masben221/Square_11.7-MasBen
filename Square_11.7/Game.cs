using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Square_11._7
{
    public class Game
    {
        public static int Scores;
        public static bool IsLost;
        public static bool isBonus = false; // Флаг активации бонуса.
        
        private Font mainFont;
        private Text scoreText;
        private Text loseText;

        private SquaresList squares;

        private int MaxScores;

        Menu menu = new Menu();
        public Game()
        {
            mainFont = new Font("comic.ttf");
            squares = new SquaresList();

            scoreText = new Text();
            scoreText.Font = mainFont;
            scoreText.FillColor = Color.Black;
            scoreText.CharacterSize = 16;
            scoreText.Position = new Vector2f(10, 10);

            loseText = new Text();
            loseText.Font = mainFont;
            loseText.FillColor = Color.Black;
            loseText.DisplayedString = "Ты Проиграл! Нажми R чтобы перезапустить игру!";
            loseText.Position = new Vector2f(20, 250);   
        }

        public void Reset()
        {
            // Сброс списка объектов
            squares.ResetSquarestList();
            Scores = 0;
            IsLost = false;

            // Создание новых объектов
            squares.SpawnPlayerSquare();
            squares.SpawnPlayerSquare();
            squares.SpawnPlayerSquare();

            squares.SpawnEnemySquare();
            squares.SpawnEnemySquare();
            squares.SpawnEnemySquare();

            squares.SpawnTimeBonus();
        }        

        // Обновление
        public void Update(RenderWindow win)
        {
            // Проверка на проигрыш
            if (IsLost == true)
            {
                // Отрисовка текста
                win.Draw(loseText);

                // Проверка на максимальный счет
                if (Scores > MaxScores)
                    MaxScores = Scores;

                // Проверка на нажатие клавиши R
                if (Keyboard.IsKeyPressed(Keyboard.Key.R) == true)
                {
                    // Перезапуск игры.                   
                    Reset();
                }
            }

            if(IsLost == false)
            {
                // Обновление
                squares.Update(win);                

                // Проверка был ли удален объект
                if (squares.SquareHasRemoved == true)
                {
                    // Если объект относится к игровым квадратам, то создать новый квадрат
                    if (squares.RemovedSquare is PlayerSquare)
                    {
                        squares.SpawnPlayerSquare();
                    }
                    // Если объект относится к бонусным квадратам, то создать новый квадрат
                    if (squares.RemovedSquare is BonusSquare)
                    {
                        squares.SpawnTimeBonus();
                    }
                }
                // Если бонус был использован.
                if (isBonus)
                {
                    squares.EnemyResetSize(); 
                    isBonus = false;
                }
            }

            scoreText.DisplayedString = "Score: " + Scores.ToString() + "\nMax: " + MaxScores.ToString();
            win.Draw(scoreText);
        }
    }
}
