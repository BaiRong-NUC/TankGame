using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeapenRewards : MonoBehaviour
{
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

                // 销毁奖励物体
                Destroy(this.gameObject);
            }
        }
    }
}
