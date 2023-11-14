using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform transformPlayer;
    public Vector3 offset;
    [SerializeField] private float speedChangePositionCam;
    void Start()
    {
        speedChangePositionCam = 5f;
    }

    void FixedUpdate()
    {
        Vector3 newCamPosition = new Vector3(offset.x, transformPlayer.position.y + offset.y, transformPlayer.position.z + offset.z);
        transform.position = Vector3.Lerp(transform.position, newCamPosition, speedChangePositionCam * Time.deltaTime);
    }
}
