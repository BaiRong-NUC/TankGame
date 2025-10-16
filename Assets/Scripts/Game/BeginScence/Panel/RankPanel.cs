using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class RankPanel : PanelBase<RankPanel>
{
    // 关联public控件对象
    public GUIButton returnBtn;

    // 排名数组
    public GameObject ranks;
    private List<GUILabel> rankLabels = new List<GUILabel>();
    // 玩家名数组,和排名数组一一对应
    public GameObject names;
    private List<GUILabel> nameLabels = new List<GUILabel>();
    // 分数数组,和排名数组一一对应
    public GameObject scores;
    private List<GUILabel> scoreLabels = new List<GUILabel>();
    // 通关时间数组,和排名数组一一对应
    public GameObject times;
    private List<GUILabel> timeLabels = new List<GUILabel>();

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
            this.rankLabels.Add(this.ranks.transform.GetChild(i).GetComponent<GUILabel>());
            this.nameLabels.Add(this.names.transform.GetChild(i).GetComponent<GUILabel>());
            this.scoreLabels.Add(this.scores.transform.GetChild(i).GetComponent<GUILabel>());
            this.timeLabels.Add(this.times.transform.GetChild(i).GetComponent<GUILabel>());
        }
        this.OnClose();
    }
}
