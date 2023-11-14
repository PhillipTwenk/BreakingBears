using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    private Rigidbody rbCharacter;
    private Animator CharacterAnimator;
    [SerializeField]private float speed;
    [SerializeField]private float speedRotation;
    private void Start()
    {
        //Get Component
        rbCharacter = GetComponent<Rigidbody>();
        CharacterAnimator = GetComponent<Animator>();

        speed = 4f;
        speedRotation = 10f;
    }
    private void FixedUpdate()
    {
        //Get Axis Input
        float hz = Input.GetAxis("Horizontal");
        float vt = Input.GetAxis("Vertical");

        //Direction Vector3
        Vector3 vectorOrientation = new Vector3(hz, 0, vt);

        if(vectorOrientation.magnitude > Mathf.Abs(0.05f))
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(vectorOrientation), Time.deltaTime * speedRotation);

        CharacterAnimator.SetFloat("speedMove", Vector3.ClampMagnitude(vectorOrientation, 1).magnitude);
        
        rbCharacter.velocity = Vector3.ClampMagnitude(vectorOrientation, 1) * speed;
        
        rbCharacter.angularVelocity = Vector3.zero;
    }
}
