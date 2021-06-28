
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
    class Menu
    {
        public static void MenuBar() {
            Console.WriteLine("\nВыберите необходимое действие и нажмите соответствующую кнопку. \n1. Открыть базу . " +
                "\n2. Создать нового сотрудника. \n3. Редактировать сотрудника \n4. Удалить сотрудника" +

                 " \n5. Создать новый отдел. \n6. Редактировать отдел \n7. Удалить отдел \n8. Сортировать сотрудников \n" +
                 "9. Сохранить в формате XML \n10. Сохранить в формате JSON \n11. Десериализировать из JSON \n12.Десериализировать из XML");
            string key = Console.ReadLine();
            switch(key)
            {
                case "1":

                    skelet.OpenDepartments(); 
          
                    break;
                case "2":
                    skelet.CreateWorker();
                    break;
                case "3":
                    skelet.EditWorker();
                    break;
                case "4":
                    skelet.DeleteWorker();
                    break;
                case "5":
                    skelet.CreateDepartment();
                    break;
                case "6":
                    skelet.EditDepartment();
                    break;
                case "7":
                    skelet.DeleteDepartment();
                    break;
                case "8":
                    SortMenu();
                    break;
                case "9":
                    skelet.XmlSerializer(skelet.departments);
                    break;
                case "10":
                    skelet.JsonSerializer(skelet.departments);
                    break;
                case "11":
                    skelet.XMLDeserialize();
                    break;
                case "12":
                    skelet.JsonDeserialize();
                    break;

            }
            MenuBar();
        }
        public static void SortMenu()
        {
            Console.WriteLine("Выберите отдел для сортировки");
            string depforsort = Console.ReadLine();
            Console.WriteLine("Выберите поле для сортировки: \n1. Номер \n2. Имя. \n3. Фамилия \n4. Возраст \n5. Зарплата");
            string fieldforsort = Console.ReadLine();
            skelet.SortWorkers(depforsort, fieldforsort);
        }
    }
}
