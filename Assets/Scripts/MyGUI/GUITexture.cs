using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUITexture : GUIBase
{
    public ScaleMode scaleMode = ScaleMode.StretchToFill; // 缩放模式
    protected override void DrawControlNoStyle()
    {
        GUI.DrawTexture(this.guiPos.pos, this.guiContent.image, this.scaleMode);
    }

    // 图片绘制没有GUIStyle,这里略过
    protected override void DrawControlUseStyle()
    {
        GUI.DrawTexture(this.guiPos.pos, this.guiContent.image, this.scaleMode);
    }
}
