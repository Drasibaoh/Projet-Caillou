using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesScript : MonoBehaviour
{
    public AudioSource feedback;
    public AudioClip sound;
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
        if (other.tag == "Player")
        {
            PickUp();
            Destroy(this.gameObject);
        }
    }
    public void PickUp()
    {
        feedback.clip = sound;
        feedback.Play();
        GameManager._instance.collectedCollectibles++;
    }
}
