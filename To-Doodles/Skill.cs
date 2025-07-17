namespace To_Doodles;

public class Skill
{
    public int Level { get; private set; } = 1;
    public int ReqExperienceTillNextLevel { get; private set; } = 100;
    public int ExperienceInLevel { get; private set; }
    public int ExperienceOverall { get; private set; }

    public void IncreaseLevel()
    {
        // TODO: Level erhöhen und Threshold anpassen
        Level++;
    }

    public void IncreaseExp(int amount)
    {
        // TODO: Erfahrung gutschreiben und Level‑Ups prüfen
        ExperienceOverall += amount;
        ExperienceInLevel += amount;
    }
}