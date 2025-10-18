using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManage : MonoBehaviour
{
    private static MusicManage _instance;

    // 单例模式,不能new,在Awake中赋值
    public static MusicManage instance => _instance;

    private AudioSource bgmAudioSource; // 背景音乐AudioSource

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject); // 销毁重复的实例
        }
        // 获取音频源
        this.bgmAudioSource = this.GetComponent<AudioSource>();

        this.ChangeValue(GameDataManage.instance.musicData.musicVolume);
        this.ChangeOpen(GameDataManage.instance.musicData.isOpenBk);
    }

    public void ChangeValue(float volume)
    {
        this.bgmAudioSource.volume = volume / 100f; // 音量范围0~1
    }

    public void ChangeOpen(bool isOpen)
    {
        this.bgmAudioSource.mute = !isOpen; // 静音与否
    }
}
