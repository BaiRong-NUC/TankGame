using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

public class RankPanel : PanelBase<RankPanel>
{
    // 关联public控件对象
    public GUIButton returnBtn;

    // // 排名数组
    // public GameObject ranks;
    // private List<GUILabel> rankLabels = new List<GUILabel>();
    // 玩家名数组,和排名数组一一对应
    public GameObject names;
    private List<Text> nameLabels = new List<Text>();
    // 分数数组,和排名数组一一对应
    public GameObject scores;
    private List<Text> scoreLabels = new List<Text>();
    // 通关时间数组,和排名数组一一对应
    public GameObject times;
    private List<Text> timeLabels = new List<Text>();

    public int rankSize = 10; // 显示前10名
    void Start()
    {
        //点击返回按钮
        this.returnBtn.clickEvent += () =>
        {
            this.OnClose();
            BeginPanel.instance.OnOpen();
        };
        // 初始化数组
        for (int i = 0; i < this.rankSize; i++)
        {
            // this.rankLabels.Add(this.ranks.transform.GetChild(i).GetComponent<GUILabel>());
            this.nameLabels.Add(this.names.transform.GetChild(i).GetComponent<Text>());
            this.scoreLabels.Add(this.scores.transform.GetChild(i).GetComponent<Text>());
            this.timeLabels.Add(this.times.transform.GetChild(i).GetComponent<Text>());
        }
        this.OnClose();
    }

    public override void OnOpen()
    {
        base.OnOpen();
        UpdateRank();
    }

    // 更新排名数据
    public void UpdateRank()
    {
        // 获取排行榜数据,更新面板
        List<RankData> rankDatas = GameDataManage.instance.rankList.rankDatas;

        for (int i = 0; i < rankDatas.Count; i++)
        {
            // this.rankLabels[i].text = (i + 1).ToString();
            this.nameLabels[i].text = rankDatas[i].playerName;
            this.scoreLabels[i].text = rankDatas[i].score.ToString();
            // 存储的时间是秒,格式化为 时:分:秒.毫秒
            float time = (int)rankDatas[i].time;
            this.timeLabels[i].text = "";
            if (time / 3600 > 0)
            {
                this.timeLabels[i].text += time / 3600 + "时:";
            }
            if ((time % 3600) / 60 > 0 || time / 3600 > 0)
            {
                this.timeLabels[i].text += (time % 3600) / 60 + "分:";
            }
            this.timeLabels[i].text += (time % 60) + "秒";
        }
    }
}
