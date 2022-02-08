using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    private int leftScore;
    private int rightScore;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sz = Random.Range(0, 2) == 0 ? Random.Range(-1.0f,-0.5f) : Random.Range(0.5f,1.0f);

        rb.velocity = new Vector3(speed * sx, 0f, speed * sz);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void LeftScores()
    {
        leftScore++;
        Debug.Log("Left Scored! Game Score: " + leftScore + " - " + rightScore);
        if (leftScore > 10)
        {
            GameOver();
            return;
        }
        rb.position = new Vector3(7, 0, 0);
        float z = Random.Range(0, 2) == 0 ? Random.Range(-1.0f,-0.5f) : Random.Range(0.5f,1.0f);
        rb.velocity = new Vector3(-1 * speed, 0f,speed * z);
    }
    
    private void RightScores()
    {
        rightScore++;
        Debug.Log("Right Scored! Game Score: " + leftScore + " - " + rightScore);
        if (rightScore > 10)
        {
            GameOver();
            return;
        }
        rb.position = new Vector3(-7, 0, 0);
        float z = Random.Range(0, 2) == 0 ? Random.Range(-1.0f,-0.5f) : Random.Range(0.5f,1.0f);;
        rb.velocity = new Vector3(speed, 0f,speed * z);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Left Goal"))
        {
            RightScores();
        }
        else
        {
            LeftScores();
        }
    }

    private void GameOver()
    {
        if (leftScore > rightScore)
        {
            Debug.Log("Game Over! Left Wins! 0 - 0");
        }
        else
        {
            Debug.Log("Game Over! Right Wins! 0 - 0");
        }
        
        rb.position = Vector3.zero;
        rb.velocity = Vector3.zero;
        leftScore = 0;
        rightScore = 0;
    }

    public void SpeedUp()
    {
        speed += 25;
    }

    public void AddForce(Vector3 force)
    {
        rb.AddForce(force);
    }
}
