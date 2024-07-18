using System;

namespace BossFight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAttack = "1";
            const string CommandFireBall = "2";
            const string CommandExplosion = "3";
            const string CommandHealing = "4";

            string desiredOperation;

            Random random = new Random();

            int bossHealth = 1000;
            int bossDamage;
            int minBossDamage = 25;
            int maxBossDamage = 51;

            int heroMaxHealth = 400;
            int heroHealth = heroMaxHealth;
            int heroMaxMana = 200;
            int heroMana = heroMaxMana;
            int heroDamage = 35;
            int heroFireBallDamage = 60;
            int fireBallCost = 20;
            int heroExplosionDamage = 100;
            int explosionCost = 45;
            int heroPotion = 125;
            int amountPotion = 3;

            bool canExplosion = false;

            Console.WriteLine("Герой! Вы должны победить этого демона!\n");

            while (bossHealth > 0 && heroHealth > 0)
            {
                bossDamage = random.Next(minBossDamage, maxBossDamage);

                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Очки здоровья демона: " + bossHealth + "\n");
                Console.WriteLine("Очки здоровья героя: " + heroHealth);
                Console.WriteLine("Очки маны героя: " + heroMana);
                Console.WriteLine("Количество зелий героя: " + amountPotion + ". Одно зелье восстанавливает "
                    + heroPotion + " единиц маны и здоровья\n");

                Console.WriteLine("Ваш черед атаковать.");
                Console.WriteLine($"1 - обычная атака, наносящая {heroDamage} урона");
                Console.WriteLine($"2 - использовать огненный шар, который нанесет {heroFireBallDamage} урона и позволит в " +
                    $"следующем раунде использовать взрыв.\n Стоимость {fireBallCost} маны");
                Console.WriteLine($"3 - использовать взрыв, который нанесет {heroExplosionDamage} урона. Доступен только после использования " +
                    $"огненного шара. \n Стоимость {explosionCost} маны");
                Console.WriteLine($"4 - восстановить ману и здоровье в количестве {heroPotion} очков");
                desiredOperation = Console.ReadLine();

                switch (desiredOperation)
                {
                    case CommandAttack:
                        Console.WriteLine($"Вы наносите демона обычную атаку в размере {heroDamage} единиц урона.");
                        bossHealth -= heroDamage;
                        break;

                    case CommandFireBall:
                        if (heroMana >= fireBallCost)
                        {
                            Console.WriteLine($"Вы отправляете в демона огненный шар и наносите {heroFireBallDamage} урона.");
                            Console.WriteLine($"Вы потратили {fireBallCost} маны.");
                            bossHealth -= heroFireBallDamage;
                            heroMana -= fireBallCost;
                            canExplosion = true;
                        }
                        
                        else
                        {
                            Console.WriteLine("У вас недостаточно маны. Демон смеётся вам в лицо.");
                        }
                        break;

                    case CommandExplosion:
                        if (canExplosion == true && heroMana >= explosionCost)
                        {
                            Console.WriteLine($"Вы начинает кричать слово EXPLOSION что сбивает с толку демона не меньше " +
                                $"чем большое красное поле под его ногами. Вы нанесли {heroExplosionDamage} урона.");
                            Console.WriteLine($"Вы потратили {explosionCost} маны.");
                            Console.WriteLine("Перед тем как снова закричать и напугать демона, нужно отправить огненный шар.");
                            bossHealth -= heroExplosionDamage;
                            heroMana -= explosionCost;
                            canExplosion = false;
                        }
                        
                        else
                        {
                            Console.WriteLine("Вы не можете прочитать это заклинание.");
                            Console.WriteLine("Вы пропускаете ход.");
                        }
                        break;

                    case CommandHealing:
                        if (amountPotion > 0)
                        {
                            Console.WriteLine($"Вы достаете зелье и используете его. Восстановлено {heroPotion} очков маны и здоровья.");
                            amountPotion--;
                            heroHealth += heroPotion;
                            heroMana += heroPotion;
                            
                            if (heroHealth > heroMaxHealth)
                            {
                                heroHealth = heroMaxHealth;
                            }
                            
                            if (heroMana > heroMaxMana)
                            {
                                heroMana = heroMaxMana;
                            }
                        }
                        
                        else
                        {
                            Console.WriteLine("У вас больше нет зелий. Бейтесь до последнего.");
                        }
                        break;

                    default:
                        Console.WriteLine("Вы расстерялись и ничего толкового не сделали. Демон насмехается над вами.");
                        break;
                }

                Console.WriteLine($"Демон улыбаясь наносит вам {bossDamage} урона.");
                heroHealth -= bossDamage;
            }

            Console.WriteLine("--------------------------------------------------------");

            if (bossHealth <= 0 && heroHealth <= 0)
            {
                Console.WriteLine("Вы победили демона, но от нанесенных ран тоже погибли.\nВас запомнят навсегда.");
            }

            else if (bossHealth <= 0)
            {
                Console.WriteLine("Вы победили демона! Теперь во всем мире будет спокойно.\nВ вашу честь будет пирушка.");
            }

            else if (heroHealth <= 0)
            {
                Console.WriteLine("К сожалению демон был слишком силен и вы погибли.\nДемону теперь никто не мешает уничтожить всё на свете.");
            }
        }
    }
}
