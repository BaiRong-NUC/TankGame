using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        musicSlider.valueChangedEvent += (value) => GameDataManage.instance.SetBkMusicVolume(value);

        //音效大小
        soundSlider.valueChangedEvent += (value) => GameDataManage.instance.SetEffectMusicVolume(value);

        //音乐开关
        musicToggle.toggleEvent += (isOn) => GameDataManage.instance.SwitchBkMusic(isOn);

        //音效开关
        soundToggle.toggleEvent += (isOn) => GameDataManage.instance.SwitchEffectMusic(isOn);

        //关闭按钮
        closeButton.clickEvent += () =>
        {
            this.OnClose();
            //只有在开始场景点击设置的时候才打开开始面板
            if (SceneManager.GetActiveScene().name == "BeginScene")
            {
                BeginPanel.instance.OnOpen(); //打开开始面板
            }
        };

        // 默认关闭
        this.OnClose(); //开始时是激活状态,运行脚本到此可以失活了. Unity编辑器中失活的组件上的脚本不会执行
    }

    // 更新音乐数据
    public void UpdateMusicData()
    {
        MusicData musicData = GameDataManage.instance.musicData;
        musicSlider.value = musicData.musicVolume;
        soundSlider.value = musicData.effectVolume;
        musicToggle.isOn = musicData.isOpenBk;
        soundToggle.isOn = musicData.isOpenEffect;
    }

    // 打开面板时更新数据,重写方法
    public override void OnOpen()
    {
        base.OnOpen();
        UpdateMusicData();
    }
}
