using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject respawn;
    public CapsuleCollider colliderC;
    // Start is called before the first frame update
    void Start()
    {
        colliderC = GetComponent<CapsuleCollider>();

        respawn.transform.position = this.transform.position;

        Debug.Log("(Respawn.cs) Position respawn in start" + respawn.transform.position);
    }
    private void Update()
    {
        colliderC.center = new Vector3(colliderC.center.x, 0, colliderC.center.z);
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("(Respawn.cs) Entrée trigger");
        if (other.tag == "CP")
        {
            Debug.Log("(Respawn.cs) C'est un CP");
            respawn.transform.position = other.transform.position;
        }
    }
}
