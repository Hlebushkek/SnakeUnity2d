using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCollider : MonoBehaviour
{
    [SerializeField] GameObject snake;
    private void OnTriggerExit2D(Collider2D other)
    {
        snake.GetComponent<EndGame>().EndRound();
    }
}
