using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GUIButton : GUIBase
{
    // 提供外部用于相应按钮点击事件,只要在外部给予了相应函数,那就会执行
    public event UnityAction clickEvent;
    protected override void DrawControlNoStyle()
    {
        if (GUI.Button(this.guiPos.pos, this.guiContent))
        {
            Debug.Log("按钮被点击");
            clickEvent?.Invoke();
        }
    }

    protected override void DrawControlUseStyle()
    {
        if (GUI.Button(this.guiPos.pos, this.guiContent, this.guiStyle))
        {
            Debug.Log("按钮被点击");
            clickEvent?.Invoke();
        }
    }
}
