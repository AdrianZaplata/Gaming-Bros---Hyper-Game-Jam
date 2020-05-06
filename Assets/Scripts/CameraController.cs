using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    [SerializeField] Vector3 offset;

    void Start()
    {
        
    }


    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
