using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   private PlayerController playerController;
   
   public GameObject obstaclePrefab;
   private Vector3 spawnPos=new Vector3(21,0,0);
   private float startDelay = 0.5f;
   private float repeatRate = 1f;


   private void Start()
   {
      playerController = GameObject.Find("Player").GetComponent<PlayerController>();
      InvokeRepeating("SpawnObstacle",startDelay,repeatRate);
   }


   public void SpawnObstacle()
   {
      if (!playerController.gameOver)
      {
         Instantiate(obstaclePrefab, spawnPos, transform.rotation);
      }
   }
}
