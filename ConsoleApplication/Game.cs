using System;
namespace ConsoleApplication;

public class Game
{
    private char[] gameFields = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    private int gameMoveNumber = 1;
    private int activeGamer;
    private char gameSymbol;
    
    public void ShowGameField() //Метод для вывода игрового поля
    {
        const string line = "-+-+-";
        const string vert = "|";
        Console.WriteLine($"{gameFields[0]}{vert}{gameFields[1]}{vert}{gameFields[2]}");
        Console.WriteLine(line);
        Console.WriteLine($"{gameFields[3]}{vert}{gameFields[4]}{vert}{gameFields[5]}");
        Console.WriteLine(line);
        Console.WriteLine($"{gameFields[6]}{vert}{gameFields[7]}{vert}{gameFields[8]}");
    }

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
        gameFields[gameField - 1] = gameSymbol; //ставим игровой символ в выбранную клетку

    }

    private bool winnerIsExist(char[] fields)
    {
        if ((fields[0] == fields[1] && fields[1] == fields[2]) || //проверяем условия подеды
            (fields[3] == fields[4] && fields[4] == fields[5]) ||
            (fields[6] == fields[7] && fields[7] == fields[8]) ||
            (fields[0] == fields[3] && fields[3] == fields[6]) ||
            (fields[1] == fields[4] && fields[4] == fields[7]) ||
            (fields[2] == fields[5] && fields[5] == fields[8]) ||
            (fields[0] == fields[4] && fields[4] == fields[8]) ||
            (fields[2] == fields[4] && fields[4] == fields[6]))
        {
            Console.WriteLine("Игрок " + activeGamer + " Победил!");
            return true;
        }

        return false;
    }

    public void Start()
    {
        ShowGameField();
        for (int gameHop = 1; gameHop < 10; gameHop++)
        {
            
            GameMove(gameHop);
            Console.Clear();
            ShowGameField();
            if (winnerIsExist(gameFields))
            {
                return;
            }
        }
        Console.WriteLine("Ничья");
    }
}

