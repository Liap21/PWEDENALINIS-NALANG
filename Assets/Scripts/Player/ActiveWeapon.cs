using UnityEngine;
using System.Collections;

public class ActiveWeapon : Singleton<ActiveWeapon>
{
    public MonoBehaviour CurrentActiveWeapon { get; private set; }

    private PlayerControls playerControls;

    private bool isAttacking = false;

    private float timeBetweenAttacks;

    protected override void Awake()
    {
        base.Awake();
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Start()
    {
        playerControls.Combat.Attack.started += _ => StartAttacking();
        playerControls.Combat.Attack.canceled += _ => StopAttacking();

        AttackCooldown();
    }

    private void Update()
    {
        // Attack logic handled by input event, no need for Update
    }

    public void NewWeapon(MonoBehaviour newWeapon)
    {
        CurrentActiveWeapon = newWeapon;

        AttackCooldown();
        timeBetweenAttacks = (CurrentActiveWeapon as IWeapon).GetWeaponInfo().weaponCooldown;
    }

    public void WeaponNull()
    {
        CurrentActiveWeapon = null;
    }

    private void AttackCooldown()
    {
        isAttacking = true;
        StopAllCoroutines();
        StartCoroutine(TimeBetweenAttacksRoutine());
    }

    private IEnumerator TimeBetweenAttacksRoutine()
    {
            yield return new WaitForSeconds(timeBetweenAttacks);
        isAttacking = false;
    }

    public void StartAttacking()
    {
        if (!isAttacking)
        {
            isAttacking = true; 
            if (CurrentActiveWeapon != null)
            {
                AttackCooldown();
                (CurrentActiveWeapon as IWeapon)?.Attack();
            }
        }
    }

    private void StopAttacking()
    {
        isAttacking = false;
    }
}