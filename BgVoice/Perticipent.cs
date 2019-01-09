using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BgVoice
{
    internal class Perticipent
    {
        public string IdCode;

        /// <summary>
        /// first , second, last names
        /// </summary>
        public string fullName;

        public int entrancenum;
        public string oblast;
        public int dayOfBirth;
        public int monthOfBirth;
        public int yearOfBirth;
        public int age;

        public string talant;
        public int score;

        public int GetAge()
        {
            if (yearOfBirth <= 18)
            {
                this.age = 18 - yearOfBirth;
            }
            else if (yearOfBirth > 19)
            {
                this.age = 18 + (100 - yearOfBirth);
            }

            return age;
        }

        public void GetName()
        {
            Console.WriteLine("Моля въведете първо име на участника.");
            string firstname = Console.ReadLine();

            Console.WriteLine("Моля въведете презиме име на участника.");
            string middlename = Console.ReadLine();
            middlename = middlename.Substring(0, 1) + ".";

            Console.WriteLine("Моля въведете фамилия на участника.");
            string surname = Console.ReadLine();

            this.fullName = firstname + " " + middlename + " " + surname;
        }

        public void GetIDCode()
        {
            Console.WriteLine("Какъв е идентификационния код на участника?");
            this.IdCode = Console.ReadLine();
        }

        public void GetOblast()
        {
            switch (IdCode[3].ToString())
            {
                case "1":
                    oblast = "София";
                    break;

                case "2":
                    oblast = "Пловдив";
                    break;

                case "3":
                    oblast = "Варна";
                    break;

                case "4":
                    oblast = "Бургас";
                    break;

                case "5":
                    oblast = "Русе";
                    break;

                case "6":
                    oblast = "Благоевград";
                    break;
            }
        }

        public void GetEntranceNum()
        {
            this.entrancenum = int.Parse(IdCode.Substring(0, 3));
        }

        public void GetDayOfBirth()
        {
            this.dayOfBirth = int.Parse(IdCode.Substring(4, 2));
        }

        public void GetMonthOfBirth()
        {
            this.monthOfBirth = int.Parse(IdCode.Substring(6, 2));
        }

        public void GetYearOfBirth()
        {
            this.yearOfBirth = int.Parse(IdCode.Substring(8, 2));
        }

        public void GetTalant()
        {
            Console.WriteLine("Какъв талант показва участника ?");
            talant = Console.ReadLine();
        }

        public void GetScore()
        {
            Console.WriteLine("Колко гласа е получил участника?");
            this.score = int.Parse(Console.ReadLine());
        }

        public void PrintInfo()
        {
            Console.WriteLine(this.fullName + ", " + this.entrancenum + ", " + this.oblast + ", " + this.talant + ", " + this.score + ", " + this.dayOfBirth + "." + this.monthOfBirth + "." + this.yearOfBirth + ".");
        }

        public void getOblastInfo()
        {
            Console.WriteLine("За коя област искате информация?");
            string oblastprint = Console.ReadLine();

            if (oblastprint.ToLower() == oblast.ToLower())
            {
            }
            else
            {
                Console.WriteLine("Невалидна област");
            }
        }
    }
}