using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenFruitSpawn : MonoBehaviour
{
    public GameObject goldenFruitPrefab;  // Golden fruit ��Ԥ����
    private Transform[] spawnPoints;      // ���ڴ洢 spawnPoints

    // ���� FruitSpawner �ű�
    private FruitSpawner fruitSpawner;

    private void Start()
    {
        // ��ȡ FruitSpawner ���
        fruitSpawner = FindObjectOfType<FruitSpawner>();

        if (fruitSpawner != null)
        {
            spawnPoints = fruitSpawner.spawnPoints;
        }
        else
        {
            Debug.LogError("FruitSpawner not found!");
        }

        // ��ʼЭ��
        StartCoroutine(SpawnGoldenFruit());
    }

    private IEnumerator SpawnGoldenFruit()
    {
        while (true)
        {
            yield return new WaitForSeconds(6f); // ÿ��6��

            if (spawnPoints.Length > 0)
            {
                int randomIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[randomIndex];

                // ���� goldenFruit Ԥ����
                Instantiate(goldenFruitPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}
