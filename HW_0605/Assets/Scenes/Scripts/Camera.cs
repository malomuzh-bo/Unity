using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI counterText;
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
        float v_distance = Input.GetAxis("Vertical");
        float h_distance = Input.GetAxis("Horizontal");
        Vector3 vector3 = new Vector3(0f, 0f, v_distance);
        transform.Translate(vector3 * 0.05f);
        transform.Rotate(0f, h_distance * 2f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crystal"))
        {
            score += 10;
            counterText.text = "Score: " + score.ToString();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            counterText.text = "You lost!";
            Destroy(gameObject);
        }
    }
}
