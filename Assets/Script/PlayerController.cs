using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] Text scoreText;
    [SerializeField] Text winText;

    private int score;
    [SerializeField] private int scoreNeededToWin;

    private void Start()
    {
        score = 0;
        DisplayScore();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        rigidBody.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pickup")
        {
            Destroy(other.gameObject);
            score++;
            DisplayScore();
        }
    }

    void DisplayScore()
    {
        scoreText.text = "Score: " + score.ToString();
        
        if(score >= scoreNeededToWin)
            winText.gameObject.SetActive(true);
    }
}