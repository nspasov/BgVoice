using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BgVoice
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Perticipent Penka = new Perticipent(); // for swapping

            int size;
            Perticipent[] perticipents;

            do
            {
                Console.WriteLine("Какъв е броят на участниците?");
                size = int.Parse(Console.ReadLine());
            } while (size < 0 || size > 500);

            perticipents = new Perticipent[size];

            for (int i = 0; i < perticipents.Length; i++)
            {
                perticipents[i] = new Perticipent();
                Console.WriteLine("Въвеждане на информация за участник№" + (i + 1));
                perticipents[i].GetName();
                perticipents[i].GetIDCode();
                perticipents[i].GetEntranceNum();
                perticipents[i].GetOblast();
                perticipents[i].GetDayOfBirth();
                perticipents[i].GetMonthOfBirth();
                perticipents[i].GetYearOfBirth();
                perticipents[i].GetTalant();
                perticipents[i].GetScore();

                Console.WriteLine("Готово, Следващ участник:");
                Console.ReadKey();
                Console.Clear();
            }

            perticipents = perticipents.OrderBy(s => s.fullName).ToArray();  // sorting array alphabetically

            Console.WriteLine("Списък с всички участници, подредени по азбучен ред на вида талант:");

            for (int i = 0; i < perticipents.Length; i++)
            {
                perticipents[i].PrintInfo();
            }

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Списък на участниците от София родени след 1990г:");

            perticipents = perticipents.OrderBy(s => s.talant).ToArray();
            // perticipents = perticipents.Where(s => s.oblast == "София" && s.yearOfBirth > 1990).OrderBy(s => s.talant).ThenByDescending(s => s.score).ToArray();

            for (int i = 0; i < perticipents.Length; i++)   // Sorting talants alphabetically & when same talant - descending order of the score points
            {
                for (int j = 0; j < perticipents.Length; j++)
                {
                    if ((perticipents[i].talant == perticipents[j].talant) && (perticipents[i].score < perticipents[j].score))
                    {
                        perticipents[i] = Penka;
                        perticipents[i] = perticipents[j];
                        perticipents[j] = Penka;
                    }
                }
            }

            for (int i = 0; i < perticipents.Length; i++)
            {
                if (perticipents[i].oblast == "София" && (perticipents[i].yearOfBirth >= 90 || perticipents[i].yearOfBirth < 18))
                {
                    perticipents[i].PrintInfo();
                }
            }

            // Инфо по области, нз как да го направя в метод защото масива не съществува..

            for (int n = 0; n < 3; n++)
            {
                Console.WriteLine("За коя област искате информация?");
                string oblastprint = Console.ReadLine();

                Console.WriteLine("Участниците от област " + oblastprint + " са:");
                perticipents = perticipents.OrderBy(s => s.fullName).ToArray();

                for (int i = 0; i < perticipents.Length; i++)
                {
                    if (oblastprint.ToLower() == perticipents[i].oblast.ToLower())
                    {
                        perticipents[i].PrintInfo();
                    }
                }

                int highestScore = 0;

                for (int i = 0; i < perticipents.Length; i++)
                {
                    if (perticipents[i].score > highestScore && oblastprint.ToLower() == perticipents[i].oblast.ToLower())
                    {
                        highestScore = perticipents[i].score;
                    }
                }

                Console.WriteLine("Най-висок резултат от област " + oblastprint + " е: " + highestScore);
                Console.WriteLine("Участниците постигнали го са: ");
                for (int i = 0; i < perticipents.Length; i++)
                {
                    if (perticipents[i].score == highestScore)
                    {
                        Console.WriteLine(perticipents[i].fullName);
                    }
                }

                Console.WriteLine("Средната възраст на участниците от област " + oblastprint + " е: ");

                int srednaVuzrast = 0;

                for (int i = 0; i < perticipents.Length; i++)
                {
                    if (oblastprint.ToLower() == perticipents[i].oblast.ToLower())
                        srednaVuzrast += perticipents[i].age;
                }
                srednaVuzrast /= perticipents.Length;

                Console.Write(srednaVuzrast);
            }
        }
    }
}