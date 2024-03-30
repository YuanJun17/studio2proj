using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    void Start()
    {
        // 获取物体的 Rigidbody2D 组件
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // 修改摩擦力
            rb.sharedMaterial.friction = 0.5f; // 设置摩擦力为 0.5
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 如果碰撞到的是玩家
        if (collision.gameObject.CompareTag("Player"))
        {
            // 销毁水果物体
            Destroy(gameObject);
        }
    }
}
