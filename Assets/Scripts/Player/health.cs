using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public int life = 100;
    private int maxLife = 100;
    public Text LifeText;
    public Slider LifeCont;
    ParticleSystem Particle;
    AudioSource[] Audio;

    // Start is called before the first frame update
    void Start()
    {
        Particle = GetComponentInChildren<ParticleSystem>();
        Audio = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
		if (life < 30 && !Audio[1].isPlaying)
		{
            Audio[1].Play();
		}
		if (life > 30)
        {
            Audio[1].Stop();
		}
    }

    public void death()
    {
        SceneManager.LoadScene(0);
    }

    public void cure(float health)
	{
		if (!Audio[0].isPlaying && life < 100)
		{
            Audio[0].Play();
		}
        life = Mathf.Clamp(life, 0, maxLife);
        Particle.Play();
        life += (int)health;
        LifeCont.value = life;
	}
	public void takeDamage(float damage)
    {
        life -= (int)damage;
        life=Mathf.Clamp(life,0,maxLife);
        LifeCont.value = life;
		if (life <= 0)
		{
            death();
		}
    }
	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "death")
        {
            death();
        }
    }
	private void OnTriggerStay(Collider other)
	{
        if (other.gameObject.tag == "health")
        {
            cure(10);
        }
    }
}
