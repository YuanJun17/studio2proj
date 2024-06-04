using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public CanvasGroup text1CanvasGroup;
    public CanvasGroup text2CanvasGroup;
    void Start()
    {
        text1CanvasGroup.alpha = 0f;
        text2CanvasGroup.alpha = 0f;
    }
    void Update()
    {
        // 检测鼠标是否与物体发生碰撞，并且按下了 F 键
        if (Input.GetKeyDown(KeyCode.F) && IsMouseOverObject())
        {
            SceneLoadManager.Instance.LoadNextScene();
        }
        if (Input.GetMouseButtonDown(0) && IsMouseOverObject())
        {
            SceneLoadManager.Instance.LoadNextNextScene();
        }
    }
    void OnMouseEnter()
    {
        if (gameObject.CompareTag("circle"))
        {
            
            text1CanvasGroup.alpha = 1f; // 显示文字1
            text2CanvasGroup.alpha = 0f; // 隐藏文字2
            
        }


        if (gameObject.CompareTag("square"))
        {
            
            text1CanvasGroup.alpha = 0f; // 隐藏文字1
            text2CanvasGroup.alpha = 1f; // 显示 
        }
    }
    void OnMouseExit()
    {
        // 当物体离开碰撞区域时，隐藏所有文字
        text1CanvasGroup.alpha = 0f;
        text2CanvasGroup.alpha = 0f;
    }
 

    bool IsMouseOverObject()
    {
        // 获取鼠标当前位置
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 检测鼠标是否位于物体碰撞体内
        Collider2D collider = Physics2D.OverlapPoint(mousePosition);
        return collider != null && collider.gameObject == gameObject;
    }
}
    