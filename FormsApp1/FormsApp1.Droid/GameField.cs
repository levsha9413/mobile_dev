using System;
using Android.App;
using Android.Widget;
using Android.OS;
namespace AndroidBlankApp2
{
    public class GameField
    {
        private char[] gameFields = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        
        
        public void Show() //Метод для вывода игрового поля
        {
            const string line = "-+-+-";
            const string vert = "|";
            Console.WriteLine($"{gameFields[0]}{vert}{gameFields[1]}{vert}{gameFields[2]}");
            Console.WriteLine(line);
            Console.WriteLine($"{gameFields[3]}{vert}{gameFields[4]}{vert}{gameFields[5]}");
            Console.WriteLine(line);
            Console.WriteLine($"{gameFields[6]}{vert}{gameFields[7]}{vert}{gameFields[8]}");
        }

        public void setField(int num, char symbol)
        {
            this.gameFields[num - 1] = symbol;
        }
        
        public bool winnerIsExist()
        {
            if ((gameFields[0] == gameFields[1] && gameFields[1] == gameFields[2]) || //проверяем условия подеды
                (gameFields[3] == gameFields[4] && gameFields[4] == gameFields[5]) ||
                (gameFields[6] == gameFields[7] && gameFields[7] == gameFields[8]) ||
                (gameFields[0] == gameFields[3] && gameFields[3] == gameFields[6]) ||
                (gameFields[1] == gameFields[4] && gameFields[4] == gameFields[7]) ||
                (gameFields[2] == gameFields[5] && gameFields[5] == gameFields[8]) ||
                (gameFields[0] == gameFields[4] && gameFields[4] == gameFields[8]) ||
                (gameFields[2] == gameFields[4] && gameFields[4] == gameFields[6]))
            {
                return true;
            }

            return false;
        }

    }
}