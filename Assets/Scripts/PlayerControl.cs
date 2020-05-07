using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour
{

    [SerializeField] float speed;
    private Vector3 movingForce;
    private Vector3 boostForce;
    private Rigidbody playerRb;
    [SerializeField] float movingF;
    [SerializeField] float boostF;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Button restartButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] bool boostEnabled;
    private GameManager gameManager;
    public GameObject endPosition;
    public Transform building;
    [SerializeField] float speedLimit;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
        movingForce = new Vector3(0, 0, movingF);
        boostForce = new Vector3(0, 0, boostF);
        boostEnabled = false;
    }


    void FixedUpdate()
    {
        playerRb.AddForce(movingForce, ForceMode.Force);

    }

    private void LateUpdate()
    {
        TrailOnSpeed();
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
        gameObject.GetComponent<TrailRenderer>().enabled = false;
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
                gameObject.GetComponent<TrailRenderer>().enabled = true;
            }
        }

        //if (Input.GetTouch(0).phase == TouchPhase.Began)
        //    {
        //        speed += boost;
        //    }
    }

    #endregion


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EndOfRoute")
        {
            Camera.main.GetComponent<CameraController>().enabled = false;
            Camera.main.transform.position = endPosition.transform.position;
            Camera.main.transform.LookAt(building);

            int mph = (int)(speed * 2.237f);
            scoreText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            mainMenuButton.gameObject.SetActive(true);
            scoreText.text = "Your score: " + mph;
        }

    }

    private void TrailOnSpeed()
    {
        int mph = (int)(speed * 2.237f);
        if (mph > speedLimit)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
