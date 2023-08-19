using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class coin : MonoBehaviour
{
    public ParticleSystem[] ParticleSystem;
    CapsuleCollider BoxCollider;
    AudioSource AudioSource;
    cont playerCount;
    MeshRenderer MeshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider = GetComponent<CapsuleCollider>();
        MeshRenderer = GetComponent<MeshRenderer>();
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(150,-100,200)*Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        playerCount = collision.gameObject.GetComponent<cont>();
        playerCount.count = 1;
        AudioSource.Play();
        ParticleSystem[0].Stop();
        ParticleSystem[1].Play();
        BoxCollider.enabled = false;
        MeshRenderer.enabled = false;
    }

}
