using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalLevelOver : MonoBehaviour
{
    [SerializeField] Material floorMat, crosshairMat, skyboxMat;
    [SerializeField] Sprite gunSprite;


    [SerializeField] EnemyDestroyer enemyDestroyer;
    [SerializeField] Image crosshair;
    [SerializeField] SpriteRenderer gun;

    [SerializeField] TextMeshProUGUI healthText, ammoText;

    private void OnEnable()
    {
        enemyDestroyer.onMostEnemiesDead += ReplaceAllMaterials;
        enemyDestroyer.onMostEnemiesDead += RemovePlayerControls;
    }
    private void OnDisable()
    {
        enemyDestroyer.onMostEnemiesDead -= ReplaceAllMaterials;
        enemyDestroyer.onMostEnemiesDead -= RemovePlayerControls;
    }


    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            ReplaceAllMaterials();
        }
    }


    void RemovePlayerControls()
    {
        gun.enabled = false;
        FindObjectOfType<MouseLook>().enabled = false;
        FindObjectOfType<PlayerMovement>().enabled = false;
        FindObjectOfType<WeaponUser>().enabled = false;
        crosshair.enabled = false;
    }


    void ReplaceAllMaterials()
    {
        var meshRenderers = FindObjectsOfType<MeshRenderer>();
        foreach(var mesh in meshRenderers)
            mesh.material = floorMat;

        crosshair.material = crosshairMat;

        RenderSettings.skybox = skyboxMat;

        gun.sprite = gunSprite;

        healthText.enabled = false;
        ammoText.enabled = false;
    }
}
