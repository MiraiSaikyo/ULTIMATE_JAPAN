using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_SE : MonoBehaviour {


    public Bullet_particle Bullet_particle_;
    public AudioClip AudioClip_;
    AudioSource AudioSource_;
    // Use this for initialization
    void Start () {
        AudioSource_ = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		if(Bullet_particle_.isExplosion==true)
        {

            AudioSource_.clip = AudioClip_;
            AudioSource_.Play();
            Bullet_particle_.isExplosion = false;
        }
	}
}
