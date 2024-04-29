using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    private Vector3 lastBlockPosition; // 上一个 block 的位置

    void Start()
    {
        // 订阅 QTE 物体销毁事件
        qteDestory.OnQTEDestroyed += SpawnBlock;
        lastBlockPosition = blockPrefab.transform.position;
    }

    void SpawnBlock()
    {
        Vector3 newPosition = lastBlockPosition + Vector3.up * 2f;

        // 生成 block
        Instantiate(blockPrefab, newPosition, Quaternion.identity);


        // 更新上一个 block 的位置为当前生成的 block 的位置
        lastBlockPosition = newPosition;
    }

    void OnDestroy()
    {
        // 取消订阅 QTE 物体销毁事件，避免内存泄漏
        qteDestory.OnQTEDestroyed -= SpawnBlock;
    }
}
