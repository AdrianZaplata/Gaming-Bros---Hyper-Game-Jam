using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    bool isPressed;
    Rigidbody playerRb;
    public GameObject sling;
    float playerPosition;
    public float maxDragDistance;
    Rigidbody slingRb;
    TrailRenderer trail;

    float speedLimit = 1.0f;
    float speed;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerPosition = transform.position.z;
        slingRb = sling.GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();
    }


    void Update()
    {
        if (isPressed)
        {
            DragBall();
        }

        TrailOnSpeed();
        speed = playerRb.velocity.magnitude;
        int mph = (int)(speed * 2.237f);
    }

    private void DragBall()
    {
        Vector3 mousePosition = Input.mousePosition;
        float dist = playerRb.position.z - Camera.main.transform.position.z;
        mousePosition.z = dist + 1.485f;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.y = playerRb.position.y;

        float dragDistance = Vector3.Distance(mousePosition, sling.transform.position);

        if(dragDistance > maxDragDistance)
        {
            Vector3 direction = (mousePosition - sling.transform.position).normalized;
            playerRb.position = sling.transform.position + direction * maxDragDistance;
        }
        else
        {
            playerRb.position = mousePosition;
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        playerRb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        playerRb.isKinematic = false;
        StartCoroutine(ExecuteAfterTime(0.01f));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        sling.gameObject.SetActive(false);
    }

    private void DisableSling()
    {
        sling.gameObject.SetActive(false);
    }

    private void TrailOnSpeed()
    {
        int mph = (int)(speed * 2.237f);
        if (mph > speedLimit)
        {
            trail.enabled = true;
        }
    }
}
