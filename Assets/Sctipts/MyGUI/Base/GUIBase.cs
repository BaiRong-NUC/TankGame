using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GUIType
{
    On,
    Off,
}


// 控件共同行为父类
public abstract class GUIBase : MonoBehaviour
{
    // 1. 位置信息
    public GUIPosition guiPos = new GUIPosition();
    // 2. 内容信息
    public GUIContent guiContent = new GUIContent();
    // 3. 自定义样式
    public GUIStyle guiStyle = new GUIStyle();
    // 4. 自定义样式是否开始
    public GUIType useCustomStyle = GUIType.Off;

    // 给外部提供的绘制GUI方法
    public void DrawGUI()
    {
        if (this.useCustomStyle == GUIType.On)
        {
            this.DrawControlUseStyle();
        }
        else
        {
            this.DrawControlNoStyle();
        }
    }

    // 使用自定义风格画控件
    protected abstract void DrawControlUseStyle();

    // 使用默认风格画控件
    protected abstract void DrawControlNoStyle();
}
