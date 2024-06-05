using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController_2 : MonoBehaviour
{
    public delegate void GoldenFruitEatenAction();
    public static event GoldenFruitEatenAction OnGoldenFruitEaten;
    void Start()
    {
        StartCoroutine(DestroyAfterDelay(6f)); // 开始一个协程，在x秒后销毁水果
        // 获取物体的 Rigidbody2D 组件
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
       /* if (rb != null)
        {
            // 修改摩擦力
            rb.sharedMaterial.friction = 0.5f; // 设置摩擦力为 0.5
        }*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 如果碰撞到的是玩家
        if (collision.gameObject.CompareTag("Player"))
        {
            // 销毁水果物体
            Destroy(gameObject);
            OnGoldenFruitEaten?.Invoke();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // 销毁水果物体
            Destroy(gameObject);

        }
    }

    private void DestroyFruit()
    {
        Destroy(gameObject); // 销毁水果对象
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 等待一段时间
        if (IsOnGround()) // 检查水果是否在地面上
        {
            DestroyFruit(); // 如果在地面上，销毁水果对象
        }
    }
    private bool IsOnGround()
    {

        return transform.position.y <= -8.7f;
    }
}
