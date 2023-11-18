using System;
namespace ConsoleApplication;

public class Game
{
    private char[] GameFields = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    private int GameMoveNumber = 1;
    private int ActiveGamer;
    private char GameSymbol;
    
    public void ShowGameField() //Метод для вывода игрового поля
    {
        const string line = "-+-+-";
        const string vert = "|";
        Console.WriteLine($"{GameFields[0]}{vert}{GameFields[1]}{vert}{GameFields[2]}");
        Console.WriteLine(line);
        Console.WriteLine($"{GameFields[3]}{vert}{GameFields[4]}{vert}{GameFields[5]}");
        Console.WriteLine(line);
        Console.WriteLine($"{GameFields[6]}{vert}{GameFields[7]}{vert}{GameFields[8]}");
    }

    public void GameMove(int mv)
    {
        if (mv % 2 == 0)
        {
            ActiveGamer = 2; //четные ходы для 2-го игрока
            GameSymbol = 'o'; //ходит ноликами 

        }
        else
        {
            ActiveGamer = 1; //нечетные для 1-го игрока
            GameSymbol = 'X'; //ходит крестиками 
        }

        
        int gameField;
        Console.WriteLine("Игрок " + ActiveGamer + " выберите свободную клетку (вводом цифры): ");
        gameField = Convert.ToInt32(Console.ReadLine()); //to do: сделать обработку исключений на случай если ввел не число
        GameFields[gameField - 1] = GameSymbol; //ставим игровой символ в выбранную клетку

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
            Console.WriteLine("Игрок " + ActiveGamer + " Победил!");
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
            if (winnerIsExist(GameFields))
            {
                return;
            }
        }
        Console.WriteLine("Нечья");
    }
}

