using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform weapon;
    public GameObject projectilePrefab;
    public float tear_delay = 8;
    private List<GameObject> tears;
    private List<ProjectileMovement> tears_scripts;
    private float delay = 0.0f;
    private float dirX = 0;
    private float dirY = 0;
    private enum movemntStatemnt {left, rigth, up, down}
    public SpriteRenderer spriteRend;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateAnim();
        if(delay <= 0)
            shoot();
        else
            delay--;
    }
    void shoot(){
        if(Input.GetKey("right")){
            tears.Add(Instantiate(projectilePrefab, weapon.position, weapon.rotation));
            delay=tear_delay;
        }
        else if(Input.GetKey("down")){
            tears.Add(Instantiate(projectilePrefab, weapon.position, weapon.rotation));
            delay=tear_delay;
        }
        else if(Input.GetKey("up")){
            tears.Add(Instantiate(projectilePrefab, weapon.position, weapon.rotation));
            delay=tear_delay;
        }
        else if(Input.GetKey("left")){
            tears.Add(Instantiate(projectilePrefab, weapon.position, weapon.rotation));
            delay=tear_delay;
        }
    }
    void updateAnim(){
        movemntStatemnt state;
        if(dirX > 0f){
            state = movemntStatemnt.rigth;
            spriteRend.flipX = false;
        }
        else if(dirX < 0f){
            state = movemntStatemnt.left;
            spriteRend.flipX = true;
        }
        else if(dirY < 0f){
            spriteRend.flipX = false;
            state = movemntStatemnt.down;
        }
        else if(dirY > 0f){
            spriteRend.flipX = false;
            state = movemntStatemnt.up;
        }
        else{
            spriteRend.flipX = false;
            state = movemntStatemnt.down;
        }
        animator.SetInteger("state", (int)state);
    }
}
