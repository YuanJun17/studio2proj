using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class starttimeline : MonoBehaviour
{
    public PlayableDirector timeline; // 指向你的场景中的Timeline对象

    void Start()
    {
        if (timeline != null)
        {
            // 播放Timeline
            timeline.Play();
        }
        else
        {
            Debug.LogError("Timeline object not assigned!");
        }
    }
}
