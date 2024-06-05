using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenFruitSpawn : MonoBehaviour
{
    public GameObject goldenFruitPrefab;  // Golden fruit 的预制体
    private Transform[] spawnPoints;      // 用于存储 spawnPoints

    // 引用 FruitSpawner 脚本
    private FruitSpawner fruitSpawner;

    private void Start()
    {
        // 获取 FruitSpawner 组件
        fruitSpawner = FindObjectOfType<FruitSpawner>();

        if (fruitSpawner != null)
        {
            spawnPoints = fruitSpawner.spawnPoints;
        }
        else
        {
            Debug.LogError("FruitSpawner not found!");
        }

        // 开始协程
        StartCoroutine(SpawnGoldenFruit());
    }

    private IEnumerator SpawnGoldenFruit()
    {
        while (true)
        {
            yield return new WaitForSeconds(6f); // 每隔6秒

            if (spawnPoints.Length > 0)
            {
                int randomIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[randomIndex];

                // 生成 goldenFruit 预制体
                Instantiate(goldenFruitPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}
