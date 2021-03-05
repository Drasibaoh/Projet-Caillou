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
    public static PlayerManager _instance;
    public PlayerStates playerState;
    public RockStates rockState;
    private AdvancedWalkerController myController;

    public KeyCode switchToRock;
    public KeyCode switchToFire;
    public KeyCode switchToGrass;
    public KeyCode switchToIce;

    private AdvancedWalkerController myRock;
    private AdvancedWalkerController myFire;
    private AdvancedWalkerController myGrass;
    private AdvancedWalkerController myIce;

    public GameObject rockform;
    public GameObject fireform;
    public GameObject iceform;
    public GameObject grassform;

    private Rigidbody myRb;
    private CapsuleCollider myCollider;
    public Vector3 centerCaps;
    private Respawn myRespawnPoint;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
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
            myCollider.enabled = false;
            myCollider.enabled = true;

        }
        else if (Input.GetKeyDown(switchToFire))
        {
            SetFire();
            myCollider.enabled = false;
            myCollider.enabled = true;
        }
        else if (Input.GetKeyDown(switchToGrass))
        {
            SetGrass();
            myCollider.enabled = false;
            myCollider.enabled = true;
        }
        else if (Input.GetKeyDown(switchToIce))
        {
            SetIce();
            myCollider.enabled = false;
            myCollider.enabled = true;
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

        if (thisObject.tag == "Watter" && rockState == RockStates.Rock)
        {
            myController.gravity -= 20f;
            myController.movementSpeed -= 5f;
            myController.jumpSpeed = 3f;
            
        }
        if (thisObject.tag == "Watter" && rockState == RockStates.Grass)
        {
            myController.gravity = 0f;
            myController.momentum = Vector3.zero;
        }

        if (thisObject.tag == "Watter" && rockState == RockStates.Ice)
        {
            BoxCollider surface = thisObject.GetComponent<BoxCollider>();
            transform.position = new Vector3(transform.position.x, thisObject.transform.position.y+surface.center.y + thisObject.transform.localScale.y*0.8f+surface.size.y/2, transform.position.z);
            myController.gravity = 0f;
            myController.momentum = Vector3.zero;

        }

        if (thisObject.tag == "GPlat" && rockState == RockStates.Fire)
        {
            other.gameObject.SetActive(false);
            Debug.Log("eee");
            StartCoroutine(Wait(thisObject, 3f));
            Debug.Log("eeeee");
            // chopper le collider parent de thisObject
        }

        if (thisObject.tag != "GPlat" && thisObject.tag != "Watter")
        {
            myController.jumpSpeed = 10f;
            myController.gravity = 30f;
        }

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Watter" )
        {
           
            myController.movementSpeed = 10f;
            myController.gravity = 30f;
            myController.jumpSpeed = 10f;
        }
    }

    void OnTriggerExit ()
    {
        myController.gravity = 30f;
        myController.momentum = Vector3.zero;
    }

    public IEnumerator Wait(GameObject plateforme, float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Debug.Log("eeee");
        plateforme.SetActive(true);

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
