using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 游戏各种面板的基类,单例基类
// T 一定是一个引用类型
public class PanelBase<T> : MonoBehaviour where T : class
{
    private static T _instance;
    public static T instance => _instance;

    protected void Awake()
    {
        _instance = this as T;
    }

    // 面板打开
    public virtual void OnOpen()
    {
        gameObject.SetActive(true);
    }

    // 面板关闭
    public virtual void OnClose()
    {
        gameObject.SetActive(false);
    }
}
