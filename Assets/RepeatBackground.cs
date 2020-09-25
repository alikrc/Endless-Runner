using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 initPos;
    private BoxCollider boxCollider;
    private float halfSize;
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        boxCollider = GetComponent<BoxCollider>();
        halfSize = boxCollider.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < initPos.x - halfSize)
        {
            transform.position = initPos;
        }
    }
}
