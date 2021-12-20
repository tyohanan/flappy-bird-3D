using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMapsObstacle : MonoBehaviour
{
    [SerializeField]
    private GameObject bird;
    [SerializeField]
    private int DistanceValue = 10;
    [SerializeField]
    private int safeDistanceValue = 8;

    public GameObject[] PlatformTop = new GameObject[3];

    private Transform birdPosition;
    private int minDistance;
    private int maxDistance;
    private float height = -1;
    private int fixRotation = -90;
    private int[] rotationDegree = {0};
    public List<GameObject> platformList = new List<GameObject>();
    
    private void Awake() {

    }
    void Start()
    {
        birdPosition = bird.GetComponent<Transform>();
    }

    void Update()
    {
        //randomize platform and rotation
        int getPlatform = Random.Range(0, PlatformTop.Length);
        int randomRotation = Random.Range(0,rotationDegree.Length);
        int posObstacle = Random.Range(0,2);
        int posObstacleDegree = 0;
        Debug.Log(posObstacle);
        if (posObstacle == 0){
            posObstacleDegree = 0;
            height = Random.Range(0.5f, 1f);
        }
        else if (posObstacle == 1){
            posObstacleDegree = 180;
            height = Random.Range(4.5f, 5f);
        }
        //generate platform atas baru saat bird masuk ke safe distance
        int maxSafeDistance = (int) birdPosition.position.x + safeDistanceValue;
        int minSafeDistance = (int) birdPosition.position.x - safeDistanceValue;
        //check distance front
        if (maxSafeDistance >= maxDistance){
            var safePlatform = Instantiate(PlatformTop[getPlatform], new Vector3(maxDistance+2,height,0), Quaternion.Euler(rotationDegree[randomRotation],fixRotation,posObstacleDegree));
            maxDistance = (int)birdPosition.position.x + DistanceValue;
            minDistance = (int)birdPosition.position.x - DistanceValue;
            platformList.Add(safePlatform);
            // Debug.Log(maxDistance +" "+safeDistance+" "+(int)birdPosition.position.x);
        } 
        //check distance back
        else if (minSafeDistance <= minDistance){
            var safePlatform = Instantiate(PlatformTop[getPlatform], new Vector3(minDistance-2,height,0), Quaternion.Euler(rotationDegree[randomRotation],fixRotation,posObstacleDegree));
            maxDistance = (int)birdPosition.position.x + DistanceValue;
            minDistance = (int)birdPosition.position.x - DistanceValue;
            platformList.Add(safePlatform);
        }
        // checking if the platform out of distance then we can destroy it
        for (int x = 0; x < platformList.Count; x++){
            if (platformList[x].transform.position.x < (minDistance-8) || platformList[x].transform.position.x > (maxDistance+8)){
                Destroy(platformList[x]);
                platformList.RemoveAt(x);
            }
        }  
    }
}
