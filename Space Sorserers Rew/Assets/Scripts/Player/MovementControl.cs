using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MovementControl : MonoBehaviour
{
    [SerializeField] protected Rigidbody body;
    [SerializeField] protected float speed;
    protected Vector3 direct;

    void Update()
    {
        direct.x = Input.GetAxis("Horizontal");
        direct.z = Input.GetAxis("Vertical");
        
        
        Move(direct.normalized);
        
    }

    private void Move(Vector3 direct)
    {
        body.velocity = direct * speed;
    }
}
