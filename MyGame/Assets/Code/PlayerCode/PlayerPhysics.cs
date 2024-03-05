using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerPhysics : MonoBehaviour
{

    [SerializeField]
    private Image _DashBarForegroundImage;


    Rigidbody2D rb;

    public float speed;
    public static float AngleX;
    public static float AngleY;

    public bool canDash = true;
    private bool isDashing;
    private float dashingPower = 25f;
    private float dashingTime = 0.5f;
    public  float dashingCooldown = 5f;


    private void Awake()
    {
        Trajectory();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AngleX = 1f; 
    }

    void Update()
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
        if (Input.GetMouseButtonDown(0))
        {
            AngleY = 1f;
        }
        if (Input.GetMouseButtonDown(1))
        {
            AngleY = -1f;
        }
       
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        Trajectory();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
    }

    public UnityEvent OnDash;


    private IEnumerator Dash()
    {
        OnDash.Invoke();
        _DashBarForegroundImage.fillAmount = 0;
        canDash = false;
        isDashing = true;

        AngleY = 0f;
        rb.velocity = new Vector2(AngleX, 0) * dashingPower;

        yield return new WaitForSeconds(dashingTime);
        rb.velocity = new Vector2(AngleX, 0);

        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    public void Trajectory()
    {    
        transform.Translate(new Vector3(AngleX, AngleY, 0) * speed * Time.deltaTime, Space.World);
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
