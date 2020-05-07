
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    [SerializeField] Vector3 offset;

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
