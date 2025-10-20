using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveTank : TankBase
{
    // 1. 坦克要在两个点之间巡逻
    private Transform targetPoint; // 当前要移动的目标点
    // 随机点
    public Transform[] randomPoint; // 巡逻点数组

    public Transform lookAtTarget;

    public float attackRange = 10f; // 攻击范围

    public float fireInterval = 2f; // 攻击间隔时间

    private float fireTimer = 0f; // 攻击计时器 

    public Transform[] shootPos; // 子弹发射位置

    public GameObject bulletPrefab; // 子弹类型

    public Texture hpTexture;

    public Texture hpBgTexture;

    public Rect hpBgRect = new Rect(10, 10, 100, 15);

    public Rect hpRect = new Rect(10, 10, 100, 15);

    
    private float showHpTime = 0; // 受伤血条显示时间

    private void RandomPos()
    {

        int index = Random.Range(0, randomPoint.Length);
        targetPoint = randomPoint[index];
    }

    void Start()
    {
        RandomPos();
    }

    void Update()
    {
        this.transform.LookAt(targetPoint.position);
        // 向面前移动
        this.transform.Translate(Vector3.forward * this.speed * Time.deltaTime);

        // 到达目标点，重新选择目标点
        if (Vector3.Distance(this.transform.position, targetPoint.position) < 1f)
        {
            RandomPos();
        }
        // 2. 移动的坦克的炮台要盯着目标
        if (this.lookAtTarget != null)
        {
            this.headTransform.LookAt(lookAtTarget.position);
            if (Vector3.Distance(this.transform.position, lookAtTarget.position) < attackRange)
            {
                fireTimer += Time.deltaTime;
                if (fireTimer >= fireInterval)
                {
                    Fire();
                    fireTimer = 0f;
                }
            }
        }
    }

    // 3. 当目标进入攻击范围时，坦克间隔时间攻击
    public override void Fire()
    {
        foreach (var pos in shootPos)
        {
            // Instantiate 子弹并设置拥有者
            GameObject bullet = Instantiate(bulletPrefab, pos.position, pos.rotation);
            bullet.GetComponent<Bullet>()?.SetOwnerTank(this);
        }
    }

    public override void Dead()
    {
        base.Dead();

        // 加分
        GamePanel.instance.AddStar(10);
    }

    // 怪物血条
    private void OnGUI()
    {
        if (this.showHpTime > 0)
        {
            // 3d物体转化为屏幕坐标,屏幕坐标转化为GUI坐标
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position + Vector3.up * 2);
            Vector2 guiPos = new Vector2(screenPos.x, Screen.height - screenPos.y);

            // 血条背景
            hpBgRect.x = guiPos.x - this.hpBgRect.width / 2;
            // hpBgRect.x = guiPos.x;
            hpBgRect.y = guiPos.y;
            GUI.DrawTexture(hpBgRect, hpBgTexture);
            // 血条
            hpRect.x = guiPos.x - this.hpBgRect.width / 2;
            // hpRect.x = guiPos.x;
            hpRect.y = guiPos.y;
            hpRect.width = (float)this.hp / this.maxHp * hpBgRect.width;
            GUI.DrawTexture(hpRect, hpTexture);
            this.showHpTime -= Time.deltaTime;
        }
    }

    override public void TakeDamage(TankBase damage)
    {
        base.TakeDamage(damage);

        // 受伤显示血条
        this.showHpTime = 2f;
    }
}
