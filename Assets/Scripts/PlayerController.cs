using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 2;
    Rigidbody2D rb2D;
    public Animator animator;
    private float dirX = 0;
    private float dirY = 0;
    private enum movemntStatemnt {idle, left, rigth, up, down}

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        rb2D.velocity = new Vector2(dirX*speed,rb2D.velocity.y);
        if (Input.GetKey("right") && Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }
        if (!Input.GetKey("right") && !Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }
        if (Input.GetKey("up"))
        {
            rb2D.velocity = new Vector2( rb2D.velocity.x, speed);
        }
        if (Input.GetKey("down"))
        {
            rb2D.velocity = new Vector2( rb2D.velocity.x, -speed);
        }
        if (Input.GetKey("up") && Input.GetKey("down"))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x,0);
        }
        if (!Input.GetKey("down") && !Input.GetKey("up"))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x,0);
        }
        UpdateAnim();
    }
    void UpdateAnim(){
        movemntStatemnt state;
        if(dirX > 0f){
            state = movemntStatemnt.rigth;
        }
        else if(dirX < 0f){
            state = movemntStatemnt.left;
        }
        else if(dirY < 0f){
            state = movemntStatemnt.down;
        }
        else if(dirY > 0f){
            state = movemntStatemnt.up;
        }
        else{
            state = movemntStatemnt.idle;
        }
        animator.SetInteger("state", (int)state);
    }
}
