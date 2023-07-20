using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            other.gameObject.layer = 0;
            switch (other.gameObject.tag)
            {
                case "Right":
                    GameManager.instance.RotateMaps(-90, other.gameObject.transform);
                    break;
                case "Left":
                    GameManager.instance.RotateMaps(90, other.gameObject.transform);
                    break;
            }
        }
    }
}
