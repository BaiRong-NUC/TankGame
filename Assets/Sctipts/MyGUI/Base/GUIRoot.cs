using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 在编辑场景下运行
[ExecuteAlways]
public class GUIRoot : MonoBehaviour
{
    // 记录所有子对象控件
    private GUIBase[] allControls;
    void Start()
    {
        this.allControls = this.GetComponentsInChildren<GUIBase>();
    }

    // 绘制子对象控件内容,控制子对象OnGUI执行顺序
    private void OnGUI()
    {
        // 获取所有子对象的GUIBase组件
        if (!Application.isPlaying)
        {
            // 在编辑状态下才会一直运行
            this.allControls = this.GetComponentsInChildren<GUIBase>();
        }
        if (this.allControls != null)
        {
            // 遍历所有控件,调用绘制方法,控制绘制顺序
            foreach (var control in allControls)
            {
                control.DrawGUI();
            }
        }
    }
}
