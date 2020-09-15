using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour
{
    private Rigidbody ball;
    public BallTrajectory ballTrajectory;
    private Vector3 ballDir;
    private int ballPower = 50;
    //private float initBallSpeed;

    private GameObject mainCamera;
    public GameObject ballCamera;
    public GameObject simulationBall;

    public TextMeshProUGUI goalTMP;
    public GameObject nextLevelButton;

    private void Awake()
    {
        ball = GetComponent<Rigidbody>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Start()
    {
        ballTrajectory.copyAllObstacles();
    }

    private void OnMouseDrag()
    {
        ballDir = (this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)).normalized;
        ballTrajectory.predict(simulationBall, this.transform.position, ballDir * ballPower); //simulate the trajectory
    }

    private void OnMouseUp()
    {
        ball.velocity = ballDir * ballPower;

        ChangeCamera();

        ballTrajectory.clearPrediction(); //delete the trajectory
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Goal"))
        {
            Goal();
        }

    }

    private void ChangeCamera()
    {
        mainCamera.SetActive(false);
        ballCamera.SetActive(true);
    }

    private void Goal()
    {
        goalTMP.gameObject.SetActive(true);
        nextLevelButton.SetActive(true);
    }

}
