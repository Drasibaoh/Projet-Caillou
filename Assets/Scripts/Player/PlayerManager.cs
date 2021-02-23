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

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        myController = GetComponent<AdvancedWalkerController>();
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
    }

    public void SetFire()
    {
        rockState = RockStates.Fire;
    }
    public void SetGrass()
    {
        rockState = RockStates.Grass;
    }
    public void SetIce()
    {
        rockState = RockStates.Ice;
    }

    #endregion
}
