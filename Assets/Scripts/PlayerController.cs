using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

public class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    public Transform playerTransform;
    //public Rigidbody rb;
    public Animator playerAni;
    public CharacterController player;
    public GameObject playerSpine;
    private float spineRotationX = 0.0f;
    private float spineRotationY = 0.0f;
    private float spineRotationZ = 0.0f;


    [Header("Player Camera Components")]
    public Transform playerCamera;
    private float cameraRotationX = 0.0f;
    private float cameraRotationY = 0.0f;


    [Header("Mobile Input")]
    public float joySpeed;  //이동 속도
    public float rotationSpeed = 0.0001f; // 회전 속도
    public FloatingJoystick floatingJoystick;


    void Start()
    {
        playerTransform = gameObject.GetComponent<Transform>();
        //rb = gameObject.GetComponent<Rigidbody>();
        player = gameObject.GetComponent<CharacterController>();
        playerAni = gameObject.GetComponent<Animator>();
        
    }

    void FixedUpdate()
    {
    #if UNITY_IOS || PLATFORM_IOS
        //플레이어 이동(조이스틱)
        Vector3 direction = playerTransform.forward * floatingJoystick.Vertical + playerTransform.right * floatingJoystick.Horizontal;
        player.Move(direction * joySpeed * Time.deltaTime);
    #endif
    }

    public void RotatePlayer(float rotationInputX, float rotationInputY){
        //플레이어 시점 방향 회전
        playerTransform.Rotate(0f, rotationInputX * rotationSpeed, 0f);

        //시점 - 상체 회전 동기화(y축);
        if(rotationInputY != 0){
            spineRotationZ += rotationInputY * rotationSpeed;
            spineRotationZ = Mathf.Clamp(90f, -90f, spineRotationZ); 
            Debug.Log("this");
            playerSpine.GetComponent<Transform>().localEulerAngles = new Vector3(playerSpine.GetComponent<Transform>().localEulerAngles.x, 0f, spineRotationZ);
        }
    }
    public void RotateCamera(float rotationInputX, float rotationInputY){
        Debug.Log("X: " + rotationInputX + " , Y: " + rotationInputY);

        // 카메라 상하 회전 각도 업데이트 (X 축)
        cameraRotationX -= rotationInputY * rotationSpeed; // Y 입력을 사용해 X 축 회전을 제어
        cameraRotationX = Mathf.Clamp(cameraRotationX, -90f, 90f); // 상하 회전 제한

        // 플레이어 좌우 회전 (Y 축)
        float rotationY = rotationInputX * rotationSpeed;
        playerTransform.Rotate(0f, rotationY, 0f);

        // 카메라의 오일러 각 직접 설정 (X 축만 조정)
        playerCamera.localEulerAngles = new Vector3(cameraRotationX, playerCamera.localEulerAngles.y, 0f);
    }


    void Fire(){
        //사격
    }
}
