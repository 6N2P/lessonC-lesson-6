using System;
using System.IO;

namespace Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (exit == false)
            {
                int numberMethod = NumerMethod();

                switch (numberMethod)
                {
                    case 1:
                        ChekAndShow();
                        break;

                    case 2:

                        CreateFileAndRead();
                        break;
                    case 3:
                        exit = true;
                        break;
                }
            }           
        }

        static void ChekAndShow()
        {
            if (IsFile() == true)
            {
                ShowContent();
            }
            else
            {
                Console.WriteLine("Файл не создан");
            }
        }
        /// <summary>
        /// Создает файл изаписывет его
        /// </summary>        
        static void CreateFileAndRead()
        {
            int ID=0;
            string dateTime=string.Empty;
            string name=string.Empty;
            int age=0;
            int growth=0;
            DateTime dateOfBirth = new DateTime();
            string plaseOfBirth=string.Empty;

            ID = GetID();
            dateTime = DateTime.Now.ToString("g");
            name = GetName();
            age = GetAge();
            growth = GetGrowth();
            dateOfBirth = GetBirthday();
            plaseOfBirth = GetPlaseofBith();

            int count = GetID() + 1;
            string lines = string.Empty;
            string allText = string.Empty;

            string text = $"{ID}#{dateTime}#{name}#{age}#{growth}#{dateOfBirth:d}#{plaseOfBirth}";
            if (IsFile() == true)
            {
                lines = File.ReadAllText(@"h:\dataTest.txt");
                allText = $"{lines}\n{text}";

                File.WriteAllText(@"h:\dataTest.txt", allText);
            }
            else
            {
                File.WriteAllText(@"h:\dataTest.txt", text);
            }
        }
        /// <summary>
        /// Проверяет существует ли фйл
        /// </summary>
        /// <returns>Возвращает булквое значение</returns>
        static bool IsFile ()
        {
            bool flag = File.Exists(@"h:\dataTest.txt") ? true : false;
            return flag;
        }
        /// <summary>
        /// Получает от пользователя номер метода
        /// </summary>
        /// <returns>Номер метода</returns>
        static int NumerMethod()
        {
            int method = 0;
            bool flag = false;

            while (flag == false)
            {
                Console.WriteLine("Если хотите вывести данные, нажмите 1\nЕсли отите заполнить данные в конце строки, нажмите 2\nДля выхода нажмите 3");
                string Smethod = Console.ReadLine();
                if (Smethod == "1" || Smethod=="2" || Smethod == "3")
                {
                    method = Convert.ToInt32(Smethod);
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Такого значения нет");
                    flag = false;
                }
            }
            return method;
        }
        /// <summary>
        /// Показывает содержимое фала
        /// </summary>
        static void ShowContent()
        {
            string lines = File.ReadAllText(@"h:\dataTest.txt");
            string[] line = lines.Split('#');
           
            foreach (var l in line)
            {
                Console.Write(l + " ");
            }
            Console.WriteLine();
        }

        static int GetID()
        {
            int id = 1;
            string line = string.Empty;
            if (IsFile() == true)
            {
                string [] lines = File.ReadAllLines(@"h:\dataTest.txt");
                id = lines.Length + 1;                
            }
            else
            {
                id = 1;
            }
                return id;
        }
        static string GetName()
        {
            string name;
            Console.WriteLine("Введите Ф.И.О");
            name = Console.ReadLine();
            return name;
        }
        static int GetAge()
        {
            int age = 0;
            bool flag = false;

            while (flag == false)
            {
                Console.WriteLine("Введите возраст");
                age = Convert.ToInt32(Console.ReadLine());
                if (age > 0 && age < 110)
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Не родившихся и бессмертных не вносят в список");
                    flag = false;
                }
            }
            return age;
        }
        static int GetGrowth()
        {
            int growth=0;           

            bool flag = false;

            while(flag==false)
            {
                Console.WriteLine("Введите рост в сантиметрах");
                growth = Convert.ToInt32(Console.ReadLine());
                if (growth>10 &&  growth < 270)
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Не стоит шутить со мной великановый каратышка");
                    flag = false;
                }
            }          

            return growth;
        }
        static DateTime GetBirthday ()
        {
            DateTime birthday=new DateTime();
            Console.WriteLine("Введите дату рождения d.m.y");
            birthday = Convert.ToDateTime(Console.ReadLine());

            return birthday;
        }
        static string GetPlaseofBith()
        {
            string plase = string.Empty;
            Console.WriteLine("Введите город рождения");
            plase = Console.ReadLine();

            return plase;
        }
        
    }
}
