using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isStartPlatform = false;
    public Collider collider;
    bool CheckCollision = true;
    public GameManager manager;
  

    private void OnTriggerStay(Collider other)
    {
        if(isStartPlatform) return;
        
        if(Mathf.Abs(collider.bounds.center.x - other.gameObject.GetComponent<Collider>().bounds.center.x) <= collider.bounds.extents.x - other.gameObject.GetComponent<Collider>().bounds.extents.x && CheckCollision)
        {
            CheckCollision = false;
            
            StartCoroutine(manager.GameOverWin());
        }
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.relativeVelocity.magnitude> 2.0f && CheckCollision){
            Destroy(collisionInfo.gameObject);
            StartCoroutine(manager.GameOverLose());
        }
    }

}
