using UnityEngine;

public class PlayerController : MonoBehaviour, IHurtable
{
    public float angle;
    public float rotspeed = 10f;
    private Vector3 moveInput;
    private float input;
    public Shooting shooting;

    public int maxHealthPoints;
    public int currentHealthPoints;

    private void Start()
    {
        shooting = GetComponent<Shooting>();
        currentHealthPoints = maxHealthPoints;
    }

    void Update ()
    {
        
        if(Input.GetAxisRaw("Horizontal") != 0 )
        {
            input = Input.GetAxisRaw("Horizontal");
            moveInput = new Vector3(input, 0, 0);
            //Debug.Log("H");
            move();
            transform.rotation = new Quaternion(0, 0, -Mathf.Sign(input) * 90, 90);
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            input = Input.GetAxisRaw("Vertical");
            moveInput = new Vector3(0, input, 0);
            //Debug.Log("V");
            move();
            transform.rotation = new Quaternion(0, 0, -Mathf.Sign(input) * 90 + 90, 0);
        }

        
        {
            if (Input.GetButtonDown("Fire1"))
            {
                shooting.shoot();
            }
        }
    }           

    private void move()
    {
        Vector3 moveVelocity = moveInput * GameSpace.GameManager.instance.playerSpeed * Time.deltaTime;
        transform.position += moveVelocity;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        currentHealthPoints -= damage;
    }

    public int GetCurrentHealthPoints()
    {
        return currentHealthPoints;
    }
}
