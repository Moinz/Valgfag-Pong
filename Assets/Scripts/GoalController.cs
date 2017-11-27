using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public string PaddleName;
	
	void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            Destroy(col.gameObject);
            GameManager.Instance.ScorePoint(PaddleName);
        }
	}
}
