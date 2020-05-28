using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props : MonoBehaviour
{
   private void OnCollisionEnter(Collision collisionInfo)
   {
       StartCoroutine(GameObject.Find("GameManager").GetComponent<GameManager>().GameOverLose());
       Destroy(collisionInfo.gameObject);
   }
}
