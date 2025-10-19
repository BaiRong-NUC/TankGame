using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeapenRewards : MonoBehaviour
{
    public GameObject rewardEffect;
    public GameObject[] weaponPrefabs;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerTank playerTank = other.GetComponent<PlayerTank>();
            if (playerTank != null)
            {
                // 生成新武器
                GameObject weaponObj = Instantiate(weaponPrefabs[Random.Range(0, weaponPrefabs.Length)]); //[)

                // 设置武器给玩家坦克
                playerTank.SetWeapon(weaponObj);
                if (this.rewardEffect != null)
                {
                    // 播放奖励特效
                    GameObject effect = GameObject.Instantiate(rewardEffect, this.transform.position, this.transform.rotation);

                    AudioSource audioSource = effect.GetComponent<AudioSource>();
                    if (audioSource != null)
                    {
                        audioSource.mute = !GameDataManage.instance.musicData.isOpenEffect;
                        audioSource.volume = GameDataManage.instance.musicData.effectVolume / 100f;
                        audioSource.Play();
                    }
                }
                // 销毁奖励物体
                Destroy(this.gameObject);
            }
        }
    }
}
