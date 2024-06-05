using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PauseTrigger : MonoBehaviour
{
    public PlayableDirector playableDirector; // Reference to the PlayableDirector
    private bool isPaused = false;

    void Start()
    {
        PauseTimeline();
    }

    void PauseTimeline()
    {
        if (playableDirector != null)
        {
            playableDirector.Pause();
            isPaused = true;
        }
    }

    void Update()
    {
        if (isPaused && Input.GetMouseButtonDown(0)) // Check for mouse click
        {
            ResumeTimeline();
        }
    }

    void ResumeTimeline()
    {
        if (playableDirector != null)
        {
            playableDirector.Play();
            Destroy(gameObject); // Destroy the trigger object after resuming
            isPaused = false;
        }
    }
}
