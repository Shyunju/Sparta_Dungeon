using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;

struct Item
{
    public string name;
    public string effect;
    public string description;
    public bool install;
};
public class Class1
{
    private static Character player;

    static void Main(string[] args)
    {
        MakePlayer();
        //MakeItem();
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
        int number;

        number = CheckValidInput(1, 2);
        if (number == 1)
        {
            ShowInfo();
            //Console.WriteLine("상태보기");
            //상태보기 함수 호출
        }
        else
        {
            MakeItem();
            //Console.WriteLine("인벤토리");
            //인벤토리 함수 호출
        }

    }

    static void ShowInfo()
    {
        Console.Clear();
        Console.WriteLine("상태보기");
        Console.WriteLine("캐릭터의 정보가 표시됩니다. \n");

        Console.WriteLine($"level : {player.Level}");
        Console.WriteLine($"직업 : {player.Job}");
        Console.WriteLine($"공격력 : {player.AttackPower}");
        Console.WriteLine($"방어력 : {player.GuardPower}");
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
    static void MakePlayer()
    {
        player = new Character(1, "fighter", 50, 50, 100, 1500);
    }
    public class Character
    {
        public int Level { get; }
        public string Job { get; }
        public int AttackPower { get; }
        public int GuardPower { get; }
        public int HP { get; }
        public int Gold { get; }

        public Character(int level, string job, int attackPower, int guardPower, int hp, int gold)
        {
            Level = level;
            Job = job;
            AttackPower = attackPower;
            GuardPower = guardPower;
            HP = hp;
            Gold = gold;
        }
    }

    static void MakeItem()
    {
        Item itm0;
        Item itm1;
        Item itm2;

        itm0.name = "무쇠갑옷";
        itm0.effect = "방어력+2";
        itm0.description = "무쇠로 만들어져 튼튼한 갑옷입니다.";
        itm0.install = false;

        itm1.name = "무쇠갑옷";
        itm1.effect = "방어력+2";
        itm1.description = "무쇠로 만들어져 튼튼한 갑옷입니다.";
        itm1.install = false;

        itm2.name = "낡은 검";
        itm2.effect = "공격력+2";
        itm2.description = "쉽게 볼 수 있는 낡은 검입니다.";
        itm2.install = false;

        List<Item> list = new List<Item>();
        list.Add(itm0);
        list.Add(itm1);
        list.Add(itm2);
        Item[] items = list.ToArray();
        //Item[] items = {  };
        //Item[] items = Array.Empty<Item>();
        //items[0].name = "asdf"; items[0].effect = "qwer"; items[0].description = "poui"; items[0].install = false;
        //items[0] = itm0;
        //items[1] = itm1;
        //items[2] = itm2;

        Inventory(items);
    }


static void Inventory( Item[] item)
    {
        Console.Clear();
        Console.WriteLine("인벤토리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

        for (int i = 1; i < item.Length; i++)
        {
            Console.Write(i + ".  ");
            if (item[i].install)
            {
                Console.Write("[E]");
            }
            Console.Write(item[i].name + "      |    " ); 
            Console.Write(item[i].effect + "      |    "); 
            Console.WriteLine(item[i].description ); 
        }
        Console.WriteLine("0번을 누르면 나가기");
        int number = CheckValidInput(0, item.Length-1);
        if(number == 0)
        {
            GameStart();
        }
        else
        {
            item[number].install = !item[number].install;
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

