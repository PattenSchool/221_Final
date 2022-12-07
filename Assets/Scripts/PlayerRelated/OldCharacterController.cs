using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//https://www.youtube.com/watch?v=1LtePgzeqjQ

public class OldCharacterController : MonoBehaviour
{
    public Rigidbody rb;
    public float defaultSpeed;
    private float _speed;
    public float sprintSpeed;
    public float sensitivity;
    public float maxForce;
    private Vector2 _move;
    private Vector2 _look;
    private float lookRotation;
    public Camera main_camera;
    public bool grounded;
    public float jumpForce;

    public int maxHealth = 0;

    public int coins = 0;

    public List<string> enemyTags = new List<string>();

    private GameObject[] _enemiesArray;

    private List<GameObject> _enemies = new List<GameObject>();

    private bool isVulnerable = true;

    public void AddCoin()
    {
        coins += 1;
    }


    public void OnMove(InputAction.CallbackContext context) //input system for movement
    {
        _move = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Vector3 jumpForces = Vector3.zero;
        if (grounded)
        {
            jumpForces = Vector3.up * jumpForce;
            grounded = false;
        }

        rb.AddForce(jumpForces, ForceMode.VelocityChange);
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _speed = sprintSpeed;
        }
        else if (context.canceled)
        {
            _speed = defaultSpeed;
        }
    }

    public void SetGrounded(bool state)
    {
        grounded = state;
    }

    public void OnLook(InputAction.CallbackContext context) //input system for rotation
    {
        _look = context.ReadValue<Vector2>();
    }

    private void FixedUpdate() //use fixed because we have a rb that is physics-based
    {
        Vector3 currentVelocity = rb.velocity; //find target velocity
        Vector3 targetVelocity = new Vector3(_move.x, 0, _move.y); //take input and change it into a vector to move character
        targetVelocity *= _speed;

        targetVelocity = transform.TransformDirection(targetVelocity); //align direction with player so we move in right direction

        Vector3 velocityChange = (targetVelocity - currentVelocity); //calculate amount of forces to apply to player
        
        // Adds gravity to player by setting vertical velocity to zero
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);

        Vector3.ClampMagnitude(velocityChange, maxForce); //limit amount of force on player

        rb.AddForce(velocityChange, ForceMode.VelocityChange); //add velocity change to player
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //lock mouse in center of screen

        _speed = defaultSpeed;

        foreach (string tag in enemyTags)
        {
            _enemiesArray = GameObject.FindGameObjectsWithTag(tag);
            foreach (var obj in _enemiesArray)
            {
                _enemies.Add(obj);
            }
        }
    }

    void LateUpdate()                                                                                         //move camera after rest of scene has been updated
    {
        transform.Rotate(Vector3.up * _look.x * sensitivity);                                                                         //turn player on up axis

        lookRotation +=(-_look.y * sensitivity);                                                                                               //player looks up and down
        lookRotation = Mathf.Clamp(lookRotation, -90, 90);                                                              //player up and down looking stops at halfway up and down
        main_camera.transform.eulerAngles = new Vector3(lookRotation, 
        main_camera.transform.eulerAngles.y, main_camera.transform.eulerAngles.z);                          //rotate the camera (in world space)
    }

    private void Update()
    {
        foreach (GameObject enemy in _enemies)
        {
            if (Vector3.Distance(enemy.transform.position, this.gameObject.transform.position) < 2f)
            {
                DamagePlayer();
            }
        }

        if (maxHealth <= 0)
        {
            ToMainMenu.ToTheMain();
        }
    }

    private void DamagePlayer()
    {
        if (isVulnerable)
        {
            maxHealth--;

            StartCoroutine(ResetVulnerable());

            isVulnerable = false;
        }
    }

    private IEnumerator ResetVulnerable()
    {
        yield return new WaitForSeconds(3);

        isVulnerable = true;

        yield break;
    }
}
