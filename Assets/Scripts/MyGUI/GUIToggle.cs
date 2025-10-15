using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GUIToggle : GUIBase
{
    public bool isOn = false; // 开关状态

    public event UnityAction<bool> toggleEvent; // 开关状态改变事件

    private bool lastIsOn = false; // 上一次的开关状态

    protected override void DrawControlNoStyle()
    {
        this.isOn = GUI.Toggle(this.guiPos.pos, this.isOn, this.guiContent);
        // 检测状态变化,触发事件
        if (this.isOn != lastIsOn)
        {
            lastIsOn = this.isOn;
            toggleEvent?.Invoke(this.isOn);
        }
    }

    protected override void DrawControlUseStyle()
    {
        this.isOn = GUI.Toggle(this.guiPos.pos, this.isOn, this.guiContent, this.guiStyle);
        // 检测状态变化,触发事件
        if (this.isOn != lastIsOn)
        {
            lastIsOn = this.isOn;
            toggleEvent?.Invoke(this.isOn);
        }
    }
}
