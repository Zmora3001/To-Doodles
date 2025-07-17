using System.Collections.Generic;

namespace To_Doodles;

public class TaskManager
{
    private readonly List<Task> _tasks = new();

    public void AddTask(Task task)
    {
        // TODO: Task hinzufügen und Persistenz anstoßen
        _tasks.Add(task);
    }

    public void RemoveTask(Task task)
    {
        // TODO: Task entfernen und Persistenz anstoßen
        _tasks.Remove(task);
    }

    public IReadOnlyList<Task> GetAllTasks() => _tasks.AsReadOnly();
}