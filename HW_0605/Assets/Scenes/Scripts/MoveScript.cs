using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    Transform endPoint;
    Generator generator;
    // Start is called before the first frame update
    void Start()
    {
        endPoint = GameObject.Find("Player").GetComponent<Transform>();
        generator = GameObject.Find("Generator").GetComponent<Generator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(endPoint.position.x, 0.25f, endPoint.position.z);
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
            generator.current_amo--;
            generator.Method();
        }
    }
}
