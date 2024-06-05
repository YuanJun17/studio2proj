using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager Instance;
    //private door1 door1;

    

    // ����������ڳ�������ʱ���ã���ʼ����̬ʵ��
    private void Awake()
    {
        // ȷ��ֻ��һ��ʵ������
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }

        // �����ö��󣬼�ʹ�������³���
        DontDestroyOnLoad(gameObject);
    }
   

    // ������һ�������ĺ���
    public void LoadNextScene()
    {
        // ��ȡ��ǰ����������
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ������һ�������������ǰ�����������һ������
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.LogWarning("��ǰ�����Ѿ������һ������");
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
            Debug.LogWarning("��ǰ�����Ѿ��ǵ����ڶ�������");
        }
    }
}
