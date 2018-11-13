using UnityEngine;

public class MovementManager : MonoBehaviour
{     
	void Update ()
    {
        Vector2 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        Vector3 moveVelocity = moveInput.normalized * GameSpace.GameManager.instance.playerSpeed * Time.deltaTime;
        transform.Translate(moveVelocity);
	}           
}
