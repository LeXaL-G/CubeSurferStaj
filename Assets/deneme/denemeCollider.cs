using UnityEngine;

public class denemeCollider : MonoBehaviour
{

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 9 && gameObject.layer == 8)
        {
            denemeStack.instance.PickUp(other.gameObject);
            denemeStack.instance.AddList(other.gameObject);

        }
        else if (other.gameObject.layer == 7 || other.gameObject.layer == 11) // 7 => Obstacle  11 => Lava
        {

            if (denemeStack.instance.cubes.Count > 1 && other.gameObject.layer == 7)
                denemeStack.instance.Destroying(other.gameObject);

            else if (denemeStack.instance.cubes.Count > 1 && other.gameObject.layer == 11)
            {
                Destroy(gameObject);
                denemeStack.instance.DeleteFromList(gameObject);
            }
        }
    }
}
