using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMapMove : MonoBehaviour
{
    //摄像机跟着目标动

    public Transform target;
    private Vector3 newPos;
    void LateUpdate()
    {
        if (target != null)
        {
            newPos = target.position;
            newPos.y = this.transform.position.y; // 保持摄像机的高度不变
            this.transform.position = newPos;
        }
    }
}
