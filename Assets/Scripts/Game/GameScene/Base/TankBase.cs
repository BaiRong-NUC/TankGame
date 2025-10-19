using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBase : MonoBehaviour
{
    // 坦克公共属性
    public int akt;
    public int def;
    public int maxHp;
    public int hp;

    public float speed = 10;
    public float rotateSpeed = 100;
    public float headRotateSpeed = 100;

    // 死亡特效
    public GameObject deadEffectPrefab;

    // 开火
    public abstract void Fire();

    // 炮台
    public Transform headTransform;

    // 受到伤害
    public virtual void TakeDamage(TankBase attacker)
    {
        // 伤害
        int damage = attacker.akt - this.def;
        if (damage < 0)
        {
            return;
        }
        // 扣血
        this.hp -= damage;
        if (this.hp <= 0)
        {
            // 死亡
            this.hp = 0;
            this.Dead();
        }
    }

    public virtual void Dead()
    {
        // 销毁坦克
        Destroy(this.gameObject);

        // 生成死亡特效
        if (this.deadEffectPrefab != null)
        {
            Instantiate(this.deadEffectPrefab, this.transform.position, this.transform.rotation);

            // GameObject上有音效,控制特效音效播放
            AudioSource audioSource = this.deadEffectPrefab.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.volume = GameDataManage.instance.musicData.effectVolume;

                audioSource.mute = GameDataManage.instance.musicData.isOpenEffect ? false : true;

                audioSource.Play();
            }
        }
    }
}
