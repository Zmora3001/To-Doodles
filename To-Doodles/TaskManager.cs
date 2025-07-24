using System.Collections.ObjectModel;

namespace To_Doodles;

public class TaskManager
{
    private static readonly ObservableCollection<Task> activeTasks = new();
    private static readonly ObservableCollection<Task> completeTasks = new();
    
    public ObservableCollection<Task> ActiveTasks => activeTasks;
    public ObservableCollection<Task> CompleteTasks => completeTasks;
    
    private static int nextTaskId = 1;
    
    private AppState? AppState { get; set; }

public TaskManager()
    {
        TaskStorage.Load(out var active, out var complete, out var appState);
        
        foreach (var task in active)
            activeTasks.Add(task);
        
        foreach (var task in complete)
            completeTasks.Add(task);
        
        AppState = appState;
    }

    // Methoden zum Hinzufügen und Entfernen von Aufgaben
    public void AddActiveTask(Task task)
    {
        activeTasks.Add(task);
        SaveState();
    }

    public void RemoveActiveTask(Task task)
    {
        activeTasks.Remove(task); 
        SaveState();
    }

    public void AddCompleteTask(Task task)
    {
        completeTasks.Add(task);
        SaveState();
    }

    public void RemoveCompleteTask(Task task)
    {
        completeTasks.Remove(task);
        SaveState();
    }

    // Methode zum Erstellen einer neuen Aufgabe
    public Task CreateNewTask(string title, string description, int wisdomExp, int patienceExp, int funExp, int creativityExp)
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

    public void DeleteTask(Task task)
    {
        if (activeTasks.Contains(task))
        {
            RemoveActiveTask(task);
        }
        else if (completeTasks.Contains(task))
        {
            RemoveCompleteTask(task);
        }
    }
    
    private void SaveState()
    {
        TaskStorage.Save(ActiveTasks, CompleteTasks, AppState!);
    }

    public void LoadState()
    {
        TaskStorage.Load(out var tempActiveTasks, out var tempCompleteTasks, out var tempAppState);
        ActiveTasks.Clear();
        CompleteTasks.Clear();
        foreach (var task in tempActiveTasks)
            ActiveTasks.Add(task);
        foreach (var task in tempCompleteTasks)
            CompleteTasks.Add(task);
        AppState = tempAppState;
    }

    public void ProcessTaskCompletion(Task task)
    {
        AppState?.ProcessTask(task);
    }

    // Getter für die Listen
    public IReadOnlyList<Task> GetActiveTasks() => activeTasks.AsReadOnly();
    public IReadOnlyList<Task> GetCompleteTasks() => completeTasks.AsReadOnly();
}