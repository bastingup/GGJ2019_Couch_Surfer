using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectAutoScroll : MonoBehaviour
{

    private ScrollRect scrollRect;
    [SerializeField]
    private Vector2 velocity;

    // Start is called before the first frame update
    void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        scrollRect.velocity = velocity;
    }
}
