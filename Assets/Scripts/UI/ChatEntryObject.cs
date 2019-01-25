using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatEntryObject : MonoBehaviour
{

    [SerializeField]
    private CanvasGroup movingBelow;

    void FadeIn(bool fromLeft)
    {
        float width = movingBelow.GetComponent<RectTransform>().rect.width;

        float targetX = movingBelow.transform.position.x;
        float startX = fromLeft ? (targetX-width) : (targetX + width);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
