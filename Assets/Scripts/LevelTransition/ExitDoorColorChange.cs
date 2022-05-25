using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorColorChange : MonoBehaviour
{
    //parameters
    [SerializeField] private Material _doorUnlockedMaterial;

    //cache
    private DoorUnlocker _doorUnlocker;
    private MeshRenderer _meshRenderer;

    private void Start() 
    {
        _doorUnlocker = GetComponent<DoorUnlocker>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetDoorUnlockedColor()
    {
        _meshRenderer.material = _doorUnlockedMaterial;
    }
}
