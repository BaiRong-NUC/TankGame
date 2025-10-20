using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStayTank : TankBase
{
    // 间隔开火
    public float fireInterval = 2f;

    // 子弹发射位置
    public Transform[] shootPos;

    // 子弹类型
    public GameObject bulletPrefab;

    private float nextFireTime = 0f;

    void Start()
    {
        this.nextFireTime = this.fireInterval;
    }

    public override void Fire()
    {
        foreach (var pos in shootPos)
        {
            // Instantiate 子弹并设置拥有者
            GameObject bullet = Instantiate(bulletPrefab, pos.position, pos.rotation);
            bullet.GetComponent<Bullet>()?.SetOwnerTank(this);
        }
    }

    void Update()
    {
        // 定时开火
        if (Time.time >= nextFireTime)
        {
            this.Fire();
            nextFireTime = Time.time + fireInterval;
        }
    }

    // 静止的坦克不会死亡
    public override void TakeDamage(TankBase attacker)
    {
        // base.TakeDamage(attacker);
    }
}
