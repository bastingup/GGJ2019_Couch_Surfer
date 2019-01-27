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

    public void ResetMission()
    {
        Transform spawnRoot = UIMaster.Instance.inCanvasView;

        for (int i = spawnRoot.childCount - 1; i >= 0; i--)
        {
            Destroy(spawnRoot.GetChild(i).gameObject);
        }

        Instantiate(chatFieldObjectPrefab, spawnRoot).ShowMission(mission);

    }
}
