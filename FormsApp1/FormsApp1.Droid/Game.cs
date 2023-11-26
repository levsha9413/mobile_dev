using System;
namespace AndroidBlankApp2
{
    public class Game
    {
        
        private int gameMoveNumber = 1;
        private int activeGamer;
        private char gameSymbol;
        private GameField gameBoard = new GameField();
    
    

    public void GameMove(int mv)
    {
        if (mv % 2 == 0)
        {
            activeGamer = 2; //четные ходы для 2-го игрока
            gameSymbol = 'o'; //ходит ноликами 

        }
        else
        {
            activeGamer = 1; //нечетные для 1-го игрока
            gameSymbol = 'X'; //ходит крестиками 
        }

        
        int gameField;
        Console.WriteLine("Игрок " + activeGamer + " выберите свободную клетку (вводом цифры): ");
        gameField = Convert.ToInt32(Console.ReadLine()); //to do: сделать обработку исключений на случай если ввел не число
        gameBoard.setField(gameField, gameSymbol); //ставим игровой символ в выбранную клетку

    }

    

    public void Start()
    {
        gameBoard.Show();
        for (int gameHop = 1; gameHop < 10; gameHop++)
        {
            
            GameMove(gameHop);
            Console.Clear();
            gameBoard.Show();
            if (gameBoard.winnerIsExist())
            {   
                Console.WriteLine("Игрок " + activeGamer + " Победил!");
                return;
            }
        }
        Console.WriteLine("Ничья");
    }
    }
}