using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratedMaps : MonoBehaviour
{
    [SerializeField]
    private GameObject bird;

    public GameObject[] PlatformTop = new GameObject[3];

    private Transform birdPosition;
    private int minDistance;
    private int maxDistance;
    private int[] rotationDegree = {0,90,180,270,360};
    public List<GameObject> platformList = new List<GameObject>();
    
    private void Awake() {

    }
    void Start()
    {
        //generate awal saat player masuk
        birdPosition = bird.GetComponent<Transform>();   
        minDistance = (int)birdPosition.position.x -10;
        maxDistance = (int)birdPosition.position.x +10;
        for (int x = minDistance; x <= maxDistance; x+=2){
            int getPlatform = Random.Range(0, PlatformTop.Length);
            int randomRotation = Random.Range(0,rotationDegree.Length);
            var allPlatformTop = Instantiate(PlatformTop[getPlatform], new Vector3(x,6,0), Quaternion.Euler(rotationDegree[randomRotation],90,0));
            platformList.Add(allPlatformTop);
            allPlatformTop.transform.parent = transform;
        }
    }

    void Update()
    {
        //generate platform atas baru saat bird masuk ke safe distance
        int safeDistance = (int)birdPosition.position.x + 8;
        if (safeDistance >= maxDistance){
            var safePlatform = Instantiate(PlatformTop[0], new Vector3(maxDistance+2,6,0), Quaternion.Euler(rotationDegree[0],90,0));
            maxDistance = (int)birdPosition.position.x + 10;
            platformList.Add(safePlatform);
            Destroy(platformList[0]);
            platformList.RemoveAt(0);
            // Debug.Log(maxDistance +" "+safeDistance+" "+(int)birdPosition.position.x);
        } 
        Debug.Log(platformList.Count);
    }
}
