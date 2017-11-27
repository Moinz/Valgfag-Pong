using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public CameraShake CameraShaker;
    public GameObject BallGameObject;
    public GameObject PlayerGameObject;
    public GameObject EnemyGameObject;

    public Text LeftScore;
    public Text RightScore;

    private int _leftPoints;
    private int _rightPoints;

    private void Start()
    {
        Instance = this;
    }
    public void ScorePoint(string name)
    {
        if (name == "Left")
        {
            CameraShaker.StartShake(.5f);
            _rightPoints++;
            RightScore.text = _rightPoints.ToString();
        }
        else
        {
            CameraShaker.StartShake(.5f);
            _leftPoints++;
            LeftScore.text = _leftPoints.ToString();
        }

        Invoke("RespawnBall", 3f);
    }

    public void RespawnBall()
    {
        var ball = Instantiate(BallGameObject, Vector3.zero, Quaternion.identity);
        ball.GetComponent<BallController>().PlayerTransform = PlayerGameObject.transform;
    }
}
