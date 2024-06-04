using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class questionChange : MonoBehaviour
{
    public Sprite[] spritesToChange; // 要切换的Sprite数组
    public SpriteRenderer[] spriteRenderers; // Sprite渲染器数组
    private int currentSpriteIndex = 0; // 当前Sprite的索引
    public float fadeDuration = 1.0f; // 淡入淡出持续时间
  
    private bool isFading = false; // 标记是否正在淡入淡出


    void Start()
    {
        // 订阅按钮按下事件
        yesbutton.OnButtonPressed += HandleButtonPressed;
        nobutton.OnButtonPressed += HandleButtonPressed;
    }

    void HandleButtonPressed(bool isYesButton)
    {
        if (!isFading && spritesToChange.Length > 0)
        {
            StartCoroutine(FadeOut(() =>
            {
                // 切换Sprite
                foreach (SpriteRenderer renderer in spriteRenderers)
                {
                    renderer.sprite = spritesToChange[currentSpriteIndex];
                }
                currentSpriteIndex = (currentSpriteIndex + 1) % spritesToChange.Length;

                StartCoroutine(FadeIn());
            }));
        }
    }
    IEnumerator FadeOut(System.Action onComplete)
    {
        isFading = true;
        float elapsedTime = 0f;
        Color startColor = Color.white;
        Color endColor = new Color(1f, 1f, 1f, 0f); // 透明
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            foreach (SpriteRenderer renderer in spriteRenderers)
            {
                renderer.color = Color.Lerp(startColor, endColor, t);
            }
            yield return null;
        }
        onComplete?.Invoke();
        isFading = false;
    }

    IEnumerator FadeIn()
    {
        isFading = true;
        float elapsedTime = 0f;
        Color startColor = new Color(1f, 1f, 1f, 0f); // 透明
        Color endColor = Color.white;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            foreach (SpriteRenderer renderer in spriteRenderers)
            {
                renderer.color = Color.Lerp(startColor, endColor, t);
            }
            yield return null;
        }
        isFading = false;
    }
}
