using System;
using System.Data;
using System.Net;
using System.Numerics;
using System.Reflection;

namespace Отделкадров
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Отдел кадров");
            Console.WriteLine("Добро пожаловать в приложение!!!\n");
            bool cs = true;
            while (cs == true)
            {
                AUTH V = new AUTH();
                V.Chtenie();
                Console.WriteLine("Enter login: ");
                string login = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string password = Console.ReadLine();
                Console.WriteLine("Enter dolgnost: ");
                string post = Console.ReadLine();
                if (V.Check(login, password, post) == true)
                {
                    if (post == "администратор")
                    {
                        Console.WriteLine("Выберите желаемое действие:\n1 - Заполнить данные нового сторудника\n2 - Удалить данные сотрудника\n3 - Вывод всех данных сотрудников");
                        int number = Convert.ToInt32(Console.ReadLine());
                        if (number == 1)
                        {
                            Console.WriteLine("Введите фамилию: ");
                            string surname = Console.ReadLine();
                            Console.WriteLine("Введите имя: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите отчество: ");
                            string patronimyc = Console.ReadLine();
                            Console.WriteLine("Введите пол: ");
                            string gender = Console.ReadLine();
                            Console.WriteLine("Введите дату рождения: ");
                            string databirth = Console.ReadLine();
                            Console.WriteLine("Введите адрес: ");
                            string address = Console.ReadLine();
                            Console.WriteLine("Введите паспортные данные: ");
                            string passportdata = Console.ReadLine();
                            Console.WriteLine("Введите образование: ");
                            string education = Console.ReadLine();
                            Console.WriteLine("Введите профессию: ");
                            string profession = Console.ReadLine();
                            Console.WriteLine("Введите должность: ");
                            string pst = Console.ReadLine();
                            Console.WriteLine("Введите дату начала работы: ");
                            string datastart = Console.ReadLine();
                            Console.WriteLine("Введите подразделение: ");
                            string division = Console.ReadLine();
                            Console.WriteLine("Введите оклад: ");
                            int salary = Convert.ToInt32(Console.ReadLine());
                            V.vvod( surname,  name,  patronimyc,  gender,  databirth,  address,  passportdata,  education,  profession,  pst,  datastart,  division,  salary);
                        }
                        else if (number == 2)
                        {
                            
                            List<data> I = new List<data>();
                            string Path = "data.csv";
                            Del(Path, I);


                        }

                        else if(number == 3)
                        {
                            List<data> users = new List<data>();
                            string Path = "data.csv";
                            getData(Path, users);
                            printData(users);
                        }

                        else
                        {
                            Console.WriteLine("Такого функционала нет");
                        }
                    }

                    void Del(string path, List<data> I)
                    {
                        using (StreamReader sr = new StreamReader(path))
                        {
                            while (sr.EndOfStream != true)
                            {
                                string[] array = sr.ReadLine().Split(';');
                                I.Add(new data()
                                {
                                    surname = array[0],
                                    name = array[1],
                                    patronimyc = array[2],
                                    gender = array[3],
                                    databirth = array[4],
                                    address = array[5],
                                    passportdata = array[6],
                                    education = array[7],
                                    profession = array[8],
                                    post = array[9],
                                    datastart = array[10],
                                    division = array[11],
                                    salary = Convert.ToInt32(array[12]),
                                });
                            }
                            sr.Close();
                        }
                        Console.WriteLine("Введите номер строки, которую нужно удалить");
                        int d = Convert.ToInt32(Console.ReadLine());
                        I.RemoveAt(d - 1);
                        using (StreamWriter sw = new StreamWriter(File.Open(path, FileMode.Create)))
                        {
                            for (int i = 0; i < I.Count; i++)
                            {
                                sw.Write($"{I[i].surname};");
                                sw.Write($"{I[i].name};");
                                sw.Write($"{I[i].patronimyc};");
                                sw.Write($"{I[i].gender};");
                                sw.Write($"{I[i].databirth};");
                                sw.Write($"{I[i].address};");
                                sw.Write($"{I[i].passportdata};");
                                sw.Write($"{I[i].education};");
                                sw.Write($"{I[i].profession};");
                                sw.Write($"{I[i].post};");
                                sw.Write($"{I[i].datastart};");
                                sw.Write($"{I[i].division};");
                                sw.Write($"{I[i].salary};\n");
                            }
                            sw.Close();
                        }
                    }

                    static void getData(string path, List<data> L)
                    {

                        using (StreamReader sr = new StreamReader(path))
                        {
                            while (sr.EndOfStream != true)
                            {
                                string[] array = sr.ReadLine().Split(';');
                                L.Add(new data()
                                {
                                    surname = array[0],
                                    name = array[1],
                                    patronimyc = array[2],
                                    gender = array[3],
                                    databirth = array[4],
                                    address = array[5],
                                    passportdata = array[6],
                                    education = array[7],
                                    profession = array[8],
                                    post = array[9],
                                    datastart = array[10],
                                    division = array[11],
                                    salary = Convert.ToInt32(array[12]),
                                });
                            }
                        }
                    }
                    static void printData(List<data> L)
                    {
                        foreach (data u in L)
                        {
                            u.show();
                        }
                    }

                    if (post == "сотрудник")
                    {
                        Console.WriteLine("Выберите желаемое действие:\n1 - Вывод всех данных сотрудников");
                        int number = Convert.ToInt32(Console.ReadLine());
                        if (number == 1)
                        {
                            List<data> users = new List<data>();
                            string Path = "data.csv";
                            getData(Path, users);
                            printData(users);
                        }

                        else
                        {
                            Console.WriteLine("Такого функционала нет");
                        }
                    }
                }
                Console.WriteLine("Желаете продолжить работу? [Y/N]");
                string s = Console.ReadLine();
                if (s == "N")
                {
                    cs = false;
                }
            }
        }
    }
}
