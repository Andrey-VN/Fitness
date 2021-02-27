using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BrithDate { get; set; }

        /// <summary>
        /// Вес.
        /// </summary>
        public double Wright { get; set; }

        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }




        //DateTime nowDate = DateTime.Today
        //int age = nowDate.Year - birthDate.Year
        //if(birthDate > nowDate.AddYears(-age)) age--;
        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get { return DateTime.Now.Year - BrithDate.Year; }}
        #endregion

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="brithDate">Дата рождения.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="height">Рост.</param>
        public User(string name, 
                    Gender gender, 
                    DateTime brithDate, 
                    double weight, 
                    double height)
        {

            #region Проверка условий
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(name));
            }
            if(gender == null)
            {
                throw new ArgumentNullException("Пол не может быть null.", nameof(Gender));
            }

            if(brithDate < DateTime.Parse("01.01.1900") || brithDate >= DateTime.Now)
            {
                throw new ArgumentNullException("Невозможная дата рождения.", nameof(brithDate));
            }

            if(weight <=0)
            {
                throw new ArgumentNullException("Вес не может быть меньше нуля или равным нулю.", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentNullException("Рост не может быть меньше нуля или равным нулю.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BrithDate = brithDate;
            Wright = weight;
            Height = height;
            
        }

        public User(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
