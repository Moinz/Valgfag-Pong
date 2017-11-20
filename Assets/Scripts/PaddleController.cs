using UnityEngine;

[RequireComponent( typeof (Rigidbody) )]
public class PaddleController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float Speed;
	// Use this for initialization
	void Start ()
    {
        _rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float yVelocity = Input.GetAxis("Vertical") * Speed;
        _rigidbody.velocity = new Vector3(0, yVelocity, 0);
	}
}
