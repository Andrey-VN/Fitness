﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Свойства
        /// </summary>
        #region
        public string Name { get; }

        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Калории.
        /// </summary>
        public double Callories { get; }


        #endregion

        public Food(string name) : this(name, 0, 0, 0, 0)
        {

        }

        public Food(string name,
                    double callories,
                    double proteins,
                    double fats,
                    double carbohydrates)
        {
            //TODO: проверка
            Name = name;
            Callories = callories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
           
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
