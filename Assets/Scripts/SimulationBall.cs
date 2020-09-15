using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This script is not used anymore */


public class SimulationBall : MonoBehaviour
{
    private Rigidbody ball;
    //private float initBallSpeed = 50;

    private void Awake()
    {
        ball = GetComponent<Rigidbody>();
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Block"))
        {
            ball.velocity = ball.velocity.normalized * initBallSpeed; //when collide with blocks, move with same speed
        }

    }*/

}
