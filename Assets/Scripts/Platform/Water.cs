using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag!=null && other.tag == "rock")
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            IsRock();
        }
        if (other.tag != null && other.tag == "fire")
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            IsFire(other.gameObject.transform);
        }
        if (other.tag != null && other.tag == "ice")
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            IsIce();
        }
        if (other.tag != null && other.tag == "grass")
        {
            IsGrass();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }


    public void IsRock()
    {
        
    }
    public void IsFire(Transform player)
    {
        player.position = checkpoint.transform.position;
    }
    public void IsIce()
    {

    }
    public void IsGrass()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY;
    }
    
}
