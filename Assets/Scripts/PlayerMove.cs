using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Range(-5f, 5f)] public float clamp = 5f;
    [Range(0, 10)] public float speed = 1.5f;
    private float _lastPosition;
    void Update()
    {
        Swerve();
    }

    private void Swerve()
    {
        if (Input.GetMouseButtonDown(0))
            _lastPosition = Input.mousePosition.x;
            
        if (Input.GetMouseButton(0))
        {
            if (_lastPosition==0)
                _lastPosition = Input.mousePosition.x;
            var delta = Input.mousePosition.x - _lastPosition;
            var target = delta * speed * Time.deltaTime;
            var desired = transform.position + (Vector3.right * target);
            
            desired.x=Mathf.Clamp(desired.x,-clamp,clamp);
            transform.position = desired;
            _lastPosition = Input.mousePosition.x;
        }
    }

}
