using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float tear_speed = 8f;
    public float range = 60f;
    private float time = 0;
    public Rigidbody2D rb;
    private enum movemntStatemnt {left, rigth, up, down}
    public GameObject selfProyectile;
    float startX;
    float startY;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * tear_speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time++;
        if(time >= range){
            Destroy(selfProyectile);
        }
    }
}
