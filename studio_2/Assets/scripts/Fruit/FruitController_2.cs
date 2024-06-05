using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController_2 : MonoBehaviour
{
    public delegate void GoldenFruitEatenAction();
    public static event GoldenFruitEatenAction OnGoldenFruitEaten;
    void Start()
    {
        StartCoroutine(DestroyAfterDelay(6f)); // ��ʼһ��Э�̣���x�������ˮ��
        // ��ȡ����� Rigidbody2D ���
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
       /* if (rb != null)
        {
            // �޸�Ħ����
            rb.sharedMaterial.friction = 0.5f; // ����Ħ����Ϊ 0.5
        }*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �����ײ���������
        if (collision.gameObject.CompareTag("Player"))
        {
            // ����ˮ������
            Destroy(gameObject);
            OnGoldenFruitEaten?.Invoke();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // ����ˮ������
            Destroy(gameObject);

        }
    }

    private void DestroyFruit()
    {
        Destroy(gameObject); // ����ˮ������
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // �ȴ�һ��ʱ��
        if (IsOnGround()) // ���ˮ���Ƿ��ڵ�����
        {
            DestroyFruit(); // ����ڵ����ϣ�����ˮ������
        }
    }
    private bool IsOnGround()
    {

        return transform.position.y <= -8.7f;
    }
}
