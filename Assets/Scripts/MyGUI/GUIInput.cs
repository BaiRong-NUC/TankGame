using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIInput : GUIBase
{
    public event UnityEngine.Events.UnityAction<string> inputEvent; // 输入内容改变事件

    private string lastInputStr = ""; // 上一次的输入内容
    protected override void DrawControlNoStyle()
    {
        this.guiContent.text = GUI.TextField(this.guiPos.pos, this.guiContent.text);
        if (this.guiContent.text != lastInputStr)
        {
            lastInputStr = this.guiContent.text;
            inputEvent?.Invoke(this.guiContent.text);
        }
    }

    protected override void DrawControlUseStyle()
    {
        this.guiContent.text = GUI.TextField(this.guiPos.pos, this.guiContent.text, this.guiStyle);
        if (this.guiContent.text != lastInputStr)
        {
            lastInputStr = this.guiContent.text;
            inputEvent?.Invoke(this.guiContent.text);
        }
    }
}
