﻿namespace To_Doodles;

public class Skill
{
    public int Level { get; private set; } = 1;
    public int ReqExperienceTillNextLevel { get; private set; } = 100;
    public int ExperienceInLevel { get; private set; }
    public int ExperienceOverall { get; private set; }

    public void IncreaseLevel()
    {
        ExperienceInLevel -= ReqExperienceTillNextLevel;
        Level++;
        ReqExperienceTillNextLevel = CalculateNextLevelThreshold();
    }

    public void IncreaseExp(int amount)
    {
        ExperienceOverall += amount;
        ExperienceInLevel += amount;

        if (ExperienceInLevel >= ReqExperienceTillNextLevel)
        {
            IncreaseLevel();
        }
    }

    // Leveling Formula aus EldenRing©
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