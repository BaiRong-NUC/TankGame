using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float time = 2;
    // 自动移除爆炸特效节点
    void Start()
    {
        Destroy(this.gameObject, time);
    }
}
