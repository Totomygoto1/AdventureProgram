using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Adventure
{

    class Hero
    {
        public string name;
        public int heroHealth;
        public int heroGold;
        public int heroShield;
        public int heroHelmet;
        public int heroArmour;
        public int heroWeapon;
        public Hero()
        {
            //Console.WriteLine("Hero created .. ");
        }
        public Hero(string nam)
        {
            name = nam;
            heroHealth = 3;
            heroGold = 20;
            heroWeapon = 3;
            heroShield = 2;
            heroHelmet = 0;
            heroArmour = 0;
        }
    }

    class Monster
    {
        public string name;
        public int monsterHealth;
        public int monsterAttackMin;
        public int monsterAttackMax;
        public int minGold;
        public int maxGold;
        public Monster()
        {
            //Console.WriteLine("Monster created .. ");
        }
        public Monster(string nam)
        {
            name = nam;
            monsterHealth = 5;
            monsterAttackMin = 3;
            monsterAttackMax = 4;
            minGold = 2;
            maxGold = 4;
        }

    }

    class Weapon : Protection
    {
        public string name;
        public int costGold;
        public int weaponStrength;
        // check min and max - just take off 2 on max, store 1 variable

        public Weapon(int hitp, string nam) : base(hitp)
        {
            name = nam;
            costGold = 2;
            weaponStrength = 3;

        }

        public override void Protectionpoint()
        {
            this.hitpoint = hitpoint + weaponStrength;
        }

    }

    class Shield : Protection
    {
        public string name;
        public int costGold;
        public int shieldStrength;
        // check min and max - just take off 2 on max, store 1 variable

        public Shield(int hitp, string nam) : base(hitp)
        {
            name = nam;
            costGold = 2;
            shieldStrength = 2;
        }

        public override void Protectionpoint()
        {
            this.hitpoint = hitpoint + shieldStrength;
        }

    }

    class Protection
    {
        public int hitpoint;
        public Protection(int hitp)
        {
            hitpoint = hitp;
        }
        public virtual void Protectionpoint()
        {

        }
    }
    class Game
    {
        // fill arrays - monsters / weapons / shields

        List<Monster> arrMonster = new List<Monster>
        {
            new Monster() { name = "An Ugly Troll", monsterHealth = 2, monsterAttackMin = 3, monsterAttackMax = 4, minGold = 2, maxGold = 4 },
            new Monster() { name = "A Humoungous Giant", monsterHealth = 4, monsterAttackMin = 3, monsterAttackMax = 4, minGold = 2, maxGold = 4 },
            new Monster() { name = "A Huge Threeheaded Dog", monsterHealth = 7, monsterAttackMin = 3, monsterAttackMax = 4, minGold = 2, maxGold = 4 },
            new Monster() { name = "A Grave Ghoul", monsterHealth = 6, monsterAttackMin = 1, monsterAttackMax = 2, minGold = 2, maxGold = 4 },
            new Monster() { name = "A Tricky Sourcerer", monsterHealth = 8, monsterAttackMin = 3, monsterAttackMax = 4, minGold = 2, maxGold = 4 },
            new Monster() { name = "The Firebreathing Dragon", monsterHealth = 20, monsterAttackMin = 44, monsterAttackMax = 45, minGold = 90, maxGold = 100 },
        };

        List<Weapon> arrWeapon = new List<Weapon>
        {
            new Weapon(7, "Crossbow") { name = "Crossbow", costGold = 8, weaponStrength = 7 },
            new Weapon(6, "Lance") { name = "Lance", costGold = 7, weaponStrength = 6 },
            new Weapon(8, "Sword") { name = "Sword", costGold = 8, weaponStrength = 8 },
            new Weapon(5, "Battle Axe") { name = "Battle Axe", costGold = 4, weaponStrength = 5 },
            new Weapon(4, "Club") { name = "Club", costGold = 4, weaponStrength = 4 },
            new Weapon(30, "A Golden Sword") { name = "A Golden Sword", costGold = 80, weaponStrength = 30 },
        };

        List<Shield> arrShield = new List<Shield>
        {
            new Shield(3, "Kite shield") { name = "Kite shield", costGold = 3, shieldStrength = 3 },
            new Shield(4, "Buckler") { name = "Buckler", costGold = 4, shieldStrength = 4 },
            new Shield(5, "Rondache") { name = "Rondache", costGold = 5, shieldStrength = 5 },
            new Shield(6, "Pavise") { name = "Pavise", costGold = 6, shieldStrength = 6 },
            new Shield(7, "Heater shield") { name = "Heater shield", costGold = 7, shieldStrength = 7 },
            new Shield(15, "Golden Star") { name = "Golden Star", costGold = 30, shieldStrength = 15 },
        };


        Hero hero1 = new Hero("Hero");
        Monster monst1 = new Monster("Dragon");
        Weapon weap1 = new Weapon(3, "Wooden Sword");
        Shield shiel1 = new Shield(2, "Turtle");
        Protection pro1 = new Protection(5);

        public void ShowTopMenu()
        {

            Console.WriteLine("1. Go to Forest ");
            Console.WriteLine("2. Go to Town ");
            Console.WriteLine("3. Quit ");
            Console.WriteLine();

        }

        public void ShowMenuTown()
        {
            // full health restored when going to town
            hero1.heroHealth = 3;

            Console.WriteLine("1. Buy Weapon - Black Market ");
            Console.WriteLine("2. Buy Shield - Royal Court ");
            Console.WriteLine("3. Go back ");

            int townuserAction = 0;
            // check the cast
            townuserAction = CheckUserInput();

            // if > 3 go back else ..
            if (townuserAction == 1)
            {
                ShowMenuWeapon();
            }
            else if (townuserAction == 2)
            {
                ShowMenuShield();
            }
            else
            {
                Change();
            }

        }

        public void ShowMenuWeapon()
        {

            int i = 0;
            foreach (Weapon w in arrWeapon)
            {
                i++;
                Console.WriteLine(i + ". Blacksmith - Buy " + w.name + " - Weapon max attack: " + w.weaponStrength.ToString() + " Gold: " + w.costGold.ToString());

            }

            Console.WriteLine("7. Go back ");

            int townuserAction = 0;
            // check the cast
            townuserAction = CheckUserInput();

            // if > 3 go back else ..
            if (townuserAction > 6)
            {
                Change();
            }
            else
            {
                BuyWeapon(townuserAction);
            }

        }

        public void ShowMenuShield()
        {

            int i = 0;
            foreach (Shield s in arrShield)
            {
                i++;
                Console.WriteLine(i + ". Royal Court - Buy " + s.name + " - Shield max attack: " + s.shieldStrength.ToString() + " Gold: " + s.costGold.ToString());

            }

            Console.WriteLine("7. Go back ");

            int townuserAction = 0;
            // check the cast
            townuserAction = CheckUserInput();

            // if > 3 go back else ..
            if (townuserAction > 6)
            {
                Change();
            }
            else
            {
                BuyShield(townuserAction);
            }

        }


        public void BuyWeapon(int windex)
        {
            ////////////////// BUY WEAPON ////////////////////////////////////
            // receive index to buy new weapon from List<Weapon>, display text

            Console.WriteLine("** Weapon Points: " + hero1.heroWeapon.ToString() + " Gold coins: " + hero1.heroGold.ToString() + " Total protection points: " + pro1.hitpoint.ToString());
            Console.WriteLine();
            Console.WriteLine("///////////////// AT THE BLACK MARKET ////////////////");
            Console.WriteLine();
            Console.WriteLine("Welcome " + hero1.name + "! We have been expecting you. ");
            Console.WriteLine("We have a great Weapon for you ... look the .. " + arrWeapon[windex - 1].name + " .. Wooo ");
            Thread.Sleep(1000);
            Console.WriteLine("The cost is " + arrWeapon[windex - 1].costGold + " Gold coins. We trust you are good for it. ");
            Console.WriteLine("Good luck on your journey! Welcome back! ");
            Console.WriteLine("/////////////////////////////////////////////////////");
            Thread.Sleep(1000);

            // check if hero can afford weapon
            int sum = hero1.heroGold - arrWeapon[windex - 1].costGold;
            if (sum >= 0)
            {
                // replace new weapon value in hitpoint
                pro1.hitpoint -= hero1.heroWeapon;
                pro1.hitpoint += arrWeapon[windex - 1].weaponStrength;

                hero1.heroWeapon = arrWeapon[windex - 1].weaponStrength;
                weap1.name = arrWeapon[windex - 1].name;
                weap1.weaponStrength = arrWeapon[windex - 1].weaponStrength;
                hero1.heroGold = hero1.heroGold - arrWeapon[windex - 1].costGold;
            }
            else
            {
                Console.WriteLine("You cannot afford this Weapon. The only way to get more Gold is to go and fight more Monsters .. Best of luck! ");
            }

            Console.WriteLine();
            Console.WriteLine("** Weapon Points: " + hero1.heroWeapon.ToString() + " Gold coins: " + hero1.heroGold.ToString() + " Total protection points: " + pro1.hitpoint.ToString());
            Thread.Sleep(1000);
            Console.WriteLine();

            ShowTopMenu();

        }


        public void BuyShield(int windex)
        {

            ////////////////// BUY SHIELD ////////////////////////////////////
            // receive index to buy new shield from List<Shield>, display text

            Console.WriteLine("** Shield Points: " + hero1.heroShield.ToString() + " Gold coins: " + hero1.heroGold.ToString() + " Total protection points: " + pro1.hitpoint.ToString());
            Console.WriteLine();
            Console.WriteLine("///////////////// AT THE ROYAL COURT ////////////////");
            Console.WriteLine();
            Console.WriteLine("Welcome " + hero1.name + "! We have been expecting you. ");
            Console.WriteLine("We have a great Shield for you ... look the .. " + arrShield[windex - 1].name + " .. Wooo ");
            Thread.Sleep(1000);
            Console.WriteLine("The cost is " + arrShield[windex - 1].costGold + " Gold coins. We trust you are good for it. ");
            Console.WriteLine("Good luck on your journey! Welcome back! ");
            Console.WriteLine("/////////////////////////////////////////////////////");
            Thread.Sleep(1000);

            // check if hero can afford shield
            int sum = hero1.heroGold - arrShield[windex - 1].costGold;
            if (sum >= 0)
            {
                // replace new shield value in hitpoint
                pro1.hitpoint -= hero1.heroShield;
                pro1.hitpoint += arrShield[windex - 1].shieldStrength;

                // set new name, strength, adjust gold
                hero1.heroShield = arrShield[windex - 1].shieldStrength;
                shiel1.name = arrShield[windex - 1].name;
                shiel1.shieldStrength = arrShield[windex - 1].shieldStrength;
                hero1.heroGold = hero1.heroGold - arrShield[windex - 1].costGold;
            }
            else
            {
                Console.WriteLine("You cannot afford this Shield. The only way to get more Gold is to go and fight more Monsters .. Best of luck! ");
            }

            Console.WriteLine();
            Console.WriteLine("** Shield Points: " + hero1.heroShield.ToString() + " Gold coins: " + hero1.heroGold.ToString() + " Total protection points: " + pro1.hitpoint.ToString());
            Thread.Sleep(1000);
            Console.WriteLine();

            ShowTopMenu();

        }



        public void ShowMenuForest()
        {
            // monsters - different monsterhealth

            Console.WriteLine("1. Forest - Small Cave ");
            Console.WriteLine("2. Forest - Waterfall ");
            Console.WriteLine("3. Forest - Little Hut ");
            Console.WriteLine("4. Forest - Sunny Glend ");
            Console.WriteLine("5. Go back ");

            int forestuserAction = 0;
            // check the cast
            forestuserAction = CheckUserInput();

            // if 5 go back else ..
            if (forestuserAction > 0 && forestuserAction < 4)
            {
                ShowMenuForestAction();
            }
            else if (forestuserAction == 4)
            {
                ShowMenuForestBossAction();
            }
            else
            {
                ShowTopMenu();
            }

        }
        public void ShowMenuForestAction()
        {
            Console.WriteLine("1. Fight monster ");
            Console.WriteLine("2. Run ");
            Console.WriteLine("3. Go back ");

            int forestactionuserAction = 0;
            // check the cast
            forestactionuserAction = CheckUserInput();

            if (forestactionuserAction == 1)
            {
                FightMonster(0);
            }
            else if (forestactionuserAction == 2)
            {
                Run();
            }
            else
            {
                ShowTopMenu();
            }

        }

        public void ShowMenuForestBossAction()
        {
            Console.WriteLine("1. Fight monster ");
            Console.WriteLine("2. Run ");
            Console.WriteLine("3. Go back ");

            int forestactionuserAction = 0;
            // check the cast
            forestactionuserAction = CheckUserInput();

            if (forestactionuserAction == 1)
            {
                // Fight The Boss Monster
                FightMonster(5);
            }
            else if (forestactionuserAction == 2)
            {
                Run();
            }
            else
            {
                ShowTopMenu();
            }

        }

        public int FightMonster(int ordinary)
        {
            ////////////////// FIND MONSTER - RANDOM PICK //////////////////////////
            // find a monster at random pick in List<Monster>, display text

            //int ordinary = 0;
            if (ordinary == 0)
            {
                Random rnd = new Random();
                int randNumb = rnd.Next(0, 4);

                for (int i = 0; i < arrMonster.Count; i++)
                {
                    if (i == randNumb)
                    {
                        monst1.name = arrMonster[i].name;
                        monst1.monsterHealth = arrMonster[i].monsterHealth;
                        monst1.monsterAttackMax = arrMonster[i].monsterAttackMax;
                        monst1.maxGold = arrMonster[i].maxGold;
                    }
                }
            }
            else
            {
                monst1.name = arrMonster[5].name;
                monst1.monsterHealth = arrMonster[5].monsterHealth;
                monst1.monsterAttackMax = arrMonster[5].monsterAttackMax;
                monst1.maxGold = arrMonster[5].maxGold;
            }

            Console.WriteLine("///////////// START THE FIGHT ////////////////");
            Console.WriteLine(monst1.name + " approaching, be very careful, he has spotted you .. ");
            Console.WriteLine(" .. prepare to fight .. ");
            Thread.Sleep(1000);
            Console.WriteLine(" .. ZZZZLINGG .. ");
            Thread.Sleep(1000);
            Console.WriteLine(" .. GAAZOOM .. ");
            Thread.Sleep(1000);
            Console.WriteLine(" .. KAPOFF .. ");
            Console.WriteLine();
            Console.WriteLine("///////////// HERO VERSUS MONSTER ////////////////");

            Console.WriteLine("** " + monst1.name + " ** \nAttack points: " + monst1.monsterAttackMax.ToString() + " \nHealth points: " + monst1.monsterHealth.ToString() + " \nGold points: " + monst1.maxGold.ToString());
            Console.WriteLine();
            Console.WriteLine("** " + hero1.name + " ** \nWeapon points: " + hero1.heroWeapon.ToString() + " \nHealth points: " + hero1.heroHealth.ToString() + " \nProtection points: " + pro1.hitpoint.ToString());
            Console.WriteLine();
            Console.WriteLine("///////////// FIGHT POINTS ////////////////");
            Console.WriteLine();

            ////////////////////// START THE FIGHT /////////////////////////////////////////////
            // as long as hero and monster are alive - set = 0
            int set = 0;
            // set if protection is gone, monster attacks health
            int sethealth = 0;

            do
            {

                // Console.WriteLine("monster and hero alive ......");

                ///////////////////////////////// HERO ATTACKS /////////////////////////////////

                // hero attacks - uses Weapon - randStrike decides min or max attack - adjust monsterHealth

                if (hero1.heroHealth < 1)
                {
                    Console.WriteLine("///////////////////////////////");
                    Console.WriteLine("Bad Luck! Hero dead! Game Over! ");
                    set = 1;
                }
                else
                {

                    Random rnd2 = new Random();
                    int randStrike = rnd2.Next(0, 5);

                    if (randStrike < 3)
                    {
                        // minimum strike
                        int min = weap1.weaponStrength - 1;
                        monst1.monsterHealth = monst1.monsterHealth - min;
                    }
                    else
                    {
                        // maximum strike
                        monst1.monsterHealth = monst1.monsterHealth - weap1.weaponStrength;
                    }
                    Console.WriteLine("Monster Health: " + monst1.monsterHealth);


                }

                ///////////////////////////////// MONSTER ATTACKS ///////////////////////////

                // monster attacks - uses maxAttack - randStrike decides min or max attack - adjust hitpoint(protection class) until 0, then adjust heroHealth

                if (monst1.monsterHealth < 1)
                {
                    hero1.heroGold = hero1.heroGold + monst1.maxGold;
                    Console.WriteLine("///////////////////////////////////////////////////////////");
                    Console.WriteLine("Congratulations! Monster dies! You're a hero! You gain Gold: " + hero1.heroGold.ToString());
                    set = 1;
                }
                else
                {

                    if (sethealth == 0)
                    {
                        // monster attacks protection / hitpoints
                        Random rnd3 = new Random();
                        int randStrike2 = rnd3.Next(0, 5);

                        if (randStrike2 < 3)
                        {
                            // minimum strike
                            int min = monst1.monsterAttackMax - 1;
                            pro1.hitpoint = pro1.hitpoint - min;
                        }
                        else
                        {
                            // maximum strike
                            pro1.hitpoint = pro1.hitpoint - monst1.monsterAttackMax;
                        }
                    }
                    else
                    {
                        // monster attacks health
                        Random rnd3 = new Random();
                        int randStrike2 = rnd3.Next(0, 5);

                        if (randStrike2 < 3)
                        {
                            // minimum strike
                            int min = monst1.monsterAttackMax - 1;
                            hero1.heroHealth = hero1.heroHealth - min;
                        }
                        else
                        {
                            // maximum strike
                            hero1.heroHealth = hero1.heroHealth - monst1.monsterAttackMax;
                        }
                    }

                    // monster hits hero health
                    if (pro1.hitpoint < 0 && sethealth == 0)
                    {
                        int subtract = Math.Abs(pro1.hitpoint);

                        hero1.heroHealth = hero1.heroHealth - subtract;
                        sethealth = 1;
                    }

                    Console.WriteLine("Hero Protection points: " + pro1.hitpoint.ToString() + " Hero Health: " + hero1.heroHealth);


                }

                /////////////////////////////////////////////////////////////////////////////////
            } while (set == 0);

            // if hero dead - set new player or exit game - or main menu -> create new hero

            if (hero1.heroHealth < 1)
            {

                Console.WriteLine("\nCreate new hero? You can continue to play, but need more weapons and shield .. Go to town!! ");

                this.hero1.heroHealth = 3;
                this.hero1.heroGold = 10;
                this.hero1.heroWeapon = 3;
                this.hero1.heroShield = 2;
                this.hero1.heroHelmet = 0;
                this.hero1.heroArmour = 0;
                this.pro1.hitpoint = 5;

            }
            Console.WriteLine();

            ShowTopMenu();

            return ordinary;

        }

        public void Run()
        {
            Console.WriteLine("Run .. do not look back ... ");
            ShowTopMenu();
        }

        public void Change()
        {
            Console.WriteLine("Think wisely for your next battle ... all that protects will be of good use .. ");
            ShowTopMenu();
        }

        public int CheckUserInput()
        {

            int set = 0;
            int input = 0;
            int number = 0;

            do
            {
                string value = Console.ReadLine();
                bool result = Int32.TryParse(value, out number);

                if (result)
                {
                    input = number;
                    set = 1;
                }
                else
                {
                    Console.WriteLine("Invalid input ");
                }
            } while (set == 0);
            return input;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            // check menu options for return / go back

            Game game1 = new Game();

            int userAction = 0;

            do
            {
                if (userAction == 0)
                {
                    game1.ShowTopMenu();
                }

                // check cast - then goto - make small function for this

                userAction = game1.CheckUserInput();

                if (userAction == 1)
                {

                    game1.ShowMenuForest();

                }
                else if (userAction == 2)
                {

                    game1.ShowMenuTown();

                }
                else
                {
                    Console.WriteLine("Choose wisely ");

                }

            }
            while (userAction != 3);

            Console.ReadLine();

        }
    }
}


