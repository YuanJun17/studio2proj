using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class questionChange : MonoBehaviour
{
    public Sprite[] spritesToChange; // Ҫ�л���Sprite����
    public SpriteRenderer[] spriteRenderers; // Sprite��Ⱦ������
    private int currentSpriteIndex = 0; // ��ǰSprite������
    public float fadeDuration = 1.0f; // ���뵭������ʱ��
  
    private bool isFading = false; // ����Ƿ����ڵ��뵭��
    private bool allSpritesChanged = false; // ����Ƿ����л�������Sprite

    void Start()
    {
        // ���İ�ť�����¼�
        yesbutton.OnButtonPressed += HandleButtonPressed;
        nobutton.OnButtonPressed += HandleButtonPressed;
    }

    void HandleButtonPressed(bool isYesButton)
    {
        if (allSpritesChanged || isFading) return;
        if (!isFading && spritesToChange.Length > 0)
        {
            StartCoroutine(FadeOut(() =>
            {
                // �л�Sprite
                foreach (SpriteRenderer renderer in spriteRenderers)
                {
                    renderer.sprite = spritesToChange[currentSpriteIndex];
                }
                currentSpriteIndex++;

                // ����Ƿ����л�������Sprite
                if (currentSpriteIndex >= spritesToChange.Length)
                {
                    allSpritesChanged = true;
                }
                else
                {
                    StartCoroutine(FadeIn());
                }
            }));
        }
    }
    IEnumerator FadeOut(System.Action onComplete)
    {
        isFading = true;
        float elapsedTime = 0f;
        Color startColor = Color.white;
        Color endColor = new Color(1f, 1f, 1f, 0f); // ͸��
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
        Color startColor = new Color(1f, 1f, 1f, 0f); // ͸��
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
