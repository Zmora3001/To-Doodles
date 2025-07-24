using System.Text.Json.Serialization;

namespace To_Doodles;

public class Skill
{
    [JsonInclude]
    public int Level { get; private set; } = 1;
    [JsonInclude]
    public int ReqExperienceTillNextLevel { get; private set; } = 100;
    [JsonInclude]
    public int ExperienceInLevel { get; private set; }
    [JsonInclude]
    public int ExperienceOverall { get; private set; }

    // erhöht das Level um 1, wenn die Erfahrung im aktuellen Level die benötigte Erfahrung zum Aufsteigen erreicht
    public void IncreaseLevel()
    {
        ExperienceInLevel -= ReqExperienceTillNextLevel;
        Level++;
        ReqExperienceTillNextLevel = CalculateNextLevelThreshold();
    }

    // erhöht die Erfahrung um den angegebenen Betrag und prüft, ob das Level erhöht werden muss
    public void IncreaseExp(int amount)
    {
        ExperienceOverall += amount;
        ExperienceInLevel += amount;

        while (ExperienceInLevel >= ReqExperienceTillNextLevel)
        {
            IncreaseLevel();
        }
    }

    // Leveling Formel aus EldenRing©
    public int CalculateNextLevelThreshold()
    {
        var x = ((Level + 81) - 92) * 0.02;
        if (x < 0)
        {
            x = 0;
        }

        var reqXp = Math.Pow((x + 0.1) * (Level + 81), 2.0) + 1;
        
        return (int)reqXp;
    }
}