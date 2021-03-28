using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Dynamic;
using CMF;
using UnityEngine.VFX;
public enum PlayerStates { Idle, Move, Jump, Swim }

public enum RockStates { Rock, Fire, Grass, Ice}

public class PlayerManager : MonoBehaviour
{
    [Header("player")]
    public static PlayerManager _instance;
    public PlayerStates playerState;
    public RockStates rockState;
    public AdvancedWalkerController myController;
    [Header("keys")]
    public KeyCode switchToRock;
    public KeyCode switchToRock2;
    public KeyCode switchToFire;
    public KeyCode switchToFire2;
    public KeyCode switchToGrass;
    public KeyCode switchToGrass2;
    public KeyCode switchToIce;
    public KeyCode switchToIce2;

    private AdvancedWalkerController myRock;
    private AdvancedWalkerController myFire;
    private AdvancedWalkerController myGrass;
    private AdvancedWalkerController myIce;
    [Header("FormVisualFeedBakc")]
    public SkinnedMeshRenderer myRenderer;
    public Material rockform;
    public Material fireform;
    public Material iceform;
    public Material grassform;
    public PauseMenu feedback;
    [Header("FormParticlesFeedBakc")]
    public GameObject rock;
    public VisualEffect rockpoof;
    public GameObject fire;
    public GameObject grass;
    public GameObject ice;
    [Header("FormAudioFeedBakc")]
    public AudioSource sound;
    public List<AudioClip> footstep;
    public List<AudioClip> formChange;
    [Header("Collider")]
    private Rigidbody myRb;
    private CapsuleCollider myCollider;
    public Vector3 centerCaps;
    private Respawn myRespawnPoint;
    public float heightmodifier;

    private float gape;
    private Vector3 formerPos;
    private Vector3 newPos;
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
        if (Input.GetKeyDown(switchToRock) || Input.GetKeyDown(switchToRock2))
        {
            SetRock();
            myCollider.enabled = false;
            myCollider.enabled = true;

        }
        else if (Input.GetKeyDown(switchToFire) || Input.GetKeyDown(switchToFire2))
        {
            SetFire();
            myCollider.enabled = false;
            myCollider.enabled = true;
        }
        else if (Input.GetKeyDown(switchToGrass) || Input.GetKeyDown(switchToGrass2))
        {
            SetGrass();
            myCollider.enabled = false;
            myCollider.enabled = true;
        }
        else if (Input.GetKeyDown(switchToIce) || Input.GetKeyDown(switchToIce2))
        {
            SetIce();
            myCollider.enabled = false;
            myCollider.enabled = true;
        }
        if (gape >= 0.8f)
        {
            newPos = transform.position;
            if (myController.IsGrounded() && formerPos.z != newPos.z)
            {
                int rand = Random.Range(0, footstep.Count);
                sound.clip = footstep[rand];
                sound.Play();
            }
            formerPos = newPos;
            gape = 0f;
        }
        gape += Time.deltaTime;
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
            myController.gravity = 10f;
            myController.movementSpeed = 5f;
            myController.jumpSpeed = 3f;
            
        }
        if (thisObject.tag == "Watter" && rockState == RockStates.Grass)
        {
            myController.gravity = 0f;
            myController.jumpSpeed = 0f;
            myController.momentum = Vector3.zero;
        }

        if (thisObject.tag == "Watter" && rockState == RockStates.Ice)
        {
            BoxCollider surface = thisObject.GetComponent<BoxCollider>();
            transform.position = new Vector3(transform.position.x, thisObject.transform.position.y+surface.center.y + thisObject.transform.localScale.y*heightmodifier+surface.size.y/2, transform.position.z);
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

        if (thisObject.tag != "GPlat" && thisObject.tag != "Watter" && thisObject.tag != "PostProcess")
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
        myRenderer.material = rockform;
        feedback.ChangeToRock();
        rock.SetActive(true);
        rockpoof.Play();
        fire.SetActive(false);
        grass.SetActive(false);
        ice.SetActive(false);
        sound.clip = formChange[0];
        sound.Play();
        Debug.Log("(PlayerManager.cs) is Rock");

    }

    public void SetFire()
    {
        rockState = RockStates.Fire;
        myRenderer.material = fireform;
        feedback.ChangeToFire();
        rock.SetActive(false);
        fire.SetActive(true);
        grass.SetActive(false);
        ice.SetActive(false);
        sound.clip = formChange[1];
        sound.Play();
        Debug.Log("(PlayerManager.cs) is Fire");

    }
    public void SetGrass()
    {
        rockState = RockStates.Grass;
        myRenderer.material = grassform;
        feedback.ChangeToGrass();
        rock.SetActive(false);
        fire.SetActive(false);
        grass.SetActive(true);
        ice.SetActive(false);
        sound.clip = formChange[2];
        sound.Play();
        Debug.Log("(PlayerManager.cs) is Grass");
    }
    public void SetIce()
    {
        rockState = RockStates.Ice;
        myRenderer.material = iceform;
        feedback.ChangeToIce();
        rock.SetActive(false);
        fire.SetActive(false);
        grass.SetActive(false);
        ice.SetActive(true);
        sound.clip = formChange[3];
        sound.Play();
        Debug.Log("(PlayerManager.cs) is Ice");
    }

    #endregion

}
