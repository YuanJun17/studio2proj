using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gobulin : MonoBehaviour
{
    void OnMouseEnter()
    {
        if (Input.GetKey(KeyCode.F))
        {
            SceneLoadManager.Instance.LoadNextScene();
        }
    }
}
