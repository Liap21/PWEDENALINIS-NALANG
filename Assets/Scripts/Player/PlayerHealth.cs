using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : Singleton<PlayerHealth>, IDataPersistence
{
    public bool isDead { get; private set; }

    [SerializeField] public int maxHealth = 3;
    [SerializeField] private float knockBackThrustAmount = 10f;
    [SerializeField] private float damageRecoveryTime = 1f;

    [SerializeField] public int currentHealth; // Serialized field for player's current health

    private Slider healthSlider;
    public int deathCount = 0;
    private bool canTakeDamage = true;
    private Knockback knockback;
    private Flash flash;

    public static PlayerController playerControllerData { get; private set; }
    const string TOWN_TEXT = "Overhaul_Scene1";
    readonly int DEATH_HASH = Animator.StringToHash("Death");

    protected override void Awake()
    {
        base.Awake();

        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();

        healthSlider = GameObject.FindWithTag("HealthSlider").GetComponent<Slider>();
        UpdateHealthSlider();
    }

    private void Start()
    {
        isDead = false;
        currentHealth = maxHealth;

        healthSlider = GameObject.FindWithTag("HealthSlider").GetComponent<Slider>();
        UpdateHealthSlider();
    }

    public void LoadData(GameData data)
    {
        this.maxHealth = data.maxHealth;
        this.deathCount = data.deathCount;

        // Health Slider
        this.healthSlider.value = (float)data.currentHealth / data.maxHealth;
        UpdateHealthSlider();
    }

    public void SaveData(ref GameData data)
    {
        data.currentHealth = this.currentHealth; // Update currentHealth with the current value
        data.deathCount = this.deathCount;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyAi enemy = other.gameObject.GetComponent<EnemyAi>();

        if (enemy) {
            TakeDamage(1, other.transform);
        }
    }

    public void HealPlayer()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += 1;
            UpdateHealthSlider();
        }
    }



   public void TakeDamage(int damageAmount, Transform hitTransform) {
    if (!canTakeDamage) { 
        Debug.Log("Cannot take damage due to recovery period.");
        return; 
    }
    

    // Set to false to avoid taking further damage during recovery time
    canTakeDamage = false;

    

    // Apply knockback and visual effects
    knockback.GetKnockedBack(hitTransform, knockBackThrustAmount);
    StartCoroutine(flash.FlashRoutine());

    // Reduce the player's health
    currentHealth -= damageAmount;

    // Update health UI and check if the player is dead
    UpdateHealthSlider();
    CheckIfPlayerDeath();
    
    // Start the damage recovery coroutine to reset `canTakeDamage`
    StartCoroutine(DamageRecoveryRoutine());
    

    Debug.Log("Player took damage. Current Health: " + currentHealth);
}

    private void CheckIfPlayerDeath()
    {
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Destroy(ActiveWeapon.Instance.gameObject);
            currentHealth = 0;
            deathCount++;
            GetComponent<Animator>().SetTrigger(DEATH_HASH);
            StartCoroutine(DeathLoadSceneRoutine());
        }
    }

    private IEnumerator DeathLoadSceneRoutine()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        SceneManager.LoadScene(TOWN_TEXT);
    }

    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }

    private void UpdateHealthSlider()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }
}
