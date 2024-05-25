using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Singleton<PlayerController>, IDataPersistence
{
    public bool FacingLeft { get { return facingLeft; } }


    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float dashSpeed = 4f;
    [SerializeField] private TrailRenderer myTrailRenderer;

    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private GameObject staffPrefab;
    [SerializeField] private GameObject bowPrefab;


    public FixedJoystick joystick;
    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;
    private Knockback knockback;

    private bool facingLeft = false;
    private bool isDashing = false;
    private float startingMoveSpeed;

    private bool attackButtonDown = false;
    private bool isAttacking = false;

    private Vector2 lastinput;
    public bool isFlip
    {
        get
        {
            if (mySpriteRender != null)
                return mySpriteRender.flipX;
            else
                return false; // Return a default value if mySpriteRender is not initialized
        }
    }

    protected override void Awake()
    {
        base.Awake();

        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>(); // Assign SpriteRenderer here
        knockback = GetComponent<Knockback>();
    }

    private void Start()
    {
        playerControls.Combat.Dash.performed += _ => Dash();
        playerControls.Combat.Attack.started += _ => StartAttacking();
        playerControls.Combat.Attack.canceled += _ => StopAttacking();

        startingMoveSpeed = moveSpeed;

        ActiveInventory.Instance.EquipStartingWeapon();
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosX = transform.position.x;
        data.playerPosY = transform.position.y;
    }

    public void LoadData(GameData data)
    {
        transform.position = new Vector3(data.playerPosX, data.playerPosY);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    public void OnDisable()
    {
        playerControls.Disable();
    }


    private void SwitchToSword()
    {
        if (ActiveWeapon.Instance.CurrentActiveWeapon != null)
            Destroy(ActiveWeapon.Instance.CurrentActiveWeapon.gameObject); // Destroy the current weapon if exists

        GameObject sword = Instantiate(swordPrefab, transform.position, Quaternion.identity);
        ActiveWeapon.Instance.NewWeapon(sword.GetComponent<MonoBehaviour>());
    }

    private void SwitchToStaff()
    {
        if (ActiveWeapon.Instance.CurrentActiveWeapon != null)
            Destroy(ActiveWeapon.Instance.CurrentActiveWeapon.gameObject); // Destroy the current weapon if exists

        GameObject staff = Instantiate(staffPrefab, transform.position, Quaternion.identity);
        ActiveWeapon.Instance.NewWeapon(staff.GetComponent<MonoBehaviour>());
    }

    private void SwitchToBow()
    {
        if (ActiveWeapon.Instance.CurrentActiveWeapon != null)
        {
            if (ActiveWeapon.Instance.CurrentActiveWeapon.gameObject.CompareTag("Bow")) // Check if already using bow
                return;

            Destroy(ActiveWeapon.Instance.CurrentActiveWeapon.gameObject); // Destroy the current weapon if exists
        }

        GameObject bow = Instantiate(bowPrefab, transform.position, Quaternion.identity);
        ActiveWeapon.Instance.NewWeapon(bow.GetComponent<MonoBehaviour>());
    }

    private void Update()
    {
        lastinput = (joystick != null) ? joystick.Direction : movement;
        PlayerInput();

        if (Input.GetKeyDown(KeyCode.Alpha1))
            SwitchToSword();

        // Example: Pressing a button to switch to staff
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SwitchToStaff();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            SwitchToBow();
        Attack();
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void StartAttacking()
    {
        attackButtonDown = true;
    }

    private void StopAttacking()
    {
        attackButtonDown = false;
    }

    private void Attack()
    {
        if (attackButtonDown && !isAttacking && ActiveWeapon.Instance.CurrentActiveWeapon != null)
        {
            isAttacking = true;
            (ActiveWeapon.Instance.CurrentActiveWeapon as IWeapon)?.Attack();
        }
    }




    private void PlayerInput()
    {

        myAnimator.SetFloat("MoveX", lastinput.x);
        myAnimator.SetFloat("MoveY", lastinput.y);
    }

    private void Move()
    {
        if (knockback.GettingKnockedBack || PlayerHealth.Instance.isDead)
        {
            return;
        }
        rb.MovePosition(rb.position + lastinput * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()
    {
        if (lastinput.magnitude > 0.1f)
        {
            facingLeft = lastinput.x <= 0;
            if (mySpriteRender != null)
                mySpriteRender.flipX = facingLeft; // Check if mySpriteRender is not null before accessing flipX
        }
    }

    public Vector2 GetLastInput()
    {
        return lastinput;
    }

    private void Dash()
    {
        if (!isDashing)
        {
            isDashing = true;
            moveSpeed *= dashSpeed;
            myTrailRenderer.emitting = true;
            StartCoroutine(EndDashRoutine());
        }
    }

    private IEnumerator EndDashRoutine()
    {
        float dashTime = 0.2f;
        float dashCD = 0.25f;
        yield return new WaitForSeconds(dashTime);
        moveSpeed = startingMoveSpeed;
        myTrailRenderer.emitting = false;
        yield return new WaitForSeconds(dashCD);
        isDashing = false;
    }
}
