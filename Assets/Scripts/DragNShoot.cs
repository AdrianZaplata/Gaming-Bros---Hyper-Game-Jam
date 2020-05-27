using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    public float power;
    public Rigidbody playerRb;
    public Vector3 minPower;
    public Vector3 maxPower;
    Camera mainCamera;
    Vector3 force;
    Vector3 startPoint;
    Vector3 endPoint;
 
    void Start()
    {
        mainCamera = Camera.main;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            startPoint = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position.z)) * -1;
            Debug.Log(startPoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPoint.y = 0f;
            endPoint = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position.z)) * -1;
            Debug.Log(endPoint);

            force = new Vector3(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), 0.0f, Mathf.Clamp(startPoint.z - endPoint.z, minPower.z, maxPower.z));
            playerRb.AddForce(force * power, ForceMode.Impulse);
        }
    }
}
