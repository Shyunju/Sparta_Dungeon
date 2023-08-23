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
    private static List<Item> list = new List<Item>();
    //private static Item[] array = Array.Empty<Item>();

    static void Main(string[] args)
    {
        MakePlayer();
        MakeItem();
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
        }
        else
        {
            //MakeItem();
            Inventory(list);
        }

    }

    static void ShowInfo()
    {
        Console.Clear();
        Console.WriteLine("상태보기");
        Console.WriteLine("캐릭터의 정보가 표시됩니다. \n");

        Console.WriteLine($"level : {player.Level}");
        Console.WriteLine($"직업 : {player.Job}");
        Console.Write($"공격력 : {player.AttackPower}  "); Console.WriteLine( player.AttackEffect);
        Console.Write($"방어력 : {player.GuardPower}"); Console.WriteLine(player.GuardEffect);
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
        player = new Character(1, "fighter", "50", "50", 100, 1500);
    }
    public class Character
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

        //List<Item> list = new List<Item>();
        list.Add(itm0);
        list.Add(itm1);
        list.Add(itm2);
        //array = list.ToArray();

    }


static void Inventory( List<Item> item)
    {
        Console.Clear();
        Console.WriteLine("인벤토리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
        char ch = '+';

        for (int i = 1; i < item.Count; i++)
        {
            Console.Write(i + ".  ");
            if (item[i].install)
            {
                Console.Write("[E]");
                if (item[i].effect.Substring(0,3) == "공격력")
                {
                    player.AttackEffect = "(" + item[i].effect.Substring(item[i].effect.LastIndexOf(ch)) + ")";
                }else if (item[i].effect.Substring(0, 3) == "방어력")
                {
                    player.GuardEffect = "(" + item[i].effect.Substring(item[i].effect.LastIndexOf(ch)) + ")";
                }
            }
            else
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
            Console.Write(item[i].name + "      |    " ); 
            Console.Write(item[i].effect + "      |    "); 
            Console.WriteLine(item[i].description ); 
        }
        Console.WriteLine("0번을 누르면 나가기");
        int number = CheckValidInput(0, item.Count-1);
        if(number == 0)
        {
            GameStart();
        }
        else
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

