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
    public class UserController : ControllerBase
    {
        private const string USERS_FILE_NAME = "users.dat";
        /// <summary>
        /// Список пользователей приложения.
        /// </summary>
        public List<User> Users { get; }
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
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
           return base.Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();         
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            base.Save(USERS_FILE_NAME, Users);
        }

    }
}
