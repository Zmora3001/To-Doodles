using System.Collections.ObjectModel;
using To_Doodles;

namespace ToDoodles.Tests
{
    public class TaskManagerStub : ITaskManager
    {
        public ObservableCollection<Task> ActiveTasks { get; } = new();
        public ObservableCollection<Task> CompleteTasks { get; } = new();

        public void AddActiveTask(Task task) => ActiveTasks.Add(task);
        public void RemoveActiveTask(Task task) => ActiveTasks.Remove(task);
        public void AddCompleteTask(Task task) => CompleteTasks.Add(task);
        public void RemoveCompleteTask(Task task) => CompleteTasks.Remove(task);
        public virtual void ProcessTaskCompletion(Task task) { /* leer für Test */ }
    }
}