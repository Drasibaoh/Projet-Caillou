using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject respawn;

    // Start is called before the first frame update
    void Start()
    {
        respawn.transform.position = this.transform.position;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entrée trigger");
        if (other.tag == "CP")
        {
            Debug.Log("C'est un CP");
            respawn.transform.position = other.transform.position;
        }
    }
}
