using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEventTrigger : MonoBehaviour
{

    public enum TriggerType { none, onEnter, onStay, onTriggerOrStay }

    [SerializeField]
    private TriggerType triggerType;

    [SerializeField]
    private SceneEvent sceneEvent;

    [SerializeField]
    private bool oneTimeTrigger;


    private void OnDrawGizmos()
    {
        if (sceneEvent)
            Gizmos.DrawIcon(transform.position, sceneEvent.GetGizmoIcon(), true);
    }

    internal void Won()
    {
        //StartCoroutine(ToWon());
        ToWon();
    }
    private void ToWon()
    {
        //yield return new WaitForSecondsRealtime(4);
        SceneManager.LoadScene(6);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggerType == TriggerType.onEnter || triggerType == TriggerType.onTriggerOrStay)
        {
            if (other.tag.Equals("Player"))
            {
                if (oneTimeTrigger)
                    Destroy(gameObject);
                sceneEvent.Play(this);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (triggerType == TriggerType.onStay || triggerType == TriggerType.onTriggerOrStay)
        {
            if (other.tag.Equals("Player"))
            {
                if (oneTimeTrigger)
                    Destroy(gameObject);
                sceneEvent.Play(this);
            }
        }
    }
}
