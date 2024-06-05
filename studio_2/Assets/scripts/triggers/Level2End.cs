using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Level2End : MonoBehaviour
{
    public FruitUI fruitUI; // 引用FruitUI脚本
    public PlayableDirector timelineDirector; // 引用PlayableDirector来播放Timeline
    public MonoBehaviour script1; // 引用脚本1
    public MonoBehaviour script2; // 引用脚本2
    public int testTargetNum;

    private void Start()
    {
        // 确保Timeline一开始是停止的
        if (timelineDirector != null)
        {
            timelineDirector.Stop();
        }
        else
        {
            Debug.LogError("Timeline Director is not assigned!");
        }
    }
    private void Update()
    {
        if (fruitUI.fruitCount >= testTargetNum)
        {
            StopScriptsAndPlayTimeline();
        }
    }

    // 停止脚本并播放Timeline
    private void StopScriptsAndPlayTimeline()
    {
        script1.enabled = false; // 停止脚本1
        script2.enabled = false; // 停止脚本2

        if (timelineDirector != null)
        {
            timelineDirector.Play(); // 播放Timeline
        }
        else
        {
            Debug.LogError("Timeline Director is not assigned!");
        }

        // 禁用自身以防止重复调用
        this.enabled = false;
    }
}
