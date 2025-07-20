using System;

namespace To_Doodles;

public class Task
{
    public int Id { get; init; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsComplete { get; private set; }

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
        if (IsComplete) // Wenn die Aufgabe abgeschlossen ist, wird sie wieder aktiv
        {
            TaskManager.AddActiveTask(this);
            TaskManager.RemoveCompleteTask(this);
        }
        else // Wenn die Aufgabe aktiv ist, wird sie abgeschlossen
        {
            TaskManager.AddCompleteTask(this);
            TaskManager.RemoveActiveTask(this);
        }
        IsComplete = !IsComplete;
    }
}