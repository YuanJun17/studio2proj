using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class starttimeline : MonoBehaviour
{
    public PlayableDirector timeline; // ָ����ĳ����е�Timeline����

    void Start()
    {
        if (timeline != null)
        {
            // ����Timeline
            timeline.Play();
        }
        else
        {
            Debug.LogError("Timeline object not assigned!");
        }
    }
}
