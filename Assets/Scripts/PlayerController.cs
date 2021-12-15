using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    public static PlayerController instance;
    public float speed;
    public Animator anim;
    CharacterController characterController;
    Vector2 moveInput;
    Vector3 rootMotion;
    public GameObject playerObject;
    public bool isScoping;
    //public Camera scopeCam;
    //public KeyCode button;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void OnAnimatorMove()
    {
        rootMotion += anim.deltaPosition;
    }

    public void Movement()
    {
        moveInput.x = Input.GetAxis("Horizontal") * speed;
        moveInput.y = Input.GetAxis("Vertical") * speed;

        anim.SetFloat("InputX", moveInput.x);
        anim.SetFloat("InputY", moveInput.y);

        characterController.Move(rootMotion);
        rootMotion = Vector3.zero;
    }
}
