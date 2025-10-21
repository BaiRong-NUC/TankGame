using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50;

    [HideInInspector]
    public TankBase ownerTank;

    public GameObject hitEffectPrefab;

    void Update()
    {
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void SetOwnerTank(TankBase tank)
    {
        this.ownerTank = tank;
    }

    // 碰撞开始
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall") || other.CompareTag("Cube")
         || (other.CompareTag("Monster") && this.ownerTank.CompareTag("Player")) // 玩家子弹碰到怪物
         || (other.CompareTag("Player") && this.ownerTank.CompareTag("Monster")) // 怪物子弹碰到玩家
        )
        {
            //碰到墙面销毁
            if (this.hitEffectPrefab != null)
            {
                GameObject bulletEffect = Instantiate(hitEffectPrefab, this.transform.position, this.transform.rotation);
                AudioSource audioSource = bulletEffect.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    // 音量数据受游戏设置控制
                    audioSource.mute = GameDataManage.instance.musicData.isOpenEffect ? false : true;
                    audioSource.volume = GameDataManage.instance.musicData.effectVolume / 100f;
                    audioSource.Play();
                }
            }

            // 如果碰到坦克，造成伤害
            TankBase hitTank = other.GetComponent<TankBase>();
            if (hitTank != null && this.ownerTank != null)
            {
                hitTank.TakeDamage(this.ownerTank);
            }

            Destroy(this.gameObject);
        }
    }
}
