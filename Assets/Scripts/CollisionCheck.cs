using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public bool collisionCheck;
    
    public void OnCollisionEnter(Collision other)
    {
        if (gameObject == StackManager.instance.cubes[^1] && (other.gameObject.layer == 7 || other.gameObject.layer == 11))
        {
            GameManager.instance.EndGame();
        }

        if (other.gameObject.layer==9 && gameObject.layer==8)
        {
            StackManager.instance.PickUp(other.gameObject);
            StackManager.instance.AddList(other.gameObject);
            
        }else if (other.gameObject.layer==7||other.gameObject.layer==11) // 7 => Obstacle  11 => Lava
        {
            collisionCheck = true;

            if (StackManager.instance.cubes.Count > 1 && other.gameObject.layer == 7)
                StackManager.instance.Destroying(other.gameObject);
            
            
            else if (StackManager.instance.cubes.Count>1&&other.gameObject.layer==11)
            {
                Destroy(gameObject);
                StackManager.instance.DeleteFromList(gameObject);
            }
        }
        else if (other.gameObject.layer==14)
        {
            GameManager.instance.wonGame = true;
        }
    }
}
