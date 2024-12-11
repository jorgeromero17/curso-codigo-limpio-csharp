using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.Add) //Casting a menu
                {
                    ShowAddMenu();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowRemoveMenu();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowTaskListMenu();
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string menuSelection = Console.ReadLine();
            if (int.TryParse(menuSelection, out int option))
            {
                return option;
            }
            return (int)Menu.Continue;
        }

        public static void ShowRemoveMenu()
        {
            try
            {
                // Show current taks
                ShowTaskListMenu();
                if(TaskList.Count > 0) {
                    Console.WriteLine("Ingrese el número de la tarea a remover: ");
                    string taskNumberToDelete = Console.ReadLine();
                    // Remove one position
                    int indexToRemove = Convert.ToInt32(taskNumberToDelete) - 1;

                    if (indexToRemove > 0 && indexToRemove < TaskList.Count)
                    {
                        string task = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine($"Tarea '{task}' eliminada");
                    }
                    else
                    {
                        Console.WriteLine("Número de tarea seleccionado es inválido");
                    }
                }
            }
            catch (Exception)
            {   
                Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
            }
        }

        public static void ShowAddMenu()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();

                if (!string.IsNullOrEmpty(task))
                {
                    TaskList.Add(task);
                    Console.WriteLine("Tarea registrada");
                }
                else
                {
                    Console.WriteLine("Se requiere el nombre de la tarea.");
                }
                
            }
            catch (Exception)
            {
                Console.WriteLine("Ha ocurrido un error al agregar la tarea");
            }
        }

        public static void ShowTaskListMenu()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                Console.WriteLine("----------------------------------------");
                var indexTask = 1;
                TaskList.ForEach( element => Console.WriteLine(indexTask++ + ". " + element));
                Console.WriteLine("----------------------------------------");
            }
        }
    }

    public enum Menu 
    {   
        Continue = 0,
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4,
    }
}
