using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditorInternal;
using System.Dynamic;

public class Player : MonoBehaviour
{
    [SerializeField] private int formID;

    // Start is called before the first frame update
    void Start()
    {
        transform.gameObject.tag = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            Debug.Log("base");
            transform.gameObject.tag = "rock";
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            Debug.Log("fire");
            transform.gameObject.tag = "fire";
        }
        if (Input.GetKey(KeyCode.Keypad3))
        {
            Debug.Log("ice");
            transform.gameObject.tag = "ice";
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            Debug.Log("grass");
            transform.gameObject.tag = "grass";
        }


    }
}
