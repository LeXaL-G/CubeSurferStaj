using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public static StackManager instance;
    public List<GameObject> cubes;
    [SerializeField] private GameObject platform;
    [SerializeField] private float distanceBetweenObject;
    [SerializeField] private Transform player,playerOne;
    [SerializeField] private GameObject firstCube;
    [SerializeField]public bool gameOver;
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cubes = new List<GameObject>();
        AddList(firstCube);
        distanceBetweenObject = firstCube.transform.localScale.y;
    }

    private void Update()
    {
        platform = GameObject.FindWithTag("Level");
    }

    public void NextPlatform()
    {
        for (int i = cubes.Count-1; i >= 1  ; i--)
        {
            Destroy(cubes[i]);
            DeleteFromList(cubes[i]);
        }
    }

    public void PickUp(GameObject pickedObject)
    {
        pickedObject.transform.parent = player;

        var desPos = cubes[^1].transform.localPosition;
        desPos.y += distanceBetweenObject;

        var playerOneLocalPosition = playerOne.localPosition;
        playerOneLocalPosition.y += distanceBetweenObject;
        
        pickedObject.transform.localPosition = desPos;
        playerOne.localPosition = playerOneLocalPosition;
        
        pickedObject.layer = 8;//inStack
    }

    public void Destroying(GameObject obstacle)
    {
        for (int i = 0; i < cubes.Count-1; i++)
        {
            if (cubes[i].GetComponent<CollisionCheck>().collisionCheck)
            {
                if (obstacle.layer==11)
                {
                    cubes[i].layer = 9; //outStack
                    Destroy(cubes[i]);
                }
                else
                {
                    cubes[i].layer = 9; //outStack
                    cubes[i].transform.parent = platform.transform;
                }
                
                DeleteFromList(cubes[i]);
                i = -1;
            }
        }

        if (obstacle.transform.parent.gameObject.layer != 13)
            LineManager.instance.ObstacleLock(obstacle.transform.parent.gameObject);
        else
            obstacle.transform.gameObject.layer = 10;


    }
    
    public void AddList(GameObject pickedObject)
    {
        cubes.Add(pickedObject);
    }

    public void DeleteFromList(GameObject pickedObject)
    {
        cubes.Remove(pickedObject);
    }
    
}
