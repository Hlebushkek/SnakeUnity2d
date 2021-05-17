using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovementScript : MonoBehaviour
{
    [SerializeField] private int x, y;
    [SerializeField] private float startSpeed;
    [SerializeField] private GameObject BodyBlock;
    [SerializeField] private GameObject SnakeBody;
    [SerializeField] private GameObject ScoreObj;
    [SerializeField] public List<GameObject> SnakeBodyBlocks = new List<GameObject>();
    private Vector3 tempCoordOfLastBlock;
    private float time;
    private float speed;
    private KeyCode currentKey = 0;
    private void Start()
    {
        Restart();
    }
    private void Update()
    {
        ChangeDirection();
    }
    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        if (time > speed)
        {
            Move();
            time = 0f;
        }
    }
    private void Move()
    {
        tempCoordOfLastBlock = this.transform.position;
        if (SnakeBodyBlocks.Count != 0)
        {
            tempCoordOfLastBlock = SnakeBodyBlocks[SnakeBodyBlocks.Count - 1].transform.position;
            for (int i = SnakeBodyBlocks.Count - 1; i >=0 ; i--)
            {
                if (i == 0) SnakeBodyBlocks[i].transform.position = this.transform.position;
                else SnakeBodyBlocks[i].transform.position = SnakeBodyBlocks[i-1].transform.position;
            }
        }
        this.transform.position += new Vector3Int(x, y, 0);
    }
    private void ChangeDirection()
    {
        if (Input.GetKey(KeyCode.W) && currentKey != KeyCode.S)
        {
            currentKey = KeyCode.W;
            x = 0; y = 1;
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.S) && currentKey != KeyCode.W)
        {
            currentKey = KeyCode.S;
            x = 0; y = -1;
            this.transform.eulerAngles = new Vector3(0, 0, 180);
        }
        if (Input.GetKey(KeyCode.A) && currentKey != KeyCode.D)
        {
            currentKey = KeyCode.A;
            x = -1; y = 0;
            this.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.D) && currentKey != KeyCode.A)
        {
            currentKey = KeyCode.D;
            x = 1; y = 0;
            this.transform.eulerAngles = new Vector3(0, 0, -90);
        }
    }
    public void AddBodyBlock()
    {
        var obj = Instantiate(BodyBlock, new Vector2(), Quaternion.identity);
        obj.transform.SetParent(SnakeBody.transform);
        obj.transform.position = tempCoordOfLastBlock;
        SnakeBodyBlocks.Add(obj);
        speed = speed - (0.1f * Mathf.Pow(SnakeBodyBlocks.Count + 1, -8f/9f));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fruit")
        {
            other.GetComponent<FruitScript>().GeneratePosition();
            ScoreObj.GetComponent<ScoreScript>().UpdateScoreText(1);
            AddBodyBlock();
        }
    }
    public void Restart()
    {
        time = 0f;
        if (SnakeBodyBlocks.Count > 0)
        {
            for (int i = 0; i < SnakeBodyBlocks.Count; i++)
                Destroy(SnakeBodyBlocks[i]);
            
            SnakeBodyBlocks.Clear();
        }
        this.transform.position = new Vector3Int(0, 0, -2);
        ScoreObj.GetComponent<ScoreScript>().RestartScore();
        speed = startSpeed;
    }
}
