using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    Rigidbody rigidBody;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        /*This code adds a force to a rigidbody to move towards the player. 
        The magnitude of the force is determined by the speed variable.*/
        /* Kode ini menambahkan gaya pada rigidbody untuk bergerak menuju pemain. 
        Besarnya gaya ditentukan oleh variabel speed.*/
        Vector3 enemyChase = (player.transform.position - transform.position).normalized; 
        rigidBody.AddForce(enemyChase* speed);
    }
}
