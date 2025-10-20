using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    public GameObject[] rewards;
    public GameObject explosionEffect; // 爆炸特效预制体
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            //被子弹击中

            //随机生成奖励50%的概率创建奖励
            if (Random.Range(0, 100) < 50)
            {
                // 随机创建奖励
                GameObject reward = Instantiate(this.rewards[Random.Range(0, rewards.Length)], this.transform.position, this.transform.rotation);
            }
            // 播放特效
            if (this.explosionEffect != null)
            {
                GameObject explosion = Instantiate(explosionEffect, this.transform.position, Quaternion.identity);

                //特效声音
                AudioSource audioSource = explosion.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.mute = !GameDataManage.instance.musicData.isOpenEffect;
                    audioSource.volume = GameDataManage.instance.musicData.effectVolume;
                    audioSource.Play();
                }
            }
            Destroy(this.gameObject);
        }
    }
}
