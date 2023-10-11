using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform weapon;
    public GameObject projectilePrefab;
    public float tear_delay = 24f;
    public float range = 10f;
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
        if(delay <= 0)
            shoot();
        else
            delay--;
    }
    void shoot(){
        movemntStatemnt state=0;
        if(Input.GetKey("left")){
            GameObject obj = Instantiate(projectilePrefab, weapon.position, weapon.rotation);
            state = movemntStatemnt.left;
            obj.GetComponent<ProjectileMovement>().defineDirection((int)state, range);
            delay=tear_delay;
        }
        else if(Input.GetKey("right")){
            GameObject obj = Instantiate(projectilePrefab, weapon.position, weapon.rotation);
            state = movemntStatemnt.rigth;
            obj.GetComponent<ProjectileMovement>().defineDirection((int)state, range);
            delay=tear_delay;
        }
        else if(Input.GetKey("up")){
            GameObject obj = Instantiate(projectilePrefab, weapon.position, weapon.rotation);
            state = movemntStatemnt.up;
            obj.GetComponent<ProjectileMovement>().defineDirection((int)state, range);
            delay=tear_delay;
        }
        else if(Input.GetKey("down")){
            GameObject obj = Instantiate(projectilePrefab, weapon.position, weapon.rotation);
            state = movemntStatemnt.down;
            obj.GetComponent<ProjectileMovement>().defineDirection((int)state, range);
            delay=tear_delay;
        }
    }
}
