using System;
using System.ComponentModel;

namespace To_Doodles;

public class Task : INotifyPropertyChanged
{
    public int Id { get; init; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
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
    private bool _isComplete = false;
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
        if (IsComplete)
        {
            IsComplete = false;
            TaskManager.RemoveCompleteTask(this);
            if (!TaskManager.ActiveTasks.Contains(this))
                TaskManager.AddActiveTask(this);
        }
        else
        {
            IsComplete = true;
            TaskManager.RemoveActiveTask(this);
            if (!TaskManager.CompleteTasks.Contains(this))
                TaskManager.AddCompleteTask(this);
        }
    }
}