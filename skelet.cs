using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace Homework_08
{
    class skelet
    {
        //Глобальная переменная для вызова случайных чисел
        public static Random r = new Random();
        public static List<Department> departments = new List<Department>();
        public static List<Department> InnerDeps = new List<Department>();
        public static List<Worker> workers = new List<Worker>();

        /// <summary>
        /// Метод для вывода случайной даты
        /// </summary>
        /// <returns></returns>
        public static DateTime RandomDate()
        {

            DateTime randomdate = new DateTime(2000, 01, 01);
            int range = (DateTime.Today - randomdate).Days;
            randomdate = randomdate.AddDays(r.Next(range)).
                 AddHours(r.Next(0, 24)).AddMinutes(r.Next(0, 60)).AddSeconds(r.Next(0, 60));
            return randomdate;

        }

        /// <summary>
        /// Метод первоначального создания и заполнения коллекций сотрудников и департаментов
        /// </summary>
       public static void CreateCollections()

        {
           


            ///Создаем и заполняем лист 100 сотрудниками
            for (int i = 1; i <= 100; i++)
            {
                workers.Add(new Worker(i, $"Имя_{i}", $"Фамилия_{i}", r.Next(20, 50), r.Next(1000, 10000), $"Отдел_{r.Next(1, 7)}"));
            }


            ///Создаем и заполняем внутренние отделы 
            for (int i = 3; i <= 6; i++)
            {
                List<Worker> workertemplist = new List<Worker>();//Временный лист для выборки сотрудников i-го отдела
                var selectedWorkers = from user in workers
                                      where user.DepartmentName.Contains($"{i}")
                                      select user;
                foreach (Worker user in selectedWorkers)
                {
                    workertemplist.Add(user);
                }

                InnerDeps.Add(new Department($"Отдел_{i}", RandomDate(), workertemplist.Count,
             workertemplist,$"Отдел_{r.Next(1,3)}"));

            }
            ///Создаем и заполняем головные отделы  
            ///
            for (int i = 1; i <= 2; i++)
            {

                List<Worker> workertemplist = new List<Worker>();//Временный лист для выборки сотрудников i-го отдела
                var selectedWorkers = from user in workers
                                      where user.DepartmentName.Contains($"{i}")
                                      select user;
                foreach (Worker user in selectedWorkers)
                {
                    workertemplist.Add(user);
                }
                List<Department> templistdepartments = new List<Department>();//Временный лист для выборки вложенных отделов
                
                
                    var selectedDepartments = from deps in InnerDeps
                                              where (deps.gDepartmentName.Contains($"{i}"))
                                              select deps;
                    foreach (Department deps in selectedDepartments)
                    {
                        templistdepartments.Add(deps);
                    }
                
               


                departments.Add(new Department($"Отдел_{i}", RandomDate(), workertemplist.Count,
             workertemplist, templistdepartments));

            }

           
        }
        /// <summary>
        /// Метод xml сериализации
        /// </summary>
        /// <param name="departments"></param>
       public static void XmlSerializer(List<Department> departments)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Department>));

            using (FileStream fs = new FileStream("departments.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, departments);
            }
        }
        /// <summary>
        /// Метод json сериализации
        /// </summary>
        /// <param name="departments"></param>
        public static void JsonSerializer(List<Department> departments)
        {
            string json = JsonConvert.SerializeObject(departments);
            File.WriteAllText("departments.json", json);
        }

        public static void JsonDeserialize()
        {
            List<Department> departments = new List<Department>();
            string json = File.ReadAllText("departments.json");
            departments = JsonConvert.DeserializeObject<List<Department>>(json);
                       
        }

        public static void XMLDeserialize()
        {
            List<Department> departments = new List<Department>();
            
            // Создаем сериализатор на основе указанного типа 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Department>));

            // Создаем поток для чтения данных
            Stream fStream = new FileStream("departments.json", FileMode.Open, FileAccess.Read);

            // Запускаем процесс десериализации
            departments = xmlSerializer.Deserialize(fStream) as List<Department>;

            // Закрываем поток
            fStream.Close();
        }
        /// <summary>
        /// Вывод на печать всех данных
        /// </summary>
        public static void OpenDepartments()
        {
            foreach (var d in departments)
            {
                Console.WriteLine(d.Print());
                var selectedWorkers = from user in workers
                                      where user.DepartmentName == d.Name
                                      select user;
                if (selectedWorkers != null)
                {
                    foreach (Worker user in selectedWorkers)
                    { Console.WriteLine($"\t{ user.Print()}"); }
                }
                if (d.InnerDeps != null)
                {
                    foreach (var id in d.InnerDeps)

                    {
                        Console.WriteLine($"\t{id.Print()}");
                        selectedWorkers = from user in workers
                                          where user.DepartmentName == id.Name
                                          select user;
                        if (selectedWorkers != null)
                        {
                            foreach (Worker user in selectedWorkers)
                            { Console.WriteLine($"\t\t{ user.Print()}"); }
                        }
                    }
                }
            }
           
        }
        /// <summary>
        /// Создание сотрудника
        /// </summary>
        public static void CreateWorker()
        {
            int N = (workers.Last()).N + 1;
            Console.WriteLine("Введите имя сотрудника");
            string FirstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию сотрудника");
            string LastName = Console.ReadLine();
            Console.WriteLine("Возраст");
            int Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Зарплату");
            int Salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Номер отдела");
            string DepartmentName = Console.ReadLine();
            workers.Add(new Worker(N, FirstName, LastName, Age, Salary, $"Отдел_{DepartmentName}"));
        }
        /// <summary>
        /// редактирование данных сотрудника
        /// </summary>
        public static void EditWorker()
        {
            Console.WriteLine("Введите номер сотрудника, чьи данные Вы хотите редактировать");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Теперь введите новые данные сотрудника");
            Console.WriteLine("Введите имя сотрудника");
            string FirstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию сотрудника");
            string LastName = Console.ReadLine();
            Console.WriteLine("Возраст");
            int Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Зарплату");
            int Salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Номер отдела");
            string DepartmentName = Console.ReadLine();
            for(int i=0;i<workers.Count;i++)
            {
                if(workers[i].N==N)
                {
                    workers[i].FirstName = FirstName;
                    workers[i].LastName = LastName;
                    workers[i].Age = Age;
                    workers[i].Salary = Salary;
                    workers[i].DepartmentName = $"Отдел_{DepartmentName}";
                    break;
                }

            }

            
        }
        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        public static void DeleteWorker()
        {
            Console.WriteLine("Введите номер сотрудника, чьи данные Вы хотите удалить");
            int N = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < workers.Count; i++)
            {
                if (workers[i].N == N)
                {
                    workers.RemoveAt(i);
                    break;
                }
                

            }
        }
        /// <summary>
        /// Создание отдела
        /// </summary>
        public static void CreateDepartment()
        {
            
            Console.WriteLine("Введите номер отдела");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите дату создания отдела");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Введите количество сотрудников");
            int col = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Отдел является головным(вбейте 1) или будет в составе другого отдела(вбейте 2)?");
            string key = Console.ReadLine();
            if (key == "1")
            {
                departments.Add(new Department($"Отдел_{N}", date, col));
               
            }
            else
            {
                Console.WriteLine("В состав какого отдела его включить?");
                string gDepartmentName = $"Отдел_{Console.ReadLine()}";
               
           
                for(int i=0;i<departments.Count;i++)
                {
                    
                        if (departments[i].Name.Contains(gDepartmentName))
                        {
                            int index = i;
                            departments[index].InnerDeps.Add(new Department($"Отдел_{N}", date, col, gDepartmentName));
                       
                            break;
                        }
                    
                }
                InnerDeps.Add(new Department($"Отдел_{N}", date, col, gDepartmentName));



            }
        }
        /// <summary>
        /// редактирование отдела
        /// </summary>
        public static void EditDepartment()
        {
            Console.WriteLine("Введите номер отдела, чьи данные Вы хотите редактировать");
            string N = $"Отдел_{Console.ReadLine()}";
            Console.WriteLine("Теперь введите новые данные ");
            Console.WriteLine("Введите номер отдела");
            int No= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите дату создания отдела");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Введите количество сотрудников");
            int col = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].Name==N)
                {
                    departments[i].Name = $"Имя_{No}";
                    departments[i].Date = date;
                    departments[i].Countofworkers = col;
                    break;
                }
            }
            for (int i = 0;i< InnerDeps.Count;i++)
            {
                if (InnerDeps[i].Name == N)
                {
                    InnerDeps[i].Name = $"Отдел_{No}";
                    InnerDeps[i].Date = date;
                    InnerDeps[i].Countofworkers = col;
                    
                    break;
                }
            }
            

        }
        /// <summary>
        /// Удаление отдела
        /// </summary>
        public static void DeleteDepartment()
        {
            Console.WriteLine("Введите номер отдела, который Вы хотите удалить");
            string N =Console.ReadLine();
            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].Name.Contains(N))
                {
                    departments.RemoveAt(i);
                    
                    break;
                }


            }
        }
        /// <summary>
        /// Метод для сортировки сотрудников по полям
        /// </summary>
        /// <param name="depforsort"></param>
        /// <param name="fieldforsort"></param>
        public static void SortWorkers(string depforsort, string fieldforsort)
        {
            var selectedWorkers = from user in workers
                                 where user.DepartmentName.Contains($"{depforsort}")
                                 select user;
            IEnumerable<Worker> sortworkers;
            switch (fieldforsort)
            {
                case "1":
                    sortworkers = selectedWorkers.OrderBy(worker => worker.N);
                    break;
                case "2":
                    sortworkers = selectedWorkers.OrderBy(worker => worker.FirstName);
                    break;
                case "3":
                    sortworkers = selectedWorkers.OrderBy(worker => worker.LastName);
                    break;
                case "4":
                    sortworkers = selectedWorkers.OrderBy(worker => worker.Age);
                    break;
                case "5":
                    sortworkers = selectedWorkers.OrderBy(worker => worker.Salary);
                    break;

            }
            


        }
    }
       
    }

