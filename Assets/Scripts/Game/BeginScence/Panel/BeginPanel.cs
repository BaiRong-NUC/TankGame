using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : PanelBase<BeginPanel>
{
    public GUIButton startButton;
    public GUIButton settingButton;
    public GUIButton exitButton;

    public GUIButton rankButton;

    void Start()
    {
        // 开始游戏按钮
        startButton.clickEvent += () =>
        {
            //切换场景
            SceneManager.LoadScene("GameScene");
        };

        // 设置按钮
        settingButton.clickEvent += () =>
        {
            print("设置按钮被点击");
        };

        // 退出按钮
        exitButton.clickEvent += () =>
        {
            print("退出按钮被点击");
            Application.Quit();
        };

        // 排行榜按钮
        rankButton.clickEvent += () =>
        {
            print("排行榜按钮被点击");
        };
    }
}
