using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{



    public GameObject enemyFollower;
    public GameObject stillObstacle;
    public Transform[] followerPositions;
    public Transform[] stillPostions;
    Vector3 rightDown;
    Vector3 leftUp;
    Vector3 spawnPosition;
    float timerWaiting;
    int index;
    Vector3 offset = new Vector3(0, 0, 20);

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        GetTimer();
        yield return new WaitForSeconds(timerWaiting);
        while (true)
        {
            GetPositionIndex();
            Instantiate(stillObstacle, stillPostions[index].transform.position + offset, stillPostions[index].transform.rotation);
            GetTimer();
            yield return new WaitForSeconds(timerWaiting);
            Instantiate(enemyFollower, followerPositions[index].transform.position + offset, followerPositions[index].transform.rotation);
            GetTimer();
            yield return new WaitForSeconds(timerWaiting);
            
        }
    }

    void GetPositionIndex() {
        index = Random.Range(0, 5);
    }

    void GetTimer() {
        timerWaiting = Random.Range(1, 2);
    }

}




