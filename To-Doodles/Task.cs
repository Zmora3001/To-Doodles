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
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime? DueDate { get; set; }

    public void ToggleComplete()
    {
        // TODO: Umschalten des Status und ggf. Abschlusszeitpunkt setzen
        IsComplete = !IsComplete;
    }
}