using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour
{
    private Rigidbody ball;
    public BallTrajectory ballTrajectory;
    private Vector3 ballDir;
    private int ballPower = 50;
    private float initBallSpeed;

    private GameObject mainCamera;
    public GameObject ballCamera;

    public GameObject simulationBall;
    private void Awake()
    {
        ball = GetComponent<Rigidbody>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Start()
    {
        ballTrajectory.copyAllObstacles();
    }

    void Update()
    {

    }

    private void OnMouseDrag()
    {
        ballDir = (this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)).normalized;
        //ballDir = new Vector3(ballDir.x, 0.05f, ballDir.z);
        ballTrajectory.predict(simulationBall, this.transform.position, ballDir * ballPower); //simulate the trajectory
    }

    private void OnMouseUp()
    {
        ball.velocity = ballDir * ballPower;
        //ball.AddForce(ballDir * ballPower); //ball move

        ChangeCamera();
        initBallSpeed = ball.velocity.magnitude;

        ballTrajectory.clearPrediction(); //delete the trajectory
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Goal"))
        {
            Debug.Log("GOALLLLL");
            Goal();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Block"))
        {
            //ball.velocity = ball.velocity.normalized * initBallSpeed; //when collide with blocks, move with same speed
        }

    }

    private void ChangeCamera()
    {
        mainCamera.SetActive(false);
        ballCamera.SetActive(true);
    }

    private void Goal()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //next level
    }
}
