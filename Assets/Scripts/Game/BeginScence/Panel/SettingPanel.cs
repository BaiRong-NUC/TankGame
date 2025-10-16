using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : PanelBase<SettingPanel>
{
    public GUISlider musicSlider;
    public GUISlider soundSlider;
    public GUIToggle musicToggle;
    public GUIToggle soundToggle;
    public GUIButton closeButton;

    void Start()
    {
        //音乐大小
        musicSlider.valueChangedEvent += (value) =>
        {

        };

        //音效大小
        soundSlider.valueChangedEvent += (value) =>
        {

        };

        //音乐开关
        musicToggle.toggleEvent += (isOn) =>
        {

        };

        //音效开关
        soundToggle.toggleEvent += (isOn) =>
        {

        };

        //关闭按钮
        closeButton.clickEvent += () =>
        {
            this.OnClose();

            BeginPanel.instance.OnOpen(); //打开开始面板
        };

        // 默认关闭
        this.OnClose(); //开始时是激活状态,运行脚本到此可以失活了. Unity编辑器中失活的组件上的脚本不会执行
    }
}
