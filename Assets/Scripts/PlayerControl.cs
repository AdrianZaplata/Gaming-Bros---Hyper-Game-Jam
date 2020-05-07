using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class PlayerControl : MonoBehaviour
{

    [SerializeField] float speed;
    private Vector3 movingForce;
    private Vector3 boostForce;
    private Rigidbody playerRb;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool boostEnabled;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
        movingForce = new Vector3(0, 0, 1000);
        boostForce = new Vector3(0, 0, 2000);
        boostEnabled = false;
    }


    void FixedUpdate()
    {
        playerRb.AddForce(movingForce, ForceMode.Force);
    }

    private void LateUpdate()
    {
        speed = playerRb.velocity.magnitude;
        int mph = (int)(speed * 2.237f); // 3.6 for kph
        if(gameManager.isGameActive == true)
        {
            speedometerText.text = "Speed: " + mph + " mph";
        }
    }

    #region Boost Management

    private void DisableSpeedBoost()
    {
        boostEnabled = false;

    }

    private void EnableSpeedBoost()
    {
        boostEnabled = true;

    }

    private void OnTriggerExit(Collider other)
    {
        DisableSpeedBoost();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0))
        {
            EnableSpeedBoost();
        }

        if (boostEnabled == true)
        {
            if (Input.GetMouseButton(0))
            {
                playerRb.AddForce(boostForce, ForceMode.Force);
            }
        }

        //if (Input.GetTouch(0).phase == TouchPhase.Began)
        //    {
        //        speed += boost;
        //    }
    }

    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        int mph = (int)(speed * 2.237f); // 3.6 for kph
        if (collision.gameObject.tag == "Wall")
        {
            scoreText.gameObject.SetActive(true);
            scoreText.text = "Your score: " + mph * 1234;

        }
    }
}
