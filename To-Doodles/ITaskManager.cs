using System.Collections.ObjectModel;

namespace To_Doodles;

public interface ITaskManager
{
    ObservableCollection<Task> ActiveTasks { get; }
    ObservableCollection<Task> CompleteTasks { get; }

    void AddActiveTask(Task task);
    void RemoveActiveTask(Task task);
    void AddCompleteTask(Task task);
    void RemoveCompleteTask(Task task);
    void ProcessTaskCompletion(Task task);
}