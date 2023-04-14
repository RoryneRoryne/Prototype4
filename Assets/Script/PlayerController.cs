using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidBody;
    GameObject focalPoint;
    float knockbackStrength = 15f;
    public float speed = 5f;
    public bool hasPowerUp = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rigidBody.AddForce(focalPoint.transform.forward * forwardInput * speed);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            // Start the PowerUpCountdownRoutine coroutine to handle the powerup countdown.
            // Memulai PowerUpCountdownRoutine coroutine untuk mengonrtol hitung mundur powerup.
            StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    // Coroutine function to handle the powerup countdown.
    // Fungsi coroutine untuk mengontrol hitung mundur powerup.
    IEnumerator PowerUpCountdownRoutine()
    {
        // Wait for 7 seconds before executing the next line of code.
        // Menunggu 7 detik sebelum mengeksekusi code berikutnya.
        yield return new WaitForSeconds(7);
        // Set the "hasPowerUp" variable to false after the wait time has elapsed.
        hasPowerUp = false;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            // Get the Rigidbody component of the collided object.
            // Mengambul komponen rigidbody dari objek yang bertabrakan.
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            // Check if the collided object has a Rigidbody component.
            // Cek jika objek yang bertabrakan memiliki komponen rigidbody.
            if (enemyRb != null)
            {
                // Calculate the direction from this object to the collided object.
                // Kalkulasi arah dari player ke objek yang tabarkan.
                Vector3 knockbackDirection = other.gameObject.transform.position - transform.position;
                /* Normalize the knockback direction vector to ensure consistent magnitude
                   Apply the knockback force to the collided object*/
                /* Normalisasi vektor arah knockback untuk memastikan magnitudo yang konsisten
                   Terapkan gaya knockback pada objek yang bertabrakan */
                enemyRb.AddForce(knockbackDirection.normalized * knockbackStrength, ForceMode.Impulse);
                //output message.
                //pesan output.
                Debug.Log($"Collided with {other.gameObject.name} with PowerUp Set to {hasPowerUp}");
            }
            
        }
    }
}
