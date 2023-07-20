using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class denemeGameManager : MonoBehaviour
{
    
    public static denemeGameManager instance;
    [SerializeField] private GameObject platform;

    [Space] [Header("Plane Rotation Setting")] [Space] 
    [SerializeField] private float angle;
    public bool startedGame;
    public bool isRotate;


    private void Awake()
    {
        instance = this;
    }
    
    
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
            startedGame = true;
    }


    public void RotateMaps(float targetAngle,Transform center)
    {
        isRotate = true;
         DOTween.To(x => angle = x, angle, targetAngle, 1f)
         .OnUpdate(()=> platform.transform.RotateAround(center.transform.position, new Vector3(0, 1f, 0), targetAngle*Time.deltaTime));
         StartCoroutine(WaitRotate());
    }

    IEnumerator WaitRotate()
    {
        yield return new WaitForSeconds(1f);
        isRotate = false;
    }
}

