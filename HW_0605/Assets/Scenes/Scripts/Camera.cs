using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI healthText;
    
    float jump;
    bool is_trigerred = false;
    public int health;
    Rigidbody player;

    // Start is called before the first frame update
    void Start()
    {
        jump = 0.2f;    
        player = GetComponent<Rigidbody>();
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 1.1f)
        {
            player.velocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            player.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
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
        if (collision.gameObject.CompareTag("Crystal") && !is_trigerred)
        {
            score += 10;
            counterText.text = "Score: " + score.ToString();
            Debug.Log("Score: " + score);
            Destroy(collision.gameObject);
            is_trigerred = true;
        }

        if (collision.gameObject.CompareTag("Enemy") && !is_trigerred)
        {
            if (health - 20 != 0)
            {
                health -= 20;
                healthText.text = "Health: " + health.ToString();
                Debug.Log("Health: " + health);
            }
            else
            {
                health = 0;
                healthText.text = "Health: " + health.ToString();
                counterText.text = "You lost!";
                //Destroy(gameObject);
                Time.timeScale = 0;
            }
            is_trigerred = true;
        }
        StartCoroutine(Check());
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fast-portal"))
        {
            //Debug.Log("Collision works!");
            Time.timeScale = 2f;
        }
        if (other.gameObject.CompareTag("Slow-portal"))
        {
            //Debug.Log("Collision works!");
            Time.timeScale = 0.5f;
        }
        if (other.gameObject.CompareTag("Respawn"))
        {
            health = 100;
            healthText.text = "Health: " + health.ToString();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Fast-portal") || other.gameObject.CompareTag("Slow-portal"))
        {
            //Debug.Log("Collision works!");
            Time.timeScale = 1f;
        }
    }
    IEnumerator Check()
    {
        yield return new WaitForSeconds(1f);
        is_trigerred = false;   
    }
}
