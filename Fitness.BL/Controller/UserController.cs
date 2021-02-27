using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public List<User> Users { get; }

        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Имя пользователя не может быть null", nameof(name));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == name);

            if(CurrentUser == null)
            {
                CurrentUser = new User(name);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

        }
        public void SetNewUserData(string gender, DateTime birthDate, double weight = 1, double height = 1)
        {
            //Проверка

            CurrentUser.Gender = new Gender(gender);
            CurrentUser.BrithDate = birthDate;
            CurrentUser.Wright = weight;
            CurrentUser.Height = height;
            Save();
        }
        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }            
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }

    }
}
