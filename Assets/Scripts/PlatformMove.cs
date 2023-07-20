using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        if (denemeGameManager.instance.startedGame&&!denemeGameManager.instance.isRotate)
            transform.position+=Vector3.back*Time.deltaTime*speed;
    }
}
