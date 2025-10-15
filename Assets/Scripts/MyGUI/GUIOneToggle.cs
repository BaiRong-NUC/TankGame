using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIOneToggle : MonoBehaviour
{
    // 单选框,通过封装GUIToggle实现单选框
    public List<GUIToggle> toggleList = new List<GUIToggle>(); // 存放所有单选框

    private GUIToggle lastOnToggle = null; // 上一次被选中的单选框

    void Start()
    {
        if (this.toggleList.Count == 0)
        {
            return;
        }
        // 一个变成true,其他都变成false
        for (int i = 0; i < toggleList.Count; i++)
        {
            int index = i;
            toggleList[i].toggleEvent += (isOn) =>
            {
                // 当某个组件变成true,其他都变成false
                if (isOn)
                {
                    for (int j = 0; j < toggleList.Count; j++)
                    {
                        if (j != index)
                        {
                            toggleList[j].isOn = false;
                        }
                    }
                    this.lastOnToggle = toggleList[index];
                }
                else
                {
                    // 判断当前变成false的组件是不是上一次为true,如果是则不允许变成false
                    // 不允许同一个按钮连续点击两次(也就是三个按钮同时为false的情况)
                    if (this.lastOnToggle == this.toggleList[index])
                    {
                        this.toggleList[index].isOn = true;
                    }
                }
            };
        }
    }
}