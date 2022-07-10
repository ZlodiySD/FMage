using System;
using System.Collections.Generic;

[Serializable]
public class TeacherMessageChooser
{
    public List<TeacherMessageConfig> teacherMessageConfigs;

    public string GetMessage(Grade grade)
    {
        var index = UnityEngine.Random.Range(0, (teacherMessageConfigs.Count - 1));
        string msg = "404";
        switch (grade)
        {
            case Grade.F:
                msg = teacherMessageConfigs[index].FGradeMessage;
                break;
            case Grade.Pass:
                msg = teacherMessageConfigs[index].PassGradeMessage;
                break;
        }
        return msg;
    }
}