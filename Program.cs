using System;
using System.Collections.Generic;

class ToDoApp
{
    class Task
    {
        public string Name { get; set; }
        public bool IsDone { get; set; }
    }

    static List<Task> tasks = new List<Task>();

    static void Main ()
    {
        Console.WriteLine("Welcome to To-DO-List App");

        while (true)
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Add a new task");
            Console.WriteLine("2. Display tasks");
            Console.WriteLine("3. Mark a task as complete");
            Console.WriteLine("4. Delete a task");
            Console.WriteLine("5. Exit");

            Console.Write("\nSelect an option (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    DisplayTasks();
                    break;
                case "3":
                    MarkTaskAsComplete();
                    break;
                case "4":
                    DeleteTask();
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }

        }
    }

    static void AddTask()
    {
        Console.WriteLine("Enter your task name: ");
        string taskName = Console.ReadLine();
        tasks.Add(new Task { Name = taskName, IsDone = false });
        Console.WriteLine($"Task '{taskName}' added.");
    }

    static void DisplayTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("There is no task");
            return;
        }

        Console.WriteLine("\nTo-Do-List: ");
        for (int i = 0; i < tasks.Count; i++)
        {
            string status = tasks[i].IsDone ? "[Completed]" : "[Pending]";
            Console.WriteLine($"{i + 1}. {status} {tasks[i].Name}");
        }
    }

    static void MarkTaskAsComplete()
    {
        DisplayTasks();
        Console.Write("Enter the number of the task to mark as complete: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks[taskNumber - 1].IsDone = true;
            Console.WriteLine($"Task '{tasks[taskNumber - 1].Name}' marked as complete.");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }


    static void DeleteTask()
    {
        DisplayTasks();
        Console.WriteLine("Enter the number of task that you want to delete");

        if (int.TryParse(Console.ReadLine() , out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            Console.WriteLine($"Task '{tasks[taskNumber - 1].Name}' deleted.");
            tasks.RemoveAt(taskNumber - 1); 
        }

        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }
}