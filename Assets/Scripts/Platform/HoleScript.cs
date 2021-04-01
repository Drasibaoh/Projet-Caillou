using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    public GameObject respawn;
    public AudioClip death;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag!=null && other.CompareTag("Player"))
        {
            AudioSource sound = other.GetComponent<AudioSource>();
            sound.clip = death;
            sound.Play();
            other.transform.position = respawn.transform.position;
        }
    }
}
