using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : PanelBase<GamePanel>
{
    // 关联public控件对象
    public GUILabel starLabel;
    public GUILabel timeLabel;

    public GUIButton quitBtn;
    public GUIButton settingBtn;

    public GUITexture healthyTexture;

    public float maxHpWidth = 573f;

    // 记录游玩时间
    [HideInInspector]
    public float gameTime = 0f;

    // 记录分数
    [HideInInspector]
    public int star = 0;

    void Start()
    {
        this.quitBtn.clickEvent += () =>
        {
            // 返回主菜单,弹出确定框
            QuitPanel.instance.OnOpen();

            // 弹出确定框暂停游戏
            Time.timeScale = 0f;
        };

        this.settingBtn.clickEvent += () =>
        {
            SettingPanel.instance.OnOpen();
            
            // 弹出设置框暂停游戏
            Time.timeScale = 0f;
        };
    }

    // 更新分数
    public void AddStar(int star)
    {
        this.star += star;
        this.starLabel.guiContent.text = this.star.ToString();
    }

    // 更新血量
    public void UpdateHp(int maxHp, int currentHp)
    {
        this.healthyTexture.guiPos.width = ((float)currentHp / maxHp) * this.maxHpWidth;
    }

    void Update()
    {
        this.gameTime += Time.deltaTime;

        // 将结果转为整数（向下取整，gameTime 为正数时 (int) 相当于 Floor）
        int hours = (int)(this.gameTime / 3600f);
        int minutes = (int)((this.gameTime % 3600f) / 60f);
        int seconds = (int)(this.gameTime % 60f);

        // 更新时间显示
        this.timeLabel.guiContent.text = "";
        if (hours > 0)
        {
            this.timeLabel.guiContent.text += hours + "时:";
        }
        if (minutes > 0 || hours > 0)
        {
            this.timeLabel.guiContent.text += minutes + "分:";
        }
        this.timeLabel.guiContent.text += seconds + "秒";
    }
}
