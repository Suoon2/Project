using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public GameObject UnderWorld;
    public void OnTapped()
    {
        Rigidbody body = this.gameObject.AddComponent<Rigidbody>();
        body.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.transform.parent.gameObject);
        Destroy(this.gameObject);
        UnderWorld.SetActive(true);
    }
}
