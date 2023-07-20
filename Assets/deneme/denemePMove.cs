using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class denemePMove : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        if (GameManager.instance.startedGame&&!GameManager.instance.isRotate)
            transform.position+=Vector3.back*Time.deltaTime*speed;
    }
}
