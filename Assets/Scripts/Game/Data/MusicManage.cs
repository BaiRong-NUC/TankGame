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

    private MusicData musicData;

    private MusicManage()
    {
        musicData = PlayerPrefsManage.instance.LoadData(typeof(MusicData), "MusicData") as MusicData;
    }
}
