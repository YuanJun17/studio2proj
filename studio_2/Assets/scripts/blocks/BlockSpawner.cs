using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] blockPrefabs;
    private Vector3 lastBlockPosition; // 上一个 block 的位置
    private GameObject lastSpawnedBlock; // 上一个生成的 block 的引用
    public Vector3 initialPosition;

    void Start()
    {
        // 订阅 QTE 物体销毁事件
        qteDestory.OnQTEDestroyed += SpawnBlock;
        lastBlockPosition = initialPosition;
    }

    void SpawnBlock()
    {
        if (lastSpawnedBlock != null)
        {
            // 如果存在上一个生成的 block，销毁它
            Destroy(lastSpawnedBlock);
        }
        int randomIndex = Random.Range(0, blockPrefabs.Length); // 随机选择一个预制体
        GameObject selectedPrefab = blockPrefabs[randomIndex];

        Vector3 newPosition = lastBlockPosition + Vector3.up * 2f;

        // 生成 block
        lastSpawnedBlock = Instantiate(selectedPrefab, newPosition, Quaternion.identity);

        // 更新上一个 block 的位置为当前生成的 block 的位置
        lastBlockPosition = newPosition;
    }

    void OnDestroy()
    {
        // 取消订阅 QTE 物体销毁事件，避免内存泄漏
        qteDestory.OnQTEDestroyed -= SpawnBlock;
        if (lastSpawnedBlock != null)
        {
            Destroy(lastSpawnedBlock);
        }
    }
}
