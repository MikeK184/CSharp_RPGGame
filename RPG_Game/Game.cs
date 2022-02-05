using RPG_Game;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Collections.Generic;



internal class Game
{
    private Player CurrentPlayer;
    private Character CurrentEnemy;
    private List<Character> Enemies;

    // Constructor
    public Game()
    {
        
        Ant fireAuntie = new Ant("Fire Auntie", 10, ConsoleColor.Red, 3);
        
        // Hades and its objects below
        Item shuriken = new Item("Shuriken", 10);
        Ant hades = new Ant("Hades", 30, ConsoleColor.Blue, 6);
        hades.PickUpItem(shuriken);
        

        Bee bumbleBee = new Bee("BumbleBee", 25, ConsoleColor.DarkYellow, true);

        // Polymorphism
        Enemies = new List<Character>() { fireAuntie, hades, bumbleBee};

    }



    // Methods below
    public void RunGame()
    {

        // Why the fuck is it a rutime error without the Into?
        RunIntor();

        for (int i = 0; i < Enemies.Count; i += 1)
        {
            CurrentEnemy = Enemies[i];
            IntroCurrentEnemy();
            BattleCurrentEnemy();

            if (CurrentPlayer.isDead)
            {
                WaitForKey();
                break;
            }
            else if (CurrentEnemy.isDead)
            {
                WriteLine($"You defeated {CurrentEnemy.Name}!");
                WaitForKey();
            }

        }
        // CurrentPlayer.TakeDamage(1000);
        RunGameOver();
        WaitForKey();

    }

    private void RunIntor()
    {
        WriteLine("#### RPG_GAME ####");

        CurrentPlayer = new Player("Markus", 42, ConsoleColor.Green);
        ForegroundColor = ConsoleColor.Green;
        WriteLine($"Are you ready to fight? You've got {Enemies.Count}x enemies to face...\n");
        ResetColor();
        CurrentPlayer.DisplayInfo();
        WaitForKey();
    }
    private void RunGameOver()
    {
        Clear();
        if (CurrentPlayer.isDead)
        {
            // https://ascii.co.uk/art/death
            WriteLine(@"You lost, 
               ...
             ;::::;
           ;::::; :;
         ;:::::'   :;
        ;:::::;     ;.
       ,:::::'       ;           OOO\
       ::::::;       ;          OOOOO\
       ;:::::;       ;         OOOOOOOO
      ,;::::::;     ;'         / OOOOOOO
    ;:::::::::`. ,,,;.        /  / DOOOOOO
  .';:::::::::::::::::;,     /  /     DOOOO
 ,::::::;::::::;;;;::::;,   /  /        DOOO
;`::::::`'::::::;;;::::: ,#/  /          DOOO
:`:::::::`;::::::;;::: ;::#  /            DOOO
::`:::::::`;:::::::: ;::::# /              DOO
`:`:::::::`;:::::: ;::::::#/               DOO
 :::`:::::::`;; ;:::::::::##                OO
 ::::`:::::::`;::::::::;:::#                OO
 `:::::`::::::::::::;'`:;::#                O
  `:::::`::::::::;' /  / `:#
   ::::::`:::::;'  /  /   `#");
        }
        else
        {
            // Why does this not work? But normal text works?
            WriteLine(@"⢸⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⡷⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠢⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠈⠑⢦⡀⠀⠀⠀⠀⠀
⢸⠀⠀⠀⠀⢀⠖⠒⠒⠒⢤⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠙⢦⡀⠀⠀⠀⠀
⢸⠀⠀⣀⢤⣼⣀⡠⠤⠤⠼⠤⡄⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠙⢄⠀⠀⠀⠀
⢸⠀⠀⠑⡤⠤⡒⠒⠒⡊⠙⡏⠀⢀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠑⠢⡄⠀
⢸⠀⠀⠀⠇⠀⣀⣀⣀⣀⢀⠧⠟⠁⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀
⢸⠀⠀⠀⠸⣀⠀⠀⠈⢉⠟⠓⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸
⢸⠀⠀⠀⠀⠈⢱⡖⠋⠁⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸
⢸⠀⠀⠀⠀⣠⢺⠧⢄⣀⠀⠀⣀⣀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸
⢸⠀⠀⠀⣠⠃⢸⠀⠀⠈⠉⡽⠿⠯⡆⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸
⢸⠀⠀⣰⠁⠀⢸⠀⠀⠀⠀⠉⠉⠉⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸
⢸⠀⠀⠣⠀⠀⢸⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸
⢸⠀⠀⠀⠀⠀⢸⠀⢇⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸
⢸⠀⠀⠀⠀⠀⡌⠀⠈⡆⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸
⢸⠀⠀⠀⠀⢠⠃⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸
⢸⠀⠀⠀⠀⢸⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠷");
        }
    }
    private void IntroCurrentEnemy()
    {
        Clear();
        ForegroundColor = CurrentEnemy.Color;
        WriteLine($"You are about to fight {CurrentEnemy.Name}");
        ResetColor();
        CurrentEnemy.DisplayInfo();
        WriteLine();

        WaitForKey();

    }

    private void BattleCurrentEnemy()
    {
        while (CurrentEnemy.isAlive && CurrentEnemy.isAlive)
        {
            Clear();
            CurrentPlayer.DisplayHealthBar();
            CurrentEnemy.DisplayHealthBar();
            WriteLine();

            CurrentPlayer.Fight(CurrentEnemy);

            if (CurrentEnemy.isDead || CurrentPlayer.isDead)
            {
                break;
            }

            WriteLine();
            WaitForKey();

            Clear();
            CurrentPlayer.DisplayHealthBar();
            CurrentEnemy.DisplayHealthBar();
            WriteLine();

            CurrentEnemy.Fight(CurrentPlayer);
            WaitForKey();
        }
    }

    public void WaitForKey()
    {
        WriteLine("Press anything to continue ...\n");
        ReadKey(true);
    }
}