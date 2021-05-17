using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    [SerializeField] GameObject snake;
    private Vector3 FruitCoord;
    private void Start()
    {
        GeneratePosition();
    }
    public void GeneratePosition()
    {
        bool isGoodCoord = false;
        while (isGoodCoord == false)
        {
            isGoodCoord = true;
            FruitCoord = new Vector3Int(Random.Range(-6, 6), Random.Range(-5, 5), -1);
            if (snake.transform.position == FruitCoord) isGoodCoord = false;
            /*if (bodylist.Count > 0 && isGoodCoord == true)
            {
                for (int i = 0; i < bodylist.Count; i++)
                {
                    if (bodylist[i].transform.position == FruitCoord)
                    {
                        isGoodCoord = false;
                        break;
                    }
                }
            }*/
        }
        this.transform.position = FruitCoord;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("BODYCOLLISIOn");
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "BodyBlock")
        {
            Debug.Log("IN if bodyblockCOLLision");
            GeneratePosition();
        }
    }
}
