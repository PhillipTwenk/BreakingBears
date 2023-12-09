using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 LabPositionCamera;
    public Transform transformPlayer;
    public Vector3 offset;
    [SerializeField] private float speedChangePositionCam;
    void Start()
    {
        LabPositionCamera = new Vector3(15.3f, 5.7f, 14.4f);
        transform.position = LabPositionCamera;
        speedChangePositionCam = 5f;
    }

    void FixedUpdate()
    {
        if(StaticStorage.IsInNDzone == true || StaticStorage.IsInDzone == true)
        {
            Vector3 newCamPosition = new Vector3(transformPlayer.position.x + offset.x, transformPlayer.position.y + offset.y, transformPlayer.position.z + offset.z);
            transform.position = Vector3.Lerp(transform.position, newCamPosition, speedChangePositionCam * Time.deltaTime);
        }
    }
}
