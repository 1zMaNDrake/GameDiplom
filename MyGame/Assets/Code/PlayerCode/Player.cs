using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerPhysics : MonoBehaviour
{

    [SerializeField]
    private Image _DashBarForegroundImage;


    private Rigidbody2D rb;

    public float speed;
    private static float AngleX;
    private static float AngleY;

    [Header("DashSettings")]
    [SerializeField] private bool canDash = true;
    [SerializeField] private bool isDashing;
    [SerializeField] private float dashingPower = 25f;
    [SerializeField] private float dashingTime = 0.5f;
    [SerializeField] private float dashingCooldown = 5f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AngleX = 1f; 
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
        if (Input.GetMouseButtonDown(1) &&  AngleY != -1f)
        {
            AngleY = -1f;
        }
       
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        Trajectory();
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

    private void Trajectory()
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
