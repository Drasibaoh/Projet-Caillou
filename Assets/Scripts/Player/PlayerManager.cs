using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditorInternal;
using System.Dynamic;
using CMF;

public enum PlayerStates { Idle, Move, Jump, Swim }

public enum RockStates { Rock, Fire, Grass, Ice}

public class PlayerManager : MonoBehaviour
{
    public PlayerStates playerState;
    public RockStates rockState;
    private AdvancedWalkerController myController;

    public KeyCode switchToRock;
    public KeyCode switchToFire;
    public KeyCode switchToGrass;
    public KeyCode switchToIce;

    private Rigidbody myRb;
    private CapsuleCollider myCollider;
    public Vector3 centerCaps;
    private Respawn myRespawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        myController = GetComponent<AdvancedWalkerController>();
        myCollider = GetComponent<CapsuleCollider>();
        myRespawnPoint = GetComponent<Respawn>();
        

        myCollider.height = 1.5f;
        myCollider.center = centerCaps;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(switchToRock))
        {
            SetRock();
        }
        else if (Input.GetKeyDown(switchToFire))
        {
            SetFire();
        }
        else if (Input.GetKeyDown(switchToGrass))
        {
            SetGrass();
        }
        else if (Input.GetKeyDown(switchToIce))
        {
            SetIce();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject thisObject = other.gameObject;

        if (thisObject.tag == "GPlat" && rockState == RockStates.Grass)
        {
            Debug.Log("(PlayerManager.cs) C'est une GPlat");

            myController.jumpSpeed = 12.5f;
        }

        if (thisObject.tag == "Watter" && rockState == RockStates.Grass)
        {
            myController.gravity = 0f;
            myController.momentum = Vector3.zero;
        }

        if (thisObject.tag == "Watter" && rockState == RockStates.Ice)
        {
            myController.gravity = -30f;
            
        }

        if (thisObject.tag == "Watter" && rockState == RockStates.Fire)
        {
            IsDead();
        }

        if (thisObject.tag == "GPlat" && rockState == RockStates.Fire)
        {
            // chopper le collider parent de thisObject
        }

        if (thisObject.tag != "GPlat" && thisObject.tag != "Watter")
        {
            myController.jumpSpeed = 10f;
            myController.gravity = 30f;
            
        }

    }

    void IsDead()
    {
        myController.transform.position = myRespawnPoint.transform.position;
    }

    #region PLAYER STATES

    public void SetIdle()
    {
        playerState = PlayerStates.Idle;
    }
    public void SetMove()
    {
        playerState = PlayerStates.Move;
    }
    public void SetJump()
    {
        playerState = PlayerStates.Jump;
    }
    public void SetSwim()
    {
        playerState = PlayerStates.Swim;
    }

    #endregion

    #region ROCK STATES

    public void SetRock()
    {
        rockState = RockStates.Rock;
        Debug.Log("(PlayerManager.cs) is Rock");
    }

    public void SetFire()
    {
        rockState = RockStates.Fire;
        Debug.Log("(PlayerManager.cs) is Fire");
    }
    public void SetGrass()
    {
        rockState = RockStates.Grass;
        Debug.Log("(PlayerManager.cs) is Grass");
    }
    public void SetIce()
    {
        rockState = RockStates.Ice;
        Debug.Log("(PlayerManager.cs) is Ice");
    }

    #endregion
}
