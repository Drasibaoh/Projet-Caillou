using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
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
            IsRock();
        }
        if (other.tag != null && other.tag == "fire")
        {
            IsFire(other.gameObject.transform);
        }
        if (other.tag != null && other.tag == "ice")
        {
            IsIce();
        }
        if (other.tag != null && other.tag == "grass")
        {
            IsGrass();
        }
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
        
    }
}
