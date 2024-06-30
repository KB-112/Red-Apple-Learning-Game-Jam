using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New HealthBar", menuName = "Custom/HealthBar")]
public class HealthBar : ScriptableObject
{
    [Header("Health Settings")]
    public float initialHealth = 10f;
    public float damagePerHit = 1f;
    public float damagePerSecond = 1f;

    [Header("Components")]
    public Image healthFillImage; // Reference to the health fill Image
    public Color healthyColor = Color.green; // Color when health is high
    public Color damagedColor = Color.red; // Color when taking damage

    private float currentHealth;
    private float damageTimer;

    // Initialization method
    public void Initialize()
    {
        
        currentHealth = initialHealth;

        UpdateHealthBar();
    }

    // Method to update the visual representation of the health bar
    private void UpdateHealthBar()
    {
        float fillAmount = currentHealth / initialHealth;
        healthFillImage.fillAmount = fillAmount;

        // Interpolate color based on health
        healthFillImage.color = Color.Lerp(damagedColor, healthyColor, fillAmount);
    }

    // Method to handle damage
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, initialHealth);

        UpdateHealthBar();

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    // Continuous damage method (called every frame)
    private void ApplyContinuousDamage()
    {
        damageTimer += Time.deltaTime;
        if (damageTimer >= 1f)
        {
            TakeDamage(damagePerSecond);
            damageTimer = 0f;
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DamageDealer"))
        {
            TakeDamage(damagePerHit);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DamageDealer"))
        {
            ApplyContinuousDamage();
        }
    }
}
