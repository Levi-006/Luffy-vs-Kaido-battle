
using System;

class Player
{
    public string playerName;
    public int playerHealth;
    public int playerDamage;

    public Player(string pName, int pHealth, int pDamage)
    {
        playerName = pName;
        playerHealth = pHealth;
        playerDamage = pDamage;
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;

        if (playerHealth < 0)
        {
            playerHealth = 0;
        }

        Console.WriteLine(
            $"{playerName} has been damaged {damage} and has health {playerHealth}"
        );
    }

    public void Attack()
    {
        Console.WriteLine($"{playerName} is attacking!");
    }
}

class Enemy
{
    public string enemyName;
    public int enemyHealth;
    public int enemyDamage;

    public Enemy(string eName, int eHealth, int eDamage)
    {
        enemyName = eName;
        enemyHealth = eHealth;
        enemyDamage = eDamage;
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth < 0)
        {
            enemyHealth = 0;
        }

        Console.WriteLine(
            $"{enemyName} has been damaged {damage} and has health {enemyHealth}"
        );
    }

    public void Attack()
    {
        Console.WriteLine($"{enemyName} is attacking!");
    }
}

class Program
{
    static void ShowMenu(bool available)
    {
        string status = available ? "Available" : "Used";

        Console.WriteLine("1. Normal Attack");
        Console.WriteLine($"2. Heavy Attack ({status})");
    }

    static int GetPlayerChoice()
    {
        while (true)
        {
            Console.Write("Choose your attack: ");

            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Please enter a number.");
                continue;
            }

            if (n == 1 || n == 2)
            {
                return n;
            }

            Console.WriteLine("Choose 1 or 2!");
        }
    }

    static void Main()
    {
        Player luffy = new Player("Luffy", 100, 40);
        Enemy kaido = new Enemy("Kaido", 150, 25);

        bool heavyAttackAvailable = true;

        while (luffy.playerHealth > 0 && kaido.enemyHealth > 0)
        {
            while (true)
            {
                ShowMenu(heavyAttackAvailable);

                int n = GetPlayerChoice();

                if (n == 1)
                {
                    luffy.playerDamage = 40;
                    break;
                }
                else if (n == 2 && heavyAttackAvailable)
                {
                    luffy.playerDamage = 70;
                    heavyAttackAvailable = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Heavy Attack has already been used!");
                }
            }

            luffy.Attack();
            kaido.TakeDamage(luffy.playerDamage);

            if (kaido.enemyHealth <= 0)
            {
                break;
            }

            kaido.Attack();
            luffy.TakeDamage(kaido.enemyDamage);
        }

        if (luffy.playerHealth == 0)
        {
            Console.WriteLine("Kaido won the battle!");
        }

        if (kaido.enemyHealth == 0)
        {
            Console.WriteLine("Luffy won the battle!");
        }
    }
}
