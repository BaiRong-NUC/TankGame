using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 音乐管理类
public class MusicManage
{
    private static MusicManage _instance;
    public static MusicManage instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MusicManage();
            }
            return _instance;
        }
    }

    public MusicData musicData;

    private MusicManage()
    {
        musicData = PlayerPrefsManage.instance.LoadData(typeof(MusicData), "MusicData") as MusicData;

        if (this.musicData.noFirstOpen == false)
        {
            // 第一次打开游戏,初始化数据
            Debug.Log("第一次打开游戏,初始化数据");
            this.musicData.noFirstOpen = true;
            this.musicData.isOpenBk = true;
            this.musicData.isOpenEffect = true;
            this.musicData.musicVolume = 100f;
            this.musicData.effectVolume = 100f;
            PlayerPrefsManage.instance.SaveData(this.musicData, "MusicData");
        }
    }

    // 开关背景音乐
    public void SwitchBkMusic(bool isOpen)
    {
        this.musicData.isOpenBk = isOpen;
        PlayerPrefsManage.instance.SaveData(this.musicData, "MusicData");
    }

    // 开关音效
    public void SwitchEffectMusic(bool isOpen)
    {
        this.musicData.isOpenEffect = isOpen;
        PlayerPrefsManage.instance.SaveData(this.musicData, "MusicData");
    }

    // 设置背景音乐音量
    public void SetBkMusicVolume(float volume)
    {
        this.musicData.musicVolume = volume;
        PlayerPrefsManage.instance.SaveData(this.musicData, "MusicData");
    }

    // 设置音效音量
    public void SetEffectMusicVolume(float volume)
    {
        this.musicData.effectVolume = volume;
        PlayerPrefsManage.instance.SaveData(this.musicData, "MusicData");
    }
}
