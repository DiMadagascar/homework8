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
            Console.WriteLine("\nВыберите необходимое действие и нажмите соответствующую кнопку. 1. Открыть базу . " +
                "2. Создать нового сотрудника. 3. Редактировать сотрудника 4. Удалить сотрудника"+
    
                 " 5. Создать новый отдел. 6. Редактировать отдел 7. Удалить отдел 8. Сортировать сотрудников 9. Сохранить в формате XML"+

                "10. Сохранить в формате JSON 11. Десериализировать из JSON 12.Десериализировать из XML");
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
            Console.WriteLine("Выберите поле для сортировки: 1. Номер 2. Имя. 3. Фамилия 4. Возраст 5. Зарплата");
            string fieldforsort = Console.ReadLine();
            skelet.SortWorkers(depforsort, fieldforsort);
        }
    }
}
