using System;
using System.Security.Permissions;

public class Class1
{
	static void Main(string[] args)
	{
		GameStart();

		
        
    }

	static void GameStart()
	{
		Console.Clear();
        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");

        Console.WriteLine("1.상태 보기");
        Console.WriteLine("2.인벤토리");

        Console.WriteLine("원하시는 행동을 입력해주세요.");
        string input = Console.ReadLine();
        int key = (int)input;

        

        

        while (key) {
            if (key == 1) 
            {
                Console.WriteLine("상태보기");
                //상태보기 함수 호출
                break;
            }
            else if (key == 2)
            {
                Console.WriteLine("인벤토리");
                //인벤토리 함수 호출
                break;
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다 다시 입력해주세요.");
                input = Console.Read();
                key = (int)input;
            }
        }
    }
}
