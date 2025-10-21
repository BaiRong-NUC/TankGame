using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassPanel : PanelBase<PassPanel>
{
    public GUIButton btnSure;
    public GUIInput inputName;

    void Start()
    {
        btnSure.clickEvent += () =>
        {
            //  取消游戏暂停
            Time.timeScale = 1f;
            //  将数据记录到排行榜上,回到主场景上
            GameDataManage.instance.AddRankData(inputName.guiContent.text, GamePanel.instance.star, GamePanel.instance.gameTime);

            // 返回主菜单
            SceneManager.LoadScene("BeginScene");
        };

        this.OnClose();
    }
}
