using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController playerController;
    public float speed = 10f;
    private float leftBound = -3;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void Update()
    {
        if (!playerController.gameOver)
        {
            transform.Translate(Vector3.left*Time.deltaTime*speed);
        }

        if (transform.position.x<leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
