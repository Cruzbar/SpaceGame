using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : MonoBehaviour
{
    public GameObject explosionPlanet;
    public GameObject outsideplanet;
    public GameObject Light;
    public GameObject Asteroid;

    public float timer;
    public Vector3 direction;
    int stoneLayer = 9;
    public Vector3 rotation;

    public float force;
    void Start()
    {
        explosionPlanet.SetActive(false);
        outsideplanet.SetActive(true);
        Light.SetActive(false);


        Rigidbody rb = Asteroid.GetComponent<Rigidbody>();

        var calculatedDirection = (explosionPlanet.transform.position - Asteroid.transform.position).normalized;
        rb.AddForce(calculatedDirection*force);
        rb.AddTorque(rotation);


    }


    void Update()
    {
        
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            Physics.IgnoreLayerCollision(stoneLayer, stoneLayer, false);
            Destroy(Asteroid);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter!");


    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter!");
        explosionPlanet.SetActive(true);
        outsideplanet.SetActive(false);
        Light.SetActive(true);
        timer = 0.1f;
    }
}
