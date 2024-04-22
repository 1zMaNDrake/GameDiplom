using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerPhysics : MonoBehaviour
{

    [SerializeField]
    private Image _DashBarForegroundImage;

    private Rigidbody2D rb;

    [SerializeField] private float speed;
    private static float AngleX;
    private static float AngleY;


    private bool canDash = true;
    private bool isDashing;
    [Header("DashSettings")]
    [SerializeField] private float dashingPower;
    [SerializeField] private float dashingTime = 0.5f;
    [SerializeField] private float dashingCooldown = 5f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Trajectory();
    }

    private void Update()
    {
        if (isDashing)
        {
            return;
        }
        if (canDash == false)
        {
            if (_DashBarForegroundImage.fillAmount <= 1)
                _DashBarForegroundImage.fillAmount += 1 / dashingCooldown * Time.deltaTime;
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

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        Movement();
    }


    public UnityEvent OnDash;
    private IEnumerator Dash()
    {
        OnDash.Invoke();
        _DashBarForegroundImage.fillAmount = 0;
        canDash = false;
        isDashing = true;

        AngleY = 0f;
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
