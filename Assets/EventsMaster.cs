using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsMaster : MonoBehaviour
{

    [SerializeField]
    private Transform liveObjects;
    private List<GameObject> objectsToSpawn;

    private void Awake()
    {
        objectsToSpawn = new List<GameObject>();

        SceneEventTrigger[] events = FindObjectsOfType<SceneEventTrigger>();
        for (int i = 0; i < events.Length; i++)
        {
            if (events[i].gameObject.activeSelf)
            {
                events[i].gameObject.SetActive(false);
                objectsToSpawn.Add(events[i].gameObject);
            }
        }

        Spawn();
    }

    public void CleanUp()
    {
        for (int i = liveObjects.childCount - 1; i >= 0; i--)
        {
            Destroy(liveObjects.GetChild(i).gameObject);
        }
    }

    private void Spawn()
    {
        foreach (GameObject gameObject in objectsToSpawn)
        {
            Instantiate(gameObject, liveObjects).SetActive(true);
        }
    }

    public void ResetEvents()
    {
        CleanUp();
        Spawn();
    }
}
