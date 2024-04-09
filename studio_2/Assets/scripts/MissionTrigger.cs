using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    
public class MissionTrigger : MonoBehaviour
{
    public CanvasGroup checkText;
    public List<CanvasGroup> canvasGroups = new List<CanvasGroup>();
    private bool isInRange = false;

    void Start()
    {
        checkText.alpha = 0f;
        foreach (CanvasGroup canvasGroup in canvasGroups)
        {
            canvasGroup.alpha = 0f;

        }
    }
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(DisplayTextSequence());
        }
    }

    IEnumerator DisplayTextSequence()
    {
        // 隐藏检查文本
        checkText.alpha = 0f;

        // 逐个显示文本
        foreach (CanvasGroup canvasGroup in canvasGroups)
        {
            canvasGroup.alpha = 1f;
            yield return new WaitForSeconds(3f); // 等待的时间
            canvasGroup.alpha = 0f;
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            // 显示检查文本
            checkText.alpha = 1f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            // 隐藏检查文本
            checkText.alpha = 0f;
        }
    }
}
