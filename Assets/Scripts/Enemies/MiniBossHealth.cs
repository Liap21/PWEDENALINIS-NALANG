using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace MiniBossScripts
{
    public class MiniBossHealth : MonoBehaviour
    {
        [SerializeField] private int startingHealth = 3;
        [SerializeField] private GameObject deathVFXPrefab;
        [SerializeField] private float knockBackThrust = 15f;
        [SerializeField] private MiniBossHealthBar healthBar; // Reference to the health bar script

        private int currentHealth;
        private Knockback knockback;
        private Flash flash;
        public UnityEvent UnityEvent;
        private void Awake()
        {
            flash = GetComponent<Flash>();
            knockback = GetComponent<Knockback>();
        }

        private void Start()
        {
            currentHealth = startingHealth;
            if (healthBar != null)
            {
                healthBar.SetMaxHealth(startingHealth);
            }
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (healthBar != null)
            {
                healthBar.SetHealth(currentHealth);
            }
            knockback.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
            StartCoroutine(flash.FlashRoutine());
            StartCoroutine(CheckDetectDeathRoutine());
        }

        private IEnumerator CheckDetectDeathRoutine()
        {
            yield return new WaitForSeconds(flash.GetRestoreMatTime());
            DetectDeath();
        }

        public void DetectDeath()
        {
            if (currentHealth <= 0)
            {
                UnityEvent?.Invoke();
                Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

}
