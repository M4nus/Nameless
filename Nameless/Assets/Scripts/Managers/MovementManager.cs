using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public float angle;
    public float rotspeed = 10f;

	void Update ()
    {
        //Vector2 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        //Vector3 moveVelocity = moveInput.normalized * GameSpace.GameManager.instance.playerSpeed * Time.deltaTime;
        //transform.Translate(moveVelocity);
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxisRaw("Horizontal") * rotspeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxisRaw("Vertical") * 10 * Time.deltaTime);
        pos += rot * velocity;
        transform.position = pos;

    }           
}
