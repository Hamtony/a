using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using UnityEditorInternal;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private GameObject player;
    private float distance;
    private Vector2 direction;
    private Animator animator;
    private enum movementState {idle, left, right, up, down}
    public float vida = 10;
    private Rigidbody2D rigidbody2D;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Isaac");
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(vida <= 0){
            animator.SetBool("dying", true);
            rigidbody2D.simulated = false;
        }
        else{
            distance= Vector2.Distance(transform.position, player.transform.position);
            direction = player.transform.position - transform.position;
            direction.Normalize();
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            UpdateAnimation();
        }
    }

    void UpdateAnimation()
    {
        movementState state;
        if(direction.x > 0f){
            state = movementState.right;
        }
        else if(direction.x < 0f){
            state = movementState.left;
        }
        else if(direction.y < 0f){
            state = movementState.down;
        }
        else if(direction.y > 0f){
            state = movementState.up;
        }
        else{
            state = movementState.idle;
        }
        animator.SetInteger("state", (int)state);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Projectile")
        {
            vida--;
        }
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
