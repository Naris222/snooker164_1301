using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;
    public int PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }

    [SerializeField]
    private GameObject[] ballPositions;

    [SerializeField]
    private GameObject ballPrefabs;

    [SerializeField]
    private GameObject cueBall;

    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetBall(BallColor.Red, 1);
        SetBall(BallColor.Yellow, 2);
        SetBall(BallColor.Green, 3);
        SetBall(BallColor.Brown, 4);
        SetBall(BallColor.Blue, 5);
        SetBall(BallColor.Pink, 6);
        SetBall(BallColor.Black, 7);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ShootBall();
        }
    }
    private void SetBall(BallColor col, int index)
    {
        GameObject obj = Instantiate(ballPrefabs, ballPositions[index].transform.position, Quaternion.identity);

        Ball ball = obj.GetComponent<Ball>();
        ball.SetColorAndPoint(col);
    }

    private void ShootBall()
    {
     Rigidbody rb = cueBall.GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse);
    }
}
