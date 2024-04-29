using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class door1 : MonoBehaviour
{
    public CanvasGroup uiText; // 引用UI文本对象
    private bool playerEnteredTrigger = false;

    public PlayableDirector timeline; // Timeline 对象
    private void Start()
    {
        uiText.alpha = 0f;
        timeline.Stop();
    }

    void Update()
    {
        // 如果玩家在触发区域内并且按下了 E 键
        if (playerEnteredTrigger && Input.GetKeyDown(KeyCode.E))
        {
            // 播放 Timeline
            if (timeline != null)
            {
                timeline.Play();
            
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 检查是否是Player进入了触发器
        if (collision.CompareTag("Player"))
        {
            uiText.alpha = 1f;
            playerEnteredTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiText.alpha = 0f;
            playerEnteredTrigger |= false;
        }
    }
    public bool PlayerEnteredTrigger()
    {
        return playerEnteredTrigger;
    }
    public void OnTimelineFinished()
    {
        uiText.alpha = 0f;
        // 加载下一个场景
        SceneLoadManager.Instance.LoadNextScene();
    }

}
