using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAnimScript : MonoBehaviour
{
    private PlayerManager player;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& player.myController.IsGrounded())
        {
            anim.SetTrigger("Jump");
        }
        if ((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.D)) && player.myController.IsGrounded())
        {
            anim.SetBool("isWalking", true);
        }
        if ((Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.D)) )
        {
            anim.SetBool("isWalking", false);
        }

    }
}
