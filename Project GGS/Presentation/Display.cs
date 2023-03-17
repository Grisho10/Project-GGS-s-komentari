using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GGS
{
    class Display
    {
        private int closeOperationId = 8;//do kolkoto komandi ime!
        private NoteCreate noteCreate = new NoteCreate();
        public Display()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('*', 40));
            Console.WriteLine("*" + new string(' ', 17) + "NOTES" + new string(' ', 16) + "*");
            Console.WriteLine(new string('*', 40));

            Console.WriteLine("1. Показване на всички бележки");
            Console.WriteLine("2. Добавяне на бележка");
            Console.WriteLine("3. Обнови бележка");
            Console.WriteLine("4. Извличане на бележка по ID");
            Console.WriteLine("5. Изтриване на бележка по ID");
            Console.WriteLine("6. ");
        }
        private void Input()
        {
            var operation = 1;//-1
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation <= closeOperationId);
        }
        
        private void Delete()
        {
            Console.WriteLine("Въведи ID за изтриване: ");
            int id = int.Parse(Console.ReadLine());
            noteCreate.Delete(id);
            Console.WriteLine("Готово!");
        }
        
        private void Fetch()
        {
            Console.WriteLine("Въведи ID за извличане: ");
            int id = int.Parse(Console.ReadLine());
            Note note = noteCreate.Get(id);
            if (note != null)
            {
                Console.WriteLine(new string('*', 40));
                Console.WriteLine("ID: " + note.Id);
                Console.WriteLine("Заглавие на бележката: " + note.Title);
                Console.WriteLine("Описание: " + note.Description);
                Console.WriteLine("Колко важна е: " + note.Level);
                Console.WriteLine(new string('*', 40));
            }
        }
        
        private void Update()
        {
            Console.WriteLine("Въведи ID за обновяване: ");
            int id = int.Parse(Console.ReadLine());
            Note note = noteCreate.Get(id);
            if (note != null)
            {
                Console.WriteLine("Въведи заглавие: ");
                note.Title = Console.ReadLine();
                Console.WriteLine("Въведи описание: ");
                note.Description = Console.ReadLine();
                Console.WriteLine("Въведи важнота(1/10): ");
                note.Level = int.Parse(Console.ReadLine());//
                noteCreate.Update(note);
            }
            else
            {
                Console.WriteLine("Бележката не е намерена!");
            }
        }

        private void Add()
        {
            Note note = new Note();
            Console.WriteLine("Въведи заглавие: ");
            note.Title = Console.ReadLine();
            Console.WriteLine("Въведи описание: ");
            note.Description = Console.ReadLine();
            Console.WriteLine("Въведи важност(1/10): ");
            note.Level = int.Parse(Console.ReadLine());
            noteCreate.Add(note);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('*', 40));
            Console.WriteLine("*" + new string(' ', 17) + "NOTES" + new string(' ', 16) + "*");
            Console.WriteLine(new string('*', 40));
            var notes = noteCreate.GetAll();
            foreach (var item in notes)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.Id, item.Title, item.Description, item.Level);
            }
        }
        



    }
}
