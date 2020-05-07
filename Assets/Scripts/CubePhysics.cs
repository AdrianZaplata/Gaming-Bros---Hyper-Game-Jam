using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePhysics : MonoBehaviour
{
    public PhysicMaterial physicMaterial;

    public float radius = 5.0F;
    public float power = 10.0F;



    IEnumerator Start()
    {
        yield return new WaitForSeconds(5);
        GetComponent<Collider>().material = physicMaterial;




        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 explosionPos = transform.position;
            Collider[]
            colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
            }

        }
    }


}
