using UnityEngine;

public class EnnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    private Transform target;
    private int desPoints = 0;

    public SpriteRenderer graphics;
    public int coinsToRemove;

    public int damageOnCollision = 20;

    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); 

        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            desPoints= (desPoints + 1) % waypoints.Length;
            target = waypoints[desPoints];
            graphics.flipX = !graphics.flipX;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))

        {
            Inventory.instance.RemoveCoins(coinsToRemove);
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}
