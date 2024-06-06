using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] blockPrefabs;
    private Vector3 lastBlockPosition; // ��һ�� block ��λ��
    private GameObject lastSpawnedBlock; // ��һ�����ɵ� block ������
    public Vector3 initialPosition;

    void Start()
    {
        // ���� QTE ���������¼�
        qteDestory.OnQTEDestroyed += SpawnBlock;
        lastBlockPosition = initialPosition;
    }

    void SpawnBlock()
    {
        if (lastSpawnedBlock != null)
        {
            // ���������һ�����ɵ� block��������
            Destroy(lastSpawnedBlock);
        }
        int randomIndex = Random.Range(0, blockPrefabs.Length); // ���ѡ��һ��Ԥ����
        GameObject selectedPrefab = blockPrefabs[randomIndex];

        Vector3 newPosition = lastBlockPosition + Vector3.up * 2f;

        // ���� block
        lastSpawnedBlock = Instantiate(selectedPrefab, newPosition, Quaternion.identity);

        // ������һ�� block ��λ��Ϊ��ǰ���ɵ� block ��λ��
        lastBlockPosition = newPosition;
    }

    void OnDestroy()
    {
        // ȡ������ QTE ���������¼��������ڴ�й©
        qteDestory.OnQTEDestroyed -= SpawnBlock;
        if (lastSpawnedBlock != null)
        {
            Destroy(lastSpawnedBlock);
        }
    }
}
