using System.ComponentModel;

namespace To_Doodles;

public class Task : INotifyPropertyChanged
{
    public int Id { get; init; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool WasCompleted { get; set; }
    public bool IsComplete
    {
        get => _isComplete;
        set
        {
            if (_isComplete != value)
            {
                _isComplete = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsComplete)));
            }
        }
    }
    private bool _isComplete;
    public event PropertyChangedEventHandler? PropertyChanged;

    // Experience rewards
    public int WisdomExp { get; init; }
    public int PatienceExp { get; init; }
    public int FunExp { get; init; }
    public int CreativityExp { get; init; }

    // Optional timestamps
    // public DateTime CreatedAt { get; init; } = DateTime.Now;
    // public DateTime? DueDate { get; set; }

    // toggelt den Status der Aufgabe und bewegt sie zwischen aktiv und abgeschlossen
    public void ToggleComplete()
    {
        var manager = MainWindow.ManagerInstance;
        if (manager == null)
            throw new InvalidOperationException("TaskManager instance not initialized");

        
        if (IsComplete)
        {
            IsComplete = false;
            manager.RemoveCompleteTask(this);
            if (!manager.ActiveTasks.Contains(this))
                manager.AddActiveTask(this);
        }
        else
        {
            IsComplete = true;
            
            if (!WasCompleted)
            {
                WasCompleted = true;
                manager.ProcessTaskCompletion(this); // Verarbeitet die Aufgabe, wenn sie zum ersten Mal abgeschlossen wird
            }
            
            manager.RemoveActiveTask(this);
            if (!manager.CompleteTasks.Contains(this))
                manager.AddCompleteTask(this);
        }
    }
}