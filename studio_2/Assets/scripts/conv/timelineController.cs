using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class timelineController : MonoBehaviour
{
    public PlayableDirector playableDirector; // Reference to the PlayableDirector
    public GameObject triggerPrefab; // Reference to the Trigger Prefab

    void Start()
    {
        // Ensure the PlayableDirector is assigned
        if (playableDirector == null)
        {
            playableDirector = GetComponent<PlayableDirector>();
        }
    }

    public void SpawnTrigger()
    {
        // Instantiate the trigger prefab
        GameObject trigger = Instantiate(triggerPrefab, Vector3.zero, Quaternion.identity);

        // Set the playableDirector reference in the trigger's script
        PauseTrigger triggerController = trigger.GetComponent<PauseTrigger>();
        if (triggerController != null)
        {
            triggerController.playableDirector = playableDirector;
        }
    }
}
