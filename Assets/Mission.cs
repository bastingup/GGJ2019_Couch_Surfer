using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    [SerializeField]
    private ChatMission mission;
    [SerializeField]
    private ChatFieldObject chatFieldObjectPrefab;

    void Start()
    {
        Transform spawnRoot = UIMaster.Instance.inCanvasView;
        Instantiate(chatFieldObjectPrefab, spawnRoot).ShowMission(mission);
    }
}
