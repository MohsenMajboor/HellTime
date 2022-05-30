using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRunFromPlayer : MonoBehaviour
{

    //parameters
    [SerializeField] GameObject player;

    [SerializeField] float followRange = 40f;
    [SerializeField] float speed = 10f;

    bool keepRunning;


    //cache
    CapsuleCollider capsuleCollider;
    Rigidbody rb;

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        keepRunning = false;
    }

    private void Update()
    {

        bool isTouchingGround = Physics.CheckSphere(transform.position, 3f, LayerMask.GetMask("Ground"));

        if(!isTouchingGround)
        {
            rb.velocity = new(1f, -5f, 1f);
        }

        if ((Vector3.Distance(transform.position, player.transform.position) < followRange || keepRunning))
        {
            keepRunning = true;

            Vector3 playerPosition = new(player.transform.position.x, 0f, player.transform.position.z);
            Vector3 enemyPosition = new(transform.position.x, 0f, transform.position.z);
            Vector3 direction = (playerPosition - enemyPosition).normalized;
            rb.velocity = new Vector3(-direction.x, rb.velocity.y, -direction.z) * speed;
        }
    }
}

