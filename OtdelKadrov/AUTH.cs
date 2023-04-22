using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Отделкадров
{
    struct auth
    {
        public string login;
        public string password;
        public string post;
    }
    struct data
    {
        public string surname;
        public string name;
        public string patronimyc;
        public string gender;
        public string databirth;
        public string address;
        public string passportdata;
        public string education;
        public string profession;
        public string post;
        public string datastart;
        public string division;
        public int salary;
        public void show()
        {
            Console.WriteLine("{0, -15} {1, -15} {2, -15} {3, -15} {4, -15} {5, -15} {6, -15} {7, -15} {8, -15} {9, -15} {10, -15} {11, -15} {12, -15}", surname, name, patronimyc, gender, databirth, address, passportdata, education, profession, post, datastart, division, salary);
        }
        public string concat()
        {
            return surname + ";" + name + ";" + patronimyc + ";" + gender + ";" + databirth + ";" + address + ";" + passportdata + ";" + education + ";" + profession + ";" + post + ";" + datastart + ";" + division + ";" + salary;
        }
    }

    
    internal class AUTH
    {
        auth[] V = new auth[1];
        string path = "auth.csv";
        public void Chtenie()
        {
            using (StreamReader br = new StreamReader(path))
            {
                int i = 0;
                while (br.EndOfStream != true)
                {
                    string[] array = br.ReadLine().Split(';');
                    V[i].login = array[0];
                    V[i].password = array[1];
                    V[i].post = array[2];
                    Array.Resize(ref V, V.Length + 1);
                    Console.WriteLine("Login: {0}, Password: {1}, Dolgnost: {2}\n", V[i].login, V[i].password, V[i].post);
                    i++;
                }
            }
        }
        public bool Check(string login, string password, string post)
        {
            for (int i = 0; i <= V.Length - 1; i++)
            {
                if (V[i].login == login && V[i].password == password && V[i].post == post)
                {
                    if (post == "администратор")
                    {
                        Console.WriteLine("\nLogin and Password entered correctly!\n");
                        return true;
                        break;
                    }
                    else if (post == "сотрудник")
                    {
                        Console.WriteLine("Login and Password entered correctly!");
                        return true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Login and Password entered incorrectly");
                        return false;
                    }
                }
            }
            return false;
        }
        data[] D = new data[1];
        int c = 0;
        string path1 = "data.csv";
        public void vvod(string surname, string name, string patronimyc, string gender, string databirth, string address, string passportdata, string education, string profession, string post, string datastart, string division, int salary)
        {
                D[c].surname = surname;
                D[c].name = name;
                D[c].patronimyc = patronimyc;
                D[c].gender = gender;
                D[c].databirth = databirth;
                D[c].address = address;
                D[c].passportdata = passportdata;
                D[c].education = education;
                D[c].profession = profession;
                D[c].post = post;
                D[c].datastart = datastart;
                D[c].division = division;
                D[c].salary = salary;
                Array.Resize(ref D, D.Length + 1);
                    using (StreamWriter wr = new StreamWriter(File.Open(path1, FileMode.Append)))
                    {
                        wr.WriteLineAsync(D[c].surname + ";" + D[c].name + ";" + D[c].patronimyc + ";" + D[c].gender + ";" + D[c].databirth + ";" + D[c].address + ";" + D[c].passportdata + ";" + D[c].education + ";" + D[c].profession + ";" + D[c].post + ";" + D[c].datastart + ";" + D[c].division + ";" + D[c].salary);
                    }
        }
    }
}
