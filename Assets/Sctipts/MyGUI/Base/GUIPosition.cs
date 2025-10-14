using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 对齐方式枚举
public enum GUIAnchor
{
    Up,
    Down,
    Left,
    Right,
    Center,
    LeftUp,
    RightUp,
    LeftDown,
    RightDown
}

// 表示GUI位置的类,用于计算位置相关信息
[System.Serializable]
public class GUIPosition
{
    // 绘制控件的位置信息
    private Rect _pos = new Rect(0, 0, 100, 100); // 位置和大小

    // 控件相对于屏幕的对齐方式
    public GUIAnchor screenAnchor = GUIAnchor.Center; // 锚点位置

    //控件中心对齐方式
    public GUIAnchor controlAnchor = GUIAnchor.Center; // 锚点位置

    // 控件的偏移量
    public Vector2 offset = Vector2.zero; // 偏移量

    // 控件默认宽
    public float width = 100;

    // 控件默认高
    public float height = 50;

    // 根据计算得出的控件中心位置
    private Vector2 controlCenterPos = Vector2.zero;

    // 根据控件中心对其方式计算控件中心位置
    private Vector2 _CalControlCenterPos()
    {
        Vector2 pos = Vector2.zero;
        switch (controlAnchor)
        {
            case GUIAnchor.Up:
                pos.x = -width / 2;
                pos.y = 0;
                break;
            case GUIAnchor.Down:
                pos.x = -width / 2;
                pos.y = -height;
                break;
            case GUIAnchor.Left:
                pos.x = 0;
                pos.y = -height / 2;
                break;
            case GUIAnchor.Right:
                pos.x = -width;
                pos.y = -height / 2;
                break;
            case GUIAnchor.Center:
                pos.x = -width / 2;
                pos.y = -height / 2;
                break;
            case GUIAnchor.LeftUp:
                pos.x = 0;
                pos.y = 0;
                break;
            case GUIAnchor.RightUp:
                pos.x = -width;
                pos.y = 0;
                break;
            case GUIAnchor.LeftDown:
                pos.x = 0;
                pos.y = -height;
                break;
            case GUIAnchor.RightDown:
                pos.x = -width;
                pos.y = -height;
                break;
        }
        return pos;
    }

    // 计算最终控件相对坐标位置的方法
    private Vector2 _CalControlPos()
    {
        // 最终位置=锚点位置+偏移量+控件中心位置
        Vector2 pos = Vector2.zero;
        switch (screenAnchor)
        {
            case GUIAnchor.Up:
                pos.x = Screen.width / 2 + offset.x + controlCenterPos.x;
                pos.y = 0 + offset.y + controlCenterPos.y;
                break;
            case GUIAnchor.Down:
                pos.x = Screen.width / 2 + offset.x + controlCenterPos.x;
                pos.y = Screen.height - offset.y + controlCenterPos.y; // 这里-offset.y为了让偏移量的正负符合直觉
                break;
            case GUIAnchor.Left:
                pos.x = 0 + offset.x + controlCenterPos.x;
                pos.y = Screen.height / 2 + offset.y + controlCenterPos.y;
                break;
            case GUIAnchor.Right:
                pos.x = Screen.width - offset.x + controlCenterPos.x;
                pos.y = Screen.height / 2 + offset.y + controlCenterPos.y;
                break;
            case GUIAnchor.Center:
                pos.x = Screen.width / 2 + offset.x + controlCenterPos.x;
                pos.y = Screen.height / 2 + offset.y + controlCenterPos.y;
                break;
            case GUIAnchor.LeftUp:
                pos.x = 0 + offset.x + controlCenterPos.x;
                pos.y = 0 + offset.y + controlCenterPos.y;
                break;
            case GUIAnchor.RightUp:
                pos.x = Screen.width - offset.x + controlCenterPos.x;
                pos.y = 0 + offset.y + controlCenterPos.y;
                break;
            case GUIAnchor.LeftDown:
                pos.x = 0 + offset.x + controlCenterPos.x;
                pos.y = Screen.height - offset.y + controlCenterPos.y;
                break;
            case GUIAnchor.RightDown:
                pos.x = Screen.width - offset.x + controlCenterPos.x;
                pos.y = Screen.height - offset.y + controlCenterPos.y;
                break;
        }
        return pos;
    }

    public Rect pos
    {
        get
        {
            // 对控件位置进行计算

            // 宽高
            this._pos.width = this.width;
            this._pos.height = height;

            // 计算控件的中心位置
            this.controlCenterPos = this._CalControlCenterPos();
            Vector2 controlCenterPos = this._CalControlPos();
            this._pos.x = controlCenterPos.x;
            this._pos.y = controlCenterPos.y;
            return _pos;
        }
    }
}
