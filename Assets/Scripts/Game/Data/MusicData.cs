using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicData
{
    // 背景音乐是否开启
    public bool isOpenBk;
    // 音效是否开启
    public bool isOpenEffect;
    // 音乐音量
    public float musicVolume;
    // 音效音量
    public float effectVolume;

    // 是否是第一次打开游戏
    public bool noFirstOpen = false;
}
