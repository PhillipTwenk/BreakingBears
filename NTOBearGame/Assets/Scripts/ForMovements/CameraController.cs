using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Animator CameraAnimator;
    public Animator FadeAnimator;
    private Vector3 LabPositionCamera;
    private Vector3 StartGamePositionCamera;
    public Transform transformPlayer;
    public Vector3 offset;
    [SerializeField] private float speedChangePositionCam;
    void Start()
    {
        LabPositionCamera = new Vector3(15.3f, 5.7f, 14.4f);
        StartGamePositionCamera = new Vector3(14.51f, 13.39f, 105.78f);
        transform.position = StartGamePositionCamera;
        speedChangePositionCam = 5f;
    }

    void FixedUpdate()
    {
        if(StaticStorage.IsInZone == true)
        {
            Vector3 newCamPosition = new Vector3(transformPlayer.position.x + offset.x, transformPlayer.position.y + offset.y, transformPlayer.position.z + offset.z);
            transform.position = Vector3.Lerp(transform.position, newCamPosition, speedChangePositionCam * Time.deltaTime);
        }
        if (StaticStorage.IsInLab == true)
        {
            gameObject.transform.position = LabPositionCamera;
        }
    }

    public void StartFadeAnimation(){
        FadeAnimator.SetTrigger("StartFadeAnimationTrigger");
    }

    public void StartCameraMovement(){
        CameraAnimator.SetTrigger("StartCameraAnimationTrigger");
    }
}
