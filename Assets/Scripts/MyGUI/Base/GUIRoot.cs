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
        // 需要一直更新数组,否则可能用户将组件设置成未激活状态,而数组中仍然有该组件
        this.allControls = this.GetComponentsInChildren<GUIBase>();

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
