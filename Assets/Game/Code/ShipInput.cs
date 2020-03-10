using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipInput : MonoBehaviour
{
    public bool useMouseInput = true;
    public bool addRoll = true;

    public GameObject Bullet;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;
    public Animator Animator { get; set; }

    


    [Space]

    [Range(-1, 1)]
    public float pitch;
    [Range(-1, 1)]
    public float yaw;
    [Range(-1, 1)]
    public float roll;
    [Range(-1, 1)]
    public float strafe;
    [Range(0, 1)]
    public float throttle;

    private const float THROTTLE_SPEED = 0.5f;
    private Ship ship;

    private void Awake()
    {
        ship = GetComponent<Ship>();
        Animator = GetComponent<Animator>();
        Cursor.visible = true;
    }

    private void Start()
    {
        Cursor.visible = true;
    }

    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (useMouseInput)
        {
            strafe = Input.GetAxis("Horizontal");
            SetStickCommandsUsingMouse();
            UpdateMouseWheelThrottle();
            UpdateKeyboardThrottle(KeyCode.W, KeyCode.S);
            ActivateLightspeed(KeyCode.LeftShift);
            DisableLightspeed(KeyCode.LeftControl);
            BoosterActivate(KeyCode.Space);
            if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject clone = Instantiate(Bullet, transform.position, transform.rotation) as GameObject;
            }
            ShootRockets(KeyCode.Mouse1);
        }
        else
        {            
            pitch = Input.GetAxis("Vertical");
            yaw = Input.GetAxis("Horizontal");

            if (addRoll)
                roll = -Input.GetAxis("Horizontal") * 0.5f;

            strafe = 0.0f;
            UpdateKeyboardThrottle(KeyCode.R, KeyCode.F);
            ActivateLightspeed(KeyCode.LeftShift);
            DisableLightspeed(KeyCode.LeftControl);
        }
    }

    private void ShootRockets(KeyCode mouse1)
    {

    }

    private void ShootLasers(KeyCode mouse0)
    {
        

        if (Input.GetKey(mouse0))
        {
            Instantiate(Bullet, transform.position, transform.rotation);
        }
    }

    private void BoosterActivate(KeyCode space)
    {
        if (Input.GetKey(space)) throttle = 10;
    }

    private void SetStickCommandsUsingMouse()
    {
        Vector3 mousePos = Input.mousePosition;

        pitch = (mousePos.y - (Screen.height * 0.5f)) / (Screen.height* 0.5f);
        yaw = (mousePos.x - (Screen.width * 0.5f)) / (Screen.width * 0.5f);

        pitch = -Mathf.Clamp(pitch, -1.0f, 1.0f);
        yaw = Mathf.Clamp(yaw, -1.0f, 1.0f);
    }
    private void UpdateKeyboardThrottle(KeyCode increaseKey, KeyCode decreaseKey)
    {
        float target = throttle;

        if (Input.GetKey(increaseKey))
            target = 1.0f;
        else if (Input.GetKey(decreaseKey))
            target = 0.0f;

        throttle = Mathf.MoveTowards(throttle, target, Time.deltaTime * THROTTLE_SPEED);
    }


    private void UpdateMouseWheelThrottle()
    {
        throttle += Input.GetAxis("Mouse ScrollWheel");
        throttle = Mathf.Clamp(throttle, 0.0f, 1.0f);
    }

    private void ActivateLightspeed(KeyCode activateLightspeed)
    {
        if (Input.GetKey(activateLightspeed))
        {
            throttle = Mathf.MoveTowards(2000, 2000, Time.deltaTime * 2);
        }

    }

    private void DisableLightspeed(KeyCode disableLightspeed)
    {
        if (Input.GetKey(disableLightspeed))throttle = 0; 
    }
}