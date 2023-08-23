using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;

struct Item //아이템 구조체
{
    public string name;
    public string effect;
    public string description;
    public bool install;
};
public class Class1
{
    private static Character player;
    private static List<Item> list = new List<Item>(); //생성된 아이템을 보관하는 리스트

    static void Main(string[] args)
    {
        MakePlayer();
        MakeItem();
        GameStart();
    }

    static void GameStart() //첫화면 출력
    {
        Console.Clear();
        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");

        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("1.상태 보기");
        Console.ResetColor();

        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("2.인벤토리");
        Console.ResetColor();

        Console.WriteLine("원하시는 행동을 입력해주세요.");
        int number;

        number = CheckValidInput(1, 2);
        if (number == 1)
        {
            ShowInfo();
        }
        else
        {
            //MakeItem();
            Inventory(list);
        }

    }

    static void ShowInfo() //상태보기 선택시 상태 출력
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("상태보기");
        Console.ResetColor();
        Console.WriteLine("캐릭터의 정보가 표시됩니다. \n");

        Console.WriteLine($"level : {player.Level}");
        Console.WriteLine($"직업 : {player.Job}");
        Console.Write($"공격력 : {player.AttackPower}  {player.AttackEffect} \n"); 
        Console.Write($"방어력 : {player.GuardPower}  {player.GuardEffect} \n"); 
        Console.WriteLine($"HP : {player.HP}");
        Console.WriteLine($"GOLD : {player.Gold}");
        Console.WriteLine();
        Console.WriteLine("0을 누르면 나가기");
        Console.WriteLine();

        int number = CheckValidInput(0, 0);
        if (number == 0)
        {
            GameStart();
        }

    }
    static void MakePlayer() //플레이어 객체 생성
    {
        player = new Character(1, "fighter", "50", "50", 100, 1500);
    }
    public class Character //플레이어를 생성가능한 클래스
    {
        public int Level { get; }
        public string Job { get; }
        public string AttackPower { get; }
        public string GuardPower { get; }
        public int HP { get; }
        public int Gold { get; }
        public bool Tool;
        public string AttackEffect;
        public string GuardEffect;


        public Character(int level, string job, string attackPower, string guardPower, int hp, int gold)
        {
            Level = level;
            Job = job;
            AttackPower = attackPower;
            GuardPower = guardPower;
            HP = hp;
            Gold = gold;
            Tool = false;
            AttackEffect = "";
            GuardEffect = "";
        }
    }

    static void MakeItem() //아이템 정보를 생산해 리스트에 추가
    {
        Item itm0;
        Item itm1;
        Item itm2;
        Item itm3;


        itm0.name = "무쇠갑옷";
        itm0.effect = "방어력+10";
        itm0.description = "무쇠로 만들어져 튼튼한 갑옷입니다.";
        itm0.install = false;

        itm1.name = "무쇠갑옷";
        itm1.effect = "방어력+10";
        itm1.description = "무쇠로 만들어져 튼튼한 갑옷입니다.";
        itm1.install = false;

        itm2.name = "낡은 검";
        itm2.effect = "공격력+10";
        itm2.description = "쉽게 볼 수 있는 낡은 검입니다.";
        itm2.install = false;

        itm3.name = "여신의 목걸이";
        itm3.effect = "공격력+10";
        itm3.description = "여신의 축복이 느껴집니다.";
        itm3.install = false;

        list.Add(itm0);
        list.Add(itm1);
        list.Add(itm2);
        list.Add(itm3);

    }
    


    static void Inventory( List<Item> item) //인벤토리 출력
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("인벤토리");
        Console.ResetColor();
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
        char ch = '+';

        for (int i = 1; i < item.Count; i++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(i + ".  ");
            if (item[i].install) //장착 여부 확인
            {
                Console.Write("[E]"); //장착 메세지 출력
                if (item[i].effect.Substring(0,3) == "공격력")
                {
                    player.AttackEffect = "(" + item[i].effect.Substring(item[i].effect.LastIndexOf(ch)) + ")"; // 아이템 고유호과 상태보기에서 추가 출력
                }else if (item[i].effect.Substring(0, 3) == "방어력")
                {
                    player.GuardEffect = "(" + item[i].effect.Substring(item[i].effect.LastIndexOf(ch)) + ")";
                }
            }
            else //장착중이 아니라면 고유효과 부여 안함
            {
                if (item[i].effect.Substring(0, 3) == "공격력")
                {
                    player.AttackEffect = "";
                }
                else if (item[i].effect.Substring(0, 3) == "방어력")
                {
                    player.GuardEffect = "";
                }
            }
            Console.Write(item[i].name + "      |  " ); 
            Console.Write(item[i].effect + "      |    "); 
            Console.WriteLine(item[i].description ); 
        }
        Console.ResetColor();
        Console.WriteLine("0번을 누르면 나가기");
        int number = CheckValidInput(0, item.Count-1);
        if(number == 0)
        {
            GameStart();
        }
        else // 장착여부를 아이템 리스트에 수정
        {
            Item temp = item[number];
            temp.install = !item[number].install;
            item[number] = temp; 
            Inventory(item);
        }

    }

    static int CheckValidInput(int min, int max)
    {
        while (true)
        {
            string input = Console.ReadLine();

            bool parseSuccess = int.TryParse(input, out var ret);
            if (parseSuccess)
            {
                if(ret >= min && ret <= max)
                    return ret;        
            }
            
            Console.WriteLine("잘못된 입력입니다.");
        }
    }
}

