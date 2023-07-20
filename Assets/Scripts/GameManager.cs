using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject platform;

    [Space] [Header("Plane Rotation Setting")] [Space] 
    [SerializeField] private float angle;
    public bool startedGame,wonGame,endGame,isRotate;

    private void Awake()
    {
        instance = this;
    }
    

    public void EndGame()
    {
        endGame = true;
        Time.timeScale = 0;
    }

    public void WinGame()
    { 
        Time.timeScale = 0;
    }
    
    private void Update()
    {
        platform = GameObject.FindWithTag("Level");
        
        if (Input.GetMouseButtonDown(0))
            startedGame = true;
        
        if (wonGame)
            WinGame();
        
    }
    
    public void RotateMaps(float targetAngle,Transform center)
    {
        isRotate = true;
         DOTween.To(x => angle = x, angle, targetAngle, 1f)
         .OnUpdate(()=> platform.transform.RotateAround(center.transform.position, new Vector3(0, 1f, 0), targetAngle*Time.deltaTime)).OnComplete(()=>isRotate=false);
    }
 
}
