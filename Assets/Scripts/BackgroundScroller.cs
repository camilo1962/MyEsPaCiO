using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed;

    private Vector3 startPosition;
    private float tileSize;

    void Start()
    {
        startPosition = transform.position;
        tileSize = transform.localScale.y;

    }

    
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}
