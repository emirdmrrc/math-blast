using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float speed = 0.5f;
    private Vector3 StartPosition;
    void Start()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(translation: Vector3.down * speed * Time.deltaTime);
       if (transform.position.y < -9.42f)
        {
            transform.position = StartPosition;
        }
    }
}
