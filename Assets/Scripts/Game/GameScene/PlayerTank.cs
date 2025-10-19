using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : TankBase
{
    void Start()
    {

    }

    void Update()
    {
        // 控制坦克移动和旋转的逻辑

        // WS前后移动,使用轴线检测
        this.transform.Translate(Input.GetAxis("Vertical") * speed * Time.deltaTime * Vector3.forward);
        // AD左右旋转
        this.transform.Rotate(Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime * Vector3.up);
        // 鼠标移动控制炮台旋转
        if (this.headTransform != null)
        {
            this.headTransform.Rotate(Input.GetAxis("Mouse X") * headRotateSpeed * Time.deltaTime * Vector3.up);
        }
        // 鼠标左键开火
        if (Input.GetMouseButtonDown(0))
        {
            this.Fire();
        }
    }

    public override void Fire()
    {
        // 玩家开火逻辑
    }

    public override void Dead()
    {
        base.Dead();
    }

    public override void TakeDamage(TankBase attacker)
    {
        base.TakeDamage(attacker);
        // 更新UI血条
        GamePanel.instance.UpdateHp(this.maxHp, this.hp);
    }
}
