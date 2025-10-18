using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 排行榜单条数据
public class RankData
{
    public int score; // 分数
    public float time; // 通关时间
    public string playerName; // 玩家名称

    public RankData() { }
    public RankData(string playerName, int score, float time)
    {
        this.score = score;
        this.time = time;
        this.playerName = playerName;
    }
}

public class RankList
{
    public List<RankData> rankDatas = new List<RankData>();
}
