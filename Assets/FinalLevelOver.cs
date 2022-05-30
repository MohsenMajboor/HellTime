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
        enemyDestroyer.onAllEnemiesDead += ReplaceAllMaterials;
    }
    private void OnDisable()
    {
        enemyDestroyer.onAllEnemiesDead -= ReplaceAllMaterials;
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
