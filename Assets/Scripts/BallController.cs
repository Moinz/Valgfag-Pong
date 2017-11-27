using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float Force;

    [Range(0, 1)]
    public float Bias = .5f;

    public Transform PlayerTransform;

    public Material LeftMaterial;
    public Material RightMaterial;

    private TrailRenderer _trailRenderer;
    private Rigidbody _rigidbody;
    private Vector3 _lastFrameVelocity;
    private void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(Random.insideUnitSphere * (Force * 2), ForceMode.Impulse);
    }

    private void Update()
    {
        _lastFrameVelocity = _rigidbody.velocity;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag("Enemy"))
        {
            BiasBounce(col.contacts[0].normal);
            _trailRenderer.material = RightMaterial;
        }
        else if (col.transform.CompareTag("Player"))
        {
            _trailRenderer.material = LeftMaterial;
            Bounce(col.contacts[0].normal);
        }
        else
        {
            Bounce(col.contacts[0].normal);
        }
    }

    private void Bounce(Vector3 collisionNormal)
    {
        var speed = _lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(_lastFrameVelocity.normalized, collisionNormal);

        speed = Mathf.Max(speed, Force);
        speed = Mathf.Min(speed, Force * 4);
        _rigidbody.velocity = direction * speed;
    }

    private void BiasBounce(Vector3 collisionNormal)
    {
        var speed = _lastFrameVelocity.magnitude;
        var bounceDirection = Vector3.Reflect(_lastFrameVelocity.normalized, collisionNormal);
        var directionToPlayer = PlayerTransform.position - transform.position;

        var direction = Vector3.Lerp(bounceDirection, directionToPlayer, Bias);

        speed = Mathf.Max(speed, Force);
        speed = Mathf.Min(speed, Force * 2);
        _rigidbody.velocity = direction * speed;
    }
}
