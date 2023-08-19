using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour
{
    AudioSource audio;
    cont cont;
    health health;
    public float vel = 3f,
        rotate = 150f,
        force = 250f;

    Rigidbody rb;

    private bool jump = false;

    void Start()
    {
        audio = GetComponents<AudioSource>()[2];
        health = GetComponent<health>();
        cont = GetComponent<cont>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
		//mover adelante
		if (Input.GetKey(KeyCode.W))
            transform.Translate(new Vector3(0,0,vel)*Time.deltaTime);
        //fin adelante
        //mover atras
        if (Input.GetKey(KeyCode.S))
            transform.Translate(new Vector3(0, 0, -vel) * Time.deltaTime);
        //fin atras
        //mover Derecha
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(new Vector3(0, rotate, 0) * Time.deltaTime);
        //fin Derecha
        //mover Izquierda
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(new Vector3(0, -rotate, 0) * Time.deltaTime);
		//fin Izquierda
		if (Input.GetKeyDown(KeyCode.E) && cont.count > 0 && health.life < 100)
		{
            cont.count = -1;
            health.cure(50);
		}
        //salto
        if (Input.GetKeyDown(KeyCode.Space) && jump)
		{
            rb.AddForce(0, force, 0);
            jump = !jump;
            if(!audio.isPlaying)
			{
                reproducir(5,10);
			}
		}
        //fin salto
    }
    public void reproducir(float inicio, float final)
    {
        //----metodo que quieras----
        audio.time = inicio;
        audio.Play();
        //----update----
		if (audio.isPlaying && audio.time >= final)
		{
            audio.Stop();
		}
    }
    private void OnCollisionStay(Collision collision)
	{
        if (!jump && collision.gameObject.tag == "ground")
        {
            jump = !jump;
        }
    }
}
