using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class LevelResultComparator
{
    public List<LevelConfig> levelConfigs;

    public Grade GetLevelGrade(int levelID, double levelTimeInSeconds)
    {
        var levelConfig = levelConfigs.First(x => x.LevelID == levelID);

        if (levelTimeInSeconds <= levelConfig.levelPassTimeInSeconds)
            return Grade.Pass;
        else
            return Grade.F;
    }
}
