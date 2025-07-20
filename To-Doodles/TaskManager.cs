namespace To_Doodles;

public class TaskManager
{
    private static readonly List<Task> activeTasks = new();
    private static readonly List<Task> completeTasks = new();

    public TaskManager()
    {
        TaskStorage.Load(out var active, out var complete);
        activeTasks.AddRange(active);
        completeTasks.AddRange(complete);
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

    public IReadOnlyList<Task> GetActiveTasks() => activeTasks.AsReadOnly();
    public IReadOnlyList<Task> GetCompleteTasks() => completeTasks.AsReadOnly();
}