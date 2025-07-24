using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace To_Doodles;

public class Task : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private int _id;
    private string _title = string.Empty;
    private string _description = string.Empty;
    private int _wisdomExp;
    private int _patienceExp;
    private int _funExp;
    private int _creativityExp;
    private bool _isComplete;
    public bool WasCompleted { get; private set; }

    public int Id 
    { 
        get => _id; 
        set => SetProperty(ref _id, value); 
    }

    public string Title 
    { 
        get => _title; 
        set => SetProperty(ref _title, value); 
    }

    public string Description 
    { 
        get => _description; 
        set => SetProperty(ref _description, value); 
    }

    public int WisdomExp 
    { 
        get => _wisdomExp; 
        set => SetProperty(ref _wisdomExp, value); 
    }

    public int PatienceExp 
    { 
        get => _patienceExp; 
        set => SetProperty(ref _patienceExp, value); 
    }

    public int FunExp 
    { 
        get => _funExp; 
        set => SetProperty(ref _funExp, value); 
    }

    public int CreativityExp 
    { 
        get => _creativityExp; 
        set => SetProperty(ref _creativityExp, value); 
    }

    public bool IsComplete 
    { 
        get => _isComplete; 
        set => SetProperty(ref _isComplete, value); 
    }

    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public ITaskManager? Manager { get; set; }

    // toggelt den Status der Aufgabe und bewegt sie zwischen aktiv und abgeschlossen
    public void ToggleComplete()
    {
        if (Manager == null)
            throw new InvalidOperationException("TaskManager not set");
        var manager = Manager;

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