using UnityEngine;

public class Ladder : MonoBehaviour
{
    public bool isInRange;

    public MovePlayer movePlayer;

    void Awake()
    {
        movePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<MovePlayer>();
    }

    void Update () 
    { 
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            movePlayer.isClimbing = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            movePlayer.isClimbing = false;
        }
    }
}
