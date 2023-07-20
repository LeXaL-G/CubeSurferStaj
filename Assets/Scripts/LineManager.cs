using UnityEngine;

public class LineManager : MonoBehaviour
{
    public static LineManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void ObstacleLock(GameObject parent)
    {
        for (int i = 0; i <= parent.transform.childCount-1; i++)
        {
            parent.transform.GetChild(i).gameObject.layer = 10;
        }
    }
}
