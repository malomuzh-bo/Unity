using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject enemy;
    int max_amount = 3;
    public int current_amo;
    // Start is called before the first frame update
    void Start()
    {
        Method();
    }
    public void Method()
    {
        StartCoroutine(GenerateEnemies());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GenerateEnemies()
    {
        while (current_amo < max_amount)
        {
            Instantiate(enemy, new Vector3(6f, 0.25f, 1f), Quaternion.identity.normalized);
            yield return new WaitForSeconds(3f);
            current_amo++;
        }
    }
}
