using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public float angle;
    public float rotspeed = 10f;
    private Vector3 moveInput;
    private float input;

	void Update ()
    {
        //Vector2 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        //Vector3 moveVelocity = moveInput.normalized * GameSpace.GameManager.instance.playerSpeed * Time.deltaTime;
        //transform.Translate(moveVelocity);
        /*Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxisRaw("Horizontal") * rotspeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxisRaw("Vertical") * 10 * Time.deltaTime);
        pos += rot * velocity;
        transform.position = pos;*/


        if(Input.GetAxisRaw("Horizontal") != 0 )
        {
            input = Input.GetAxisRaw("Horizontal");
            moveInput = new Vector3(input, 0, 0);
            Debug.Log("H");
            move();
            //transform.rotation = new Quaternion(0, 0, -Mathf.Sign(input) * 90, 90);
        }
        else if (Input.GetAxisRaw("Vertical") != 0)
        {
            input = Input.GetAxisRaw("Vertical");
            moveInput = new Vector3(0, input, 0);
            Debug.Log("V");
            move();
            //transform.rotation = new Quaternion(0, 0, -Mathf.Sign(input) * 90 + 90, 0);
        }
        
        
        


    }           

    private void move()
    {
        Vector3 moveVelocity = moveInput * GameSpace.GameManager.instance.playerSpeed * Time.deltaTime;
        transform.position += moveVelocity;
    }
}
