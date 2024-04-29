using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager Instance;
    //private door1 door1;

    

    // 这个函数会在场景加载时调用，初始化静态实例
    private void Awake()
    {
        // 确保只有一个实例存在
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // 保留该对象，即使加载了新场景
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
    }

    // 加载下一个场景的函数
    public void LoadNextScene()
    {
        // 获取当前场景的索引
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // 加载下一个场景，如果当前场景不是最后一个场景
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.LogWarning("当前场景已经是最后一个场景");
        }
    }
    public void LoadNextNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 2)
        {
            SceneManager.LoadScene(currentSceneIndex + 2);
        }
        else
        {
            Debug.LogWarning("当前场景已经是倒数第二个场景");
        }
    }
}
