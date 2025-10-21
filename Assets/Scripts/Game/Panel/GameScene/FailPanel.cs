using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailPanel : PanelBase<FailPanel>
{
    public GUIButton retry;
    public GUIButton exit;

    void Start()
    {
        retry.clickEvent += () =>
        {
            //  取消游戏暂停
            Time.timeScale = 1f;
            // 重新加载当前场景
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        };

        exit.clickEvent += () =>
        {
            //  取消游戏暂停
            Time.timeScale = 1f;
            // 返回主菜单
            SceneManager.LoadScene("BeginScene");
        };

        this.OnClose();
    }
}
