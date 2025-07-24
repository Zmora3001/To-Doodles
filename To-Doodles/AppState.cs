namespace To_Doodles;

public class AppState
{
    public Skill Wisdom { get; set; } = new();
    public Skill Patience { get; set; } = new();
    public Skill Fun { get; set; } = new();
    public Skill Creativity { get; set; } = new();

    public void ProcessTask(Task task)
    {
        Wisdom.IncreaseExp(task.WisdomExp);
        Patience.IncreaseExp(task.PatienceExp);
        Fun.IncreaseExp(task.FunExp);
        Creativity.IncreaseExp(task.CreativityExp);
    }
}
