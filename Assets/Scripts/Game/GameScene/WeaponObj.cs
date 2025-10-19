using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    public GameObject bulletPrefab;

    // 发射子弹的位置
    public Transform[] shootPos;

    // 这个武器的拥有者,传递给子弹
    public TankBase ownerTank;

    // 设置武器拥有者
    public void SetOwnerTank(TankBase tank)
    {
        this.ownerTank = tank;
    }

    public void Fire()
    {
        foreach (Transform pos in shootPos)
        {
            GameObject obj = Instantiate(bulletPrefab, pos.position, pos.rotation);

            // 控制子弹逻辑
            Bullet bullet = obj.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.SetOwnerTank(this.ownerTank);
            }
        }
    }
}
