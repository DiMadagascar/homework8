using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
    public class Department
    {
        #region Конструкторы
        
        public Department()
        {

        }
      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="date"></param>
        /// <param name="countofworkers"></param>
        /// <param name="workers"></param>
        /// <param name="InnerDeps"></param>
        public Department(string Name, DateTime date, int countofworkers, List<Worker> workers, List<Department> InnerDeps)
        {
            this.name = Name;
            this.date = date;
            this.countofworkers = countofworkers;
            this.workers = workers;
            this.innerdeps = InnerDeps;
            
        }
        public Department(string Name, DateTime date, int countofworkers, List<Worker> workers, string gDepartmentName)
        {
            this.name = Name;
            this.date = date;
            this.countofworkers = countofworkers;
            this.workers = workers;
            this.gdepartmentname = gDepartmentName;
        }
        public Department(string Name, DateTime date, int countofworkers)
        {
            this.name = Name;
            this.date = date;
            this.countofworkers = countofworkers;
            

        }
        public Department(string Name, DateTime date, int countofworkers, string gDepartmentName)
        {
            this.name = Name;
            this.date = date;
            this.countofworkers = countofworkers;
            this.gdepartmentname = gDepartmentName;

        }

        #endregion

        #region Методы

        public string Print()
        {
            return $"Имя отдела:{this.name,8} Дата создания отдела:{this.date.ToShortDateString(),10}" +
                $" Количество сотрудников:{this.countofworkers,3} ";
        }

        #endregion

        #region Свойства
                
        /// <summary>
        /// Наименование отдела
        /// </summary>
        public string Name { get { return this.name; } set { this.name = value; } }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime Date { get { return this.date; } set { this.date = value; } }

        /// <summary>
        /// кол-во сотрудников
        /// </summary>
        public int Countofworkers { get { return this.countofworkers; } set { this.countofworkers = value; } }
        /// <summary>
        /// Лист с сотрудниками
        /// </summary>
        public List<Worker>Workers { get { return this.workers; } set { this.workers = value; } }
        /// <summary>
        /// Лист с внутр. отделами
        /// </summary>
        public List<Department> InnerDeps { get { return this.innerdeps; } set { this.innerdeps = value; } }
        /// <summary>
        /// Головной отдел для внутреннего
        /// </summary>
        public string gDepartmentName { get { return this.gdepartmentname; } set { this.gdepartmentname = value; } }




        #endregion

        #region Поля


        /// <summary>
        /// Наименование отдела
        /// </summary>
        private string name;

        /// <summary>
        /// Поле "Дата создания"
        /// </summary>
        private DateTime date;

        /// <summary>
        /// Поле "Кол-во сотрудников"
        /// </summary>
        private int countofworkers;
        /// <summary>
        /// Поле Лист с сотрудниками
        /// </summary>
        private List<Worker> workers;
        /// <summary>
        /// Поле внутр. отделы
        /// </summary>
        private List<Department> innerdeps;
        /// <summary>
        /// Поле головной отдел
        /// </summary>
        private string gdepartmentname;
        #endregion
    }
}
