using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUILabel : GUIBase
{
    protected override void DrawControlNoStyle()
    {
        GUI.Label(this.guiPos.pos, this.guiContent);
    }

    protected override void DrawControlUseStyle()
    {
        GUI.Label(this.guiPos.pos, this.guiContent, this.guiStyle);
    }
}
