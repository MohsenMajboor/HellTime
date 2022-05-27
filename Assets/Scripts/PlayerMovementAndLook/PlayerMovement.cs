using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //parameters
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _jumpHeight = 2f;
    [SerializeField] private float _accelerationDueToGravity = -20;
    [SerializeField] [Range(0f,1f)] private float _timeScaleInAir = 0.5f;

    //state
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistanceForGroundCheck = 0.4f;
    private bool _isGrounded;



    //cache
    private Vector3 _velocity;
    private CharacterController _characterController;

    // Start is called before the first frame update
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistanceForGroundCheck, LayerMask.GetMask("Ground"));

        if(!_isGrounded)
        {
            Time.timeScale = _timeScaleInAir;
        }

        else if(_isGrounded && _velocity.y < 0f)
        {
            _velocity.y = -1f;
            Time.timeScale = 1f;
        }

        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        Vector3 movementVector = transform.right * xMovement + transform.forward * zMovement;

        _characterController.Move(movementVector * Time.deltaTime * _moveSpeed);

        if(Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(-2f * _accelerationDueToGravity * _jumpHeight);
        }

        _velocity.y += _accelerationDueToGravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);

    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    AmmoPickup ammoPickup = other.gameObject.GetComponent<AmmoPickup>();
    //    if (ammoPickup)
    //    {
    //        //FindObjectOfType<Weapon>().IncreaseAmmo(ammoPickup.GetAmmo());
    //        //ammoPickup.DestroyPickup();
    //    }
    //}
}
