using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minImpulse = 12f;
    private float maxImpulse = 16f;
    private float maxTorque = 16f;
    private float xSpawnPosition = 4f;
    private float ySpawnPosition = -3f;

    private GameObject gameManager;




    void Start()
    { 
    targetRb = GetComponent<Rigidbody>();
    targetRb.AddForce(RandomForce(), ForceMode.Impulse);
    targetRb.AddTorque(RandomTorque(), ForceMode.Impulse);
    // Pour eviter de spawn toujours au meme endroit on random position de l'objet
    transform.position = RandomPosition();
    gameManager = GameObject.Find("Gamecontroller");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameManager.GetComponent<GameController>().UpdateScore(5);
    
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    Vector3 RandomForce() 
    {
        return Vector3.up * Random.Range(minImpulse,maxImpulse);
    }
    Vector3 RandomTorque() 
    {
        return new Vector3 (Random.Range(-maxTorque,maxTorque), Random.Range(-maxTorque,maxTorque), Random.Range(-maxTorque,maxTorque));
    }
    Vector3 RandomPosition() 
    {
        return new Vector3(Random.Range(-xSpawnPosition,xSpawnPosition),ySpawnPosition);

    }

}
