using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PropType
{
    Health,
    Defense,
    Damage
}

public class PropReward : MonoBehaviour
{
    public PropType propType = PropType.Health;

    public GameObject rewardEffect;

    // 奖励数值，比如恢复的生命值，增加的伤害等
    public int changeValue = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerTank playerTank = other.GetComponent<PlayerTank>();
            if (playerTank != null)
            {
                // 根据道具类型应用效果
                switch (propType)
                {
                    case PropType.Health:
                        playerTank.hp += changeValue;
                        if (playerTank.hp > playerTank.maxHp)
                        {
                            playerTank.hp = playerTank.maxHp;
                        }
                        // 更新UI血条
                        GamePanel.instance.UpdateHp(playerTank.maxHp, playerTank.hp);
                        break;
                    case PropType.Defense:
                        playerTank.def += changeValue;
                        break;
                    case PropType.Damage:
                        playerTank.akt += changeValue;
                        break;
                }

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
