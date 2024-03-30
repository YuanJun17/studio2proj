using System.Collections;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruitPrefab; // 水果预制体
    public Transform[] spawnPoints; // 生成水果的位置数组
    public float spawnInterval = 2f; // 生成水果的间隔时间范围

    void Start()
    {
        // 开始生成水果协程
        StartCoroutine(SpawnFruitsCoroutine());
    }

    IEnumerator SpawnFruitsCoroutine()
    {
        while (true)
        {
            // 随机选择生成水果的数量
            int numberOfFruits = Random.Range(1, spawnPoints.Length + 1);

            // 在随机生成点生成水果
            for (int i = 0; i < numberOfFruits; i++)
            {
                // 随机选择一个生成点
                int randomIndex = Random.Range(0, spawnPoints.Length);
                Transform randomSpawnPoint = spawnPoints[randomIndex];

                // 生成水果并保持其初始属性
                GameObject fruit = Instantiate(fruitPrefab, randomSpawnPoint.position, Quaternion.identity);
                // 如果水果有刚体组件，可以设置一些初始速度等属性
                Rigidbody2D rb = fruit.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
                }
            }

            // 等待一段时间后继续生成下一批水果
            yield return new WaitForSeconds(Random.Range(spawnInterval, spawnInterval * 2));
        }
    }
}
