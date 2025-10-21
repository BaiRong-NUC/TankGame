using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPos : MonoBehaviour
{
    // 结束点脚本
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 玩家到达终点，弹出通关面板
            PassPanel.instance.OnOpen();
            // 暂停游戏
            Time.timeScale = 0f;
        }
    }
}
