using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //parameters
    [SerializeField] private float _mouseSensitivity;
    [SerializeField] private Transform _playerParent;
    [SerializeField] bool upDownLook = false;

    //state
    private float _xRotation;


    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;    
    }


    // Update is called once per frame
    void Update()
    {
        float sensitivityTimeMultiplier = (1/Time.timeScale);

        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * _mouseSensitivity * sensitivityTimeMultiplier;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * _mouseSensitivity * sensitivityTimeMultiplier;

        _playerParent.Rotate(Vector3.up * mouseX);

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        if(upDownLook)
        {
            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        }
    }


}
