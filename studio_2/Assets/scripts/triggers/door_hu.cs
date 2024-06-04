using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_hu : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            SceneLoadManager.Instance.LoadNextScene();
        }
    }
}
