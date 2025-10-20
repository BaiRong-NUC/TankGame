using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : TankBase
{
    [HideInInspector]
    // 当前的武器
    public WeaponObj weaponObj = null;

    public Transform weaponPoint;
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
        if (this.weaponObj != null)
        {
            this.weaponObj.Fire();
        }
    }

    public override void Dead()
    {
        base.Dead();
    }

    public override void TakeDamage(TankBase attacker)
    {
        base.TakeDamage(attacker);
        // 更新UI血条
        GamePanel.instance?.UpdateHp(this.maxHp, this.hp);
    }

    // 设置武器
    public void SetWeapon(GameObject weapon)
    {
        // 销毁当前武器
        if (this.weaponObj != null)
        {
            Destroy(this.weaponObj.gameObject);
            this.weaponObj = null;
        }
        // 设置新武器坐标
        weapon.transform.SetParent(this.weaponPoint);
        weapon.transform.localPosition = Vector3.zero; //设置相对于父对象的坐标为 0,0,0
        weapon.transform.localRotation = Quaternion.identity;
        weapon.transform.localScale = Vector3.one;
        //记录当前武器
        this.weaponObj = weapon.GetComponent<WeaponObj>();
        // 设置武器拥有者
        this.weaponObj.SetOwnerTank(this);
    }
}
