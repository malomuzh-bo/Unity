using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSctipt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(0f, 3f, 0f);
    }
}
