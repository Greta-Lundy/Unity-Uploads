using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;
    private bool zoom;
    private float T;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        zoom = false;
        T = Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (zoom)
        {

            scrollSpeed = Mathf.Lerp(scrollSpeed, -8, T);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
    }

    public void SpeedUp()
    {
        zoom = true;
    }
}
