using System.Collections.ObjectModel;

namespace To_Doodles;

public class TaskManager
{
    private static readonly ObservableCollection<Task> activeTasks = new();
    private static readonly ObservableCollection<Task> completeTasks = new();
    private static int nextTaskId = 1;

    public TaskManager()
    {
        TaskStorage.Load(out var active, out var complete);
        
        foreach (var task in active)
            completeTasks.Add(task);
        
        foreach (var task in complete)
            completeTasks.Add(task);
    }

    // Methoden zum Hinzufügen und Entfernen von Aufgaben
    public static void AddActiveTask(Task task)
    {
        activeTasks.Add(task);
        TaskStorage.Save(activeTasks, completeTasks);
    }

    public static void RemoveActiveTask(Task task)
    {
        activeTasks.Remove(task);
        TaskStorage.Save(activeTasks, completeTasks);
    }

    public static void AddCompleteTask(Task task)
    {
        completeTasks.Add(task);
        TaskStorage.Save(activeTasks, completeTasks);
    }

    public static void RemoveCompleteTask(Task task)
    {
        completeTasks.Remove(task);
        TaskStorage.Save(activeTasks, completeTasks);
    }

    // Methode zum Erstellen einer neuen Aufgabe
    public static Task CreateNewTask(string title, string description, int wisdomExp, int patienceExp, int funExp, int creativityExp)
    {
        var newTask = new Task
        {
            Id = nextTaskId++,
            Title = title,
            Description = description,
            WisdomExp = wisdomExp,
            PatienceExp = patienceExp,
            FunExp = funExp,
            CreativityExp = creativityExp
        };
        AddActiveTask(newTask);
        return newTask;
    }
    
    // Getter für die Listen
    public IReadOnlyList<Task> GetActiveTasks() => activeTasks.AsReadOnly();
    public IReadOnlyList<Task> GetCompleteTasks() => completeTasks.AsReadOnly();
}