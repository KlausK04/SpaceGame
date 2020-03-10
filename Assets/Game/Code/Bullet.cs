using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1000;
    public int power = 1;

    public float lifeTime = 10.0f;
    void Start()
    {
        var Ship = GameObject.Find("PlayerShip");
        var PlayerSpeed = Ship.GetComponent<Rigidbody>().velocity;

        GetComponent<Rigidbody>().velocity = transform.forward * speed + PlayerSpeed;

        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
