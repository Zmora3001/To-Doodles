namespace To_Doodles;

public class AppState
{
    private Skill Wisdom { get; } = new();
    private Skill Patience { get; } = new();
    private Skill Fun { get; } = new();
    private Skill Creativity { get; } = new();

    public void ProcessTask(Task task)
    {
        Wisdom.IncreaseExp(task.WisdomExp);
        Patience.IncreaseExp(task.PatienceExp);
        Fun.IncreaseExp(task.FunExp);
        Creativity.IncreaseExp(task.CreativityExp);
    }

    public Skill GetWisdom() => Wisdom;
    public Skill GetPatience() => Patience;
    public Skill GetFun() => Fun;
    public Skill GetCreativity() => Creativity;
}