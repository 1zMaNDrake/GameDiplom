using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerPhysics : MonoBehaviour
{
    public int bulletCount = 1;

    [SerializeField] private Image _DashBarForegroundImage;

    private Rigidbody2D rb;

    [SerializeField] private float speed;
    private float AngleX;
    private float AngleY;

    [Header("ShootSettings")]
    public GameObject bullet;
    private float timeBtwShots;
    public float startTimeBtwShots = 0.45f;

    [Header("DashSettings")]
    [SerializeField] private float dashingPower;
    [SerializeField] private float dashingTime = 0.5f;
    [SerializeField] private float dashingCooldown = 5f;

    private bool canDash = true;
    private bool isDashing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Trajectory();
    }

    private void Update()
    {
        if (Time.timeScale != 0f)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + -90f);
        }
        else
        {
            return;
        }

        if (isDashing)
        {
            return;
        }
        if (canDash == false)
        {
            if (_DashBarForegroundImage.fillAmount <= 1)  _DashBarForegroundImage.fillAmount += 1 / dashingCooldown * Time.deltaTime;
            else _DashBarForegroundImage.fillAmount = 1;
        }
        if (Input.GetMouseButtonDown(0) && AngleY != 1f)
        {
            AngleY = 1f;
        }
        if (Input.GetMouseButtonDown(1) && AngleY != -1f)
        {
            AngleY = -1f;
        }

        if (Input.GetKey(KeyCode.C))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        Movement();
    }

    private void Shoot()
    {
        if (timeBtwShots <= 0)
        {
            StartCoroutine(ShotProcces());
            timeBtwShots = startTimeBtwShots;
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private IEnumerator ShotProcces()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            AudioManager.Instance.PlaySFX("Pistol");
            Instantiate(bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.15f);
        }
        
    }

    public UnityEvent OnDash;
    private IEnumerator Dash()
    {
        OnDash.Invoke();
        AudioManager.Instance.PlaySFX("Dash");
        AngleY = 0f;
        _DashBarForegroundImage.fillAmount = 0;
        canDash = false;
        isDashing = true;

        rb.velocity = new Vector2(transform.localPosition.x * dashingPower, 0f);

        yield return new WaitForSeconds(dashingTime);

        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void Trajectory()
    {
        AngleX = Random.value < 0.5f ? -1f : 1f;
        AngleY = Random.value < 0.5f ? -1f : 1f;
    }

    private void Movement()
    {
        Vector2 direction = new Vector2(AngleX, AngleY).normalized;
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wallbasic"))
        {
            AngleY *= -1;
        }
        if (collision.gameObject.CompareTag("Wallliteral"))
        {
            AngleX *= -1;
        }
    }

}
