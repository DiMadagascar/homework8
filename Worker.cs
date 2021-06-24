using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
    public class Worker
    {

        #region Конструкторы

        public Worker()
        {

        }

        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="N">Номер</param>
        /// <param name="FirstName">Имя</param>
        /// <param name="LastName">Фамилия</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Salary">Оплата труда</param>
        /// <param name="DepartmentName">Департамент</param>
        public Worker(int N, string FirstName, string LastName, int Age, int Salary,  string  DepartmentName)
        {
            this.n = N;
            this.firstName = FirstName;
            this.lastName = LastName;
            this.age = Age;
            this.salary = Salary;
            this.department = DepartmentName;
            
        }

        #endregion

        #region Методы

        public string Print()
        {
            return $"Номер:{this.n, 3}  Имя:{this.firstName,6}  Фамилия:{this.lastName,10}  Возраст{this.age,3}" +
                $" Зарплата:{this.salary,10}  Номер отдела:{this.department,3}";
        }

        #endregion

        #region Свойства
       /// <summary>
       /// Номер
       /// </summary>
        public int N { get { return this.n; } set { this.n = value; } }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get { return this.firstName; } set { this.firstName = value; } }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get { return this.lastName; } set { this.lastName = value; } }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get { return this.age; } set { this.age = value; } }
               
        /// <summary>
        /// Оплата труда
        /// </summary>
        public int Salary { get { return this.salary; } set { this.salary = value; } }
        /// <summary>
        /// Отдел
        /// </summary>
        public string DepartmentName { get { return this.department; } set { this.department = value; } }
        #endregion

        #region Поля

        /// <summary>
        /// Номер
        /// </summary>
        private int n;
        /// <summary>
        /// Поле "Имя"
        /// </summary>
        private string firstName;

        /// <summary>
        /// Поле "Фамилия"
        /// </summary>
        private string lastName;

        /// <summary>
        /// Поле "Возраст"
        /// </summary>
        private int age;

        /// <summary>
        /// Поле "Оплата труда"
        /// </summary>
        private int salary;

        /// <summary>
        /// Поле "Отдел"
        /// </summary>
        private string department;

        

        #endregion

    }
}

