using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace Square_11._7
{
    class Menu
    {
        private bool isDown;
        private Text text;
        private Vector2f textPos = new Vector2f(100, 70);
        private Font font;
        
        private List<Texture> enemyTextures;       
      
        private uint textSize = 35;
        private Color textColor = new Color(74, 133, 184);        

        public Menu()
        {
            text = new Text();
            font = new Font("comic.ttf");
            text.CharacterSize = textSize;
            text.Font = font;
            text.Position = textPos;
            text.FillColor = textColor;
            text.DisplayedString = $"Нажми 1, 2, или 3 для выбора врага";
           
            enemyTextures = new List<Texture>();                              
        }

        public void Start(RenderWindow window)
        {

            for (int i = 0; i < 3; i++)
            {
                enemyTextures.Add(new Texture($"Bomb_{i}.png"));
            }            

            //Очистка экрана
            window.Clear(Color.Black);

            window.DispatchEvents();

            // Вывод в буфер.

            window.Draw(text);

            // Вывод на экран из буфера
            window.Display();

            while (!isDown)
            {
                // Проверка на нажатие клавиши Num1
                if (Keyboard.IsKeyPressed(Keyboard.Key.Num1) == true)
                {
                     SquaresList.TextureEnemy = enemyTextures[0];
                    isDown = true;
                }
                // Проверка на нажатие клавиши Num2
                if (Keyboard.IsKeyPressed(Keyboard.Key.Num2) == true)
                {
                     SquaresList.TextureEnemy = enemyTextures[1];
                    isDown = true;
                }
                // Проверка на нажатие клавиши Num3
                if (Keyboard.IsKeyPressed(Keyboard.Key.Num3) == true)
                {                    
                    SquaresList.TextureEnemy = enemyTextures[2];
                    isDown = true;
                }       
            }

            SquaresList.TexturePlayer = new Texture("Coin.png");
            SquaresList.TextureBonus = new Texture("Bonus.png");
        }     

    }
}

