using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
   
    public int maxHealth = 100;

    public int currentHealth;

    public HealthBar healthBar;

    public bool isInvincible = false;

    public SpriteRenderer graphics;

    public float invincibiltyFlashDelay = 0.15f;

    public float invincibilityTimeAfterHit = 2f;

    public static PlayerHealth instance;

    public AudioClip hitSound;

    public AudioClip deathSound;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance PlayerHealth dans la sc�ne");
            return;
        }

        instance = this;

    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(0);
        }
        
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void HealPlayer(int heal)  
    {
        if ((currentHealth + heal) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else 
        {
            currentHealth += heal;
        }
            healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)  // Ajoutez "public" devant
    {
        if (!isInvincible)
        {
            AudioManager.instance.PlayClipAt(hitSound,transform.position);
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if(currentHealth <= 0)
            {
                AudioManager.instance.PlayClipAt(deathSound, transform.position);
                Die();
                return;
            }

            isInvincible = true;
            StartCoroutine(InvincibiltyFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public void Die()
    {
        MovePlayer.instance.enabled = false;
        MovePlayer.instance.animator.SetTrigger("Die");
        MovePlayer.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        MovePlayer.instance.rb.linearVelocity = Vector3.zero;
        MovePlayer.instance.playerCollider.enabled = false;
        GameOverManagement.instance.OnPlayerDeath();

    }

    public void Respawn()
    {
        MovePlayer.instance.enabled = true;
        MovePlayer.instance.animator.SetTrigger("Respawn");
        MovePlayer.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        MovePlayer.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    public IEnumerator InvincibiltyFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibiltyFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibiltyFlashDelay);

        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        while (isInvincible)
        {
            yield return new WaitForSeconds(invincibilityTimeAfterHit);
            isInvincible = false;

        }
    }
}
