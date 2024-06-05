using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruitPrefab; // ˮ��Ԥ����
    public Transform[] spawnPoints; // ����ˮ����λ������
    public float spawnInterval = 2f; // ����ˮ���ļ��ʱ�䷶Χ

    void Start()
    {
        // ��ʼ����ˮ��Э��
        StartCoroutine(SpawnFruitsCoroutine());
    }

    IEnumerator SpawnFruitsCoroutine()
    {
        while (true)
        {
            // ���ѡ������ˮ��������
            int totalFruitsToSpawn = Random.Range(1, spawnPoints.Length + 1);

            // ���ѡ�����ɵ㣬����¼�Ѿ�ѡ�еĵ�
            List<int> selectedIndices = new List<int>();
            for (int i = 0; i < totalFruitsToSpawn; i++)
            {
                int randomIndex;
                // ȷ��ѡ��ĵ㲻�ظ�
                do
                {
                    randomIndex = Random.Range(0, spawnPoints.Length);
                } while (selectedIndices.Contains(randomIndex));

                selectedIndices.Add(randomIndex);

                Transform randomSpawnPoint = spawnPoints[randomIndex];

                // ����ˮ�����������ʼ����
                GameObject fruit = Instantiate(fruitPrefab, randomSpawnPoint.position, Quaternion.identity);
                // ���ˮ���и����������������һЩ��ʼ�ٶȵ�����
                Rigidbody2D rb = fruit.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
                }
            }

            // �ȴ�һ��ʱ������������һ��ˮ��
            yield return new WaitForSeconds(Random.Range(spawnInterval, spawnInterval * 2));
        }
    }

}
