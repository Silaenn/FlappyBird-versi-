using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeController : MonoBehaviour
{
    // Start is called before the first frame update
    public float pipeSpeed;
    public float destroyXPos = -6f;
    void Update()
    {
        if(transform.position.x < destroyXPos){
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * pipeSpeed * Time.deltaTime);
    }
}
