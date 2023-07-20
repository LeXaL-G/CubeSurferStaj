using UnityEngine;

namespace CustomPackages.ToonWaterPack.Scripts
{
    public class ObjectFloater : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 1.0f)] private float height = 0.1f;
        [SerializeField, Range(0.1f, 1.0f)] private float period = 1;
        private Vector3 _initialPosition;
        private float _offset;

        private void Awake()
        {
            _initialPosition = transform.position;
            _offset = 1 - (Random.value * 2);
        }

        private void Update()
        {
            transform.position = _initialPosition - Vector3.up * Mathf.Sin((Time.time + _offset) * period) * height;
        }
    }
}
