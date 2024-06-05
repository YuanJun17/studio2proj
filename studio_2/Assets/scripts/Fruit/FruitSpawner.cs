using System.Collections;
using System.Collections.Generic;
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
            int totalFruitsToSpawn = Random.Range(1, spawnPoints.Length + 1);

            // 随机选择生成点，并记录已经选中的点
            List<int> selectedIndices = new List<int>();
            for (int i = 0; i < totalFruitsToSpawn; i++)
            {
                int randomIndex;
                // 确保选择的点不重复
                do
                {
                    randomIndex = Random.Range(0, spawnPoints.Length);
                } while (selectedIndices.Contains(randomIndex));

                selectedIndices.Add(randomIndex);

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
