using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectView : View
{
    public List<LevelBtnView> levelBtnViews;

    public LevelBtnView levelBtnPrefab;

    public Transform btnHolder;

    public void Init(List<LevelData> levelDatas)
    {
        foreach (var level in levelDatas)
        {
            var btn = Instantiate(levelBtnPrefab, btnHolder);
            btn.Init(this, level);
            levelBtnViews.Add(btn);
        }
    }

    public void LevelSelected(int levelId)
    {

    }
}
