using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnTime;
    public float yPosMin, yPosMax;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPipeCoroutine());
    }


   IEnumerator SpawnPipeCoroutine(){
    while(true){
    yield return new WaitForSeconds(spawnTime);
    Instantiate(pipe, transform.position + Vector3.up * Random.Range(yPosMin, yPosMax), Quaternion.identity);
   }
   }
}
