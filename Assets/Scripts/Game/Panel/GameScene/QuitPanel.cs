using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : PanelBase<QuitPanel>
{
    public GUIButton btnQuit;
    public GUIButton btnCancel;
    public GUIButton btnClose;

    void Start()
    {
        // 回到菜单
        this.btnQuit.clickEvent += () =>
        {
            SceneManager.LoadScene("BeginScene");
        };
        // 取消退出
        this.btnCancel.clickEvent += () =>
        {
            this.OnClose();
        };
        // 关闭面板
        this.btnClose.clickEvent += () =>
        {
            this.OnClose();
        };

        this.OnClose(); // 默认关闭
    }

    public override void OnClose()
    {
        base.OnClose();
        // 关闭面板恢复游戏
        Time.timeScale = 1f;
    }
}
