using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 音乐管理类
public class GameDataManage
{
    private static GameDataManage _instance;
    public static GameDataManage instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameDataManage();
            }
            return _instance;
        }
    }

    // 音乐数据
    public MusicData musicData;

    // 排行榜数据
    public RankList rankList;


    private GameDataManage()
    {
        // 初始化读取音乐数据
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

        // 初始化读取排行榜数据
        this.rankList = PlayerPrefsManage.instance.LoadData(typeof(RankList), "RankList") as RankList;
    }

    // 开关背景音乐
    public void SwitchBkMusic(bool isOpen)
    {
        this.musicData.isOpenBk = isOpen;
        MusicManage.instance.ChangeOpen(isOpen);
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
        MusicManage.instance.ChangeValue(volume);
        PlayerPrefsManage.instance.SaveData(this.musicData, "MusicData");
    }

    // 设置音效音量
    public void SetEffectMusicVolume(float volume)
    {
        this.musicData.effectVolume = volume;
        PlayerPrefsManage.instance.SaveData(this.musicData, "MusicData");
    }

    // 添加排行榜数据
    public void AddRankData(string playerName, int score, float time)
    {
        this.rankList.rankDatas.Add(new RankData(playerName, score, time));
        // 按通关时间排序,时间短的在前面
        this.rankList.rankDatas.Sort((a, b) => a.time < b.time ? -1 : 1);
        // 只保留前10名
        if (this.rankList.rankDatas.Count > RankPanel.instance.rankSize)
        {
            this.rankList.rankDatas.RemoveRange(RankPanel.instance.rankSize, this.rankList.rankDatas.Count - RankPanel.instance.rankSize);
        }
        PlayerPrefsManage.instance.SaveData(this.rankList, "RankList");
    }
}