﻿List<string> TaskList = new List<string>();

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
    
int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    string menuSelection = Console.ReadLine();
    if (int.TryParse(menuSelection, out int option))
    {
        return option;
    }
    return (int)Menu.Continue;
}

void ShowRemoveMenu()
{
    try
    {
        ShowTaskListMenu();
        if(TaskList.Count > 0) {
            Console.WriteLine("Ingrese el número de la tarea a remover: ");
            string taskNumberToDelete = Console.ReadLine();
            // Remove one position because the array start in 0
            int indexToRemove = Convert.ToInt32(taskNumberToDelete) - 1;

            if (indexToRemove >= 0 && indexToRemove < TaskList.Count)
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

void ShowAddMenu()
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

void ShowTaskListMenu()
{
    if (TaskList?.Count > 0)
    {   
        Console.WriteLine("----------------------------------------");
        var indexTask = 1;
        TaskList.ForEach( element => Console.WriteLine($"{indexTask++}. {element}"));
        Console.WriteLine("----------------------------------------");
    } 
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}

    enum Menu 
    {   
        Continue = 0,
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4,
    }

