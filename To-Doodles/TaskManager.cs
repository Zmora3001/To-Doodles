namespace To_Doodles;

public class TaskManager
{
    private readonly List<Task> activeTasks = new();
    private readonly List<Task> completeTasks = new();

    public TaskManager()
    {
        TaskStorage.Load(out var active, out var complete);
        activeTasks.AddRange(active);
        completeTasks.AddRange(complete);
    }

    public void AddActiveTask(Task task)
    {
        activeTasks.Add(task);
        TaskStorage.Save(activeTasks, completeTasks);
    }

    public void RemoveActiveTask(Task task)
    {
        activeTasks.Remove(task);
        TaskStorage.Save(activeTasks, completeTasks);
    }

    public void AddCompleteTask(Task task)
    {
        completeTasks.Add(task);
        TaskStorage.Save(activeTasks, completeTasks);
    }

    public void RemoveCompleteTask(Task task)
    {
        completeTasks.Remove(task);
        TaskStorage.Save(activeTasks, completeTasks);
    }

    public IReadOnlyList<Task> GetActiveTasks() => activeTasks.AsReadOnly();
    public IReadOnlyList<Task> GetCompleteTasks() => completeTasks.AsReadOnly();
}