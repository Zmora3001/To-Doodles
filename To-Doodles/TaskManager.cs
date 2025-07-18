using System.Collections.Generic;

namespace To_Doodles;

public class TaskManager
{
    private readonly List<Task> activeTasks = new();
    private readonly List<Task> completeTasks = new();
    
    public void AddActiveTask(Task task)
    {
        // TODO: Task hinzufügen und Persistenz anstoßen
        activeTasks.Add(task);
    }

    public void RemoveActiveTask(Task task)
    {
        // TODO: Task entfernen und Persistenz anstoßen
        activeTasks.Remove(task);
    }

    public void AddCompleteTask(Task task)
    {
        // TODO: Task hinzufügen und Persistenz anstoßen
        activeTasks.Add(task);
    }

    public void RemoveCompleteTask(Task task)
    {
        // TODO: Task entfernen und Persistenz anstoßen
        activeTasks.Remove(task);
    }
    
    public IReadOnlyList<Task> GetActiveTasks() => activeTasks.AsReadOnly();
    public IReadOnlyList<Task> GetCompleteTasks() => completeTasks.AsReadOnly();
}