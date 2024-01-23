using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{

    private const float yDie = 0.0f;
    public float forceValue;
    public float jumpValue;
    private AudioSource audiosource;
    private bool inContact;
    private Rigidbody rb;
 public float velocity = 10;
    private Renderer rd;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rd = GetComponent<Renderer>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

     if(Input.GetButtonDown("Jump") && inContact) 
     {
        rb.AddForce(Vector3.up * jumpValue, ForceMode.Impulse);
        audiosource.Play();
        inContact = false;
     }

     if(Input.touchCount == 1){
        if(Input.touches[0].phase == TouchPhase.Began && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * jumpValue, ForceMode.Impulse);
            audiosource.Play();
        }
     }

        MoverEsferaAdelante();

    if(transform.position.y < yDie)
            SceneManager.LoadScene("Lose");

    }

    private void FixedUpdate(){
        rb.AddForce(new Vector3(Input.GetAxis("Horizontal")* forceValue ,
                               0,
                                0));

         rb.AddForce(new Vector3(Input.acceleration.x  * forceValue,
                                0,
                                0));                        
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("Suelo"))
        {
            inContact = true;
        } 

        if(collision.gameObject.CompareTag("Enemy") )
        {
            SceneManager.LoadScene("Lose");
        } else if (collision.gameObject.CompareTag("Final")){
            SceneManager.LoadScene("Bola2");
        }else if (collision.gameObject.CompareTag("Final2")){
            SceneManager.LoadScene("Win");
        }
        
    }



    private void OnTriggerEnter(Collider other)
    {
        rd.material.color = Color.blue;
    }


    void MoverEsferaAdelante()
    {
        // Obtener la posición actual de la esfera
        Vector3 posicionActual = transform.position;

        // Calcular la nueva posición hacia adelante
        Vector3 nuevaPosicion = posicionActual + transform.forward * velocity * Time.deltaTime;

        // Actualizar la posición de la esfera
        transform.position = nuevaPosicion;
    }

}
