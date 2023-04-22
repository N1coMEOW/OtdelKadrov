using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegistrationLibrary
{
    public struct User
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; private set; }
        /// <summary>
        /// Роль в системе
        /// </summary>

        /// <summary>
        /// Конструктор для взаимодействия с классом аутентификации
        /// </summary>
        /// <param name="StringFromAuthFile">Строка из файла аутентификации с данными пользователя</param>
        public User(string StringFromAuthFile)
        {
            Name = StringFromAuthFile.Split(";")[2];
            Surname = StringFromAuthFile.Split(";")[3];
        }
    }
    /// <summary>
    /// Класс описывающий ошибку отсутствия файла аутентификации
    /// </summary>
    public class PathToFileMissingException : Exception
    {
        public PathToFileMissingException(string Message) : base(Message) { }
    }
    /// <summary>
    /// "Статический" класс для аутентификации пользователя в системе (Работает с csv файлами)
    /// </summary>
    public class AuthenticationInSystem
    {
        /// <summary>
        /// Путь к файлу с аутентификационными данными (Файл должен иметь формат csv)
        /// </summary>
        private static string? pathToFileWithAuth;
        /// <summary>
        /// Свойство для работы с путём с файлу
        /// </summary>
        public static string? PathToFileWithAuth
        {
            get
            {
                return pathToFileWithAuth;
            }
            set
            {
                if ((value is not null) && Regex.IsMatch(value, @".*reg.csv$"))
                {
                    pathToFileWithAuth = value;
                }
                else
                {
                    throw new ArgumentException("Файл должен иметь формат csv");
                }
            }
        }
        /// <summary>
        /// Функция аутентификации пользователя в системе, для работы необходимо запонить свойство PathToFileWithAuth
        /// </summary>
        /// <param name="Login">Логин пользователя в системе</param>
        /// <param name="Password">Пароль пользователя в системе</param>
        /// <returns>Структура с данными пользователя</returns>
        /// <exception cref="PathToFileMissingException">Отсутствует путь к файлу аутентификации</exception>
        public static User? Authentication(string Login, string Password)
        {
            if (pathToFileWithAuth is not null)
            {
                using (StreamReader AuthenticationFile = new StreamReader(pathToFileWithAuth))
                {
                    while (!AuthenticationFile.EndOfStream)
                    {
                        string? CurrentLineInAuthenticationFile = AuthenticationFile.ReadLine();
                        if (CurrentLineInAuthenticationFile is not null
                            && CurrentLineInAuthenticationFile.Split(";")[0] == Login
                            && CurrentLineInAuthenticationFile.Split(";")[1] == Password)
                        {
                            return new User(CurrentLineInAuthenticationFile);
                        }
                    }
                    return null;
                }
            }
            else
            {
                throw new PathToFileMissingException("Путь к файлу с аутентификационными данными не задан");
            }
        }
    }
}
