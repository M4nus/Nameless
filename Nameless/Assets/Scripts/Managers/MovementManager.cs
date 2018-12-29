using UnityEngine;

public class MovementManager : MonoBehaviour
{       
    private Vector3 moveInput;
    private float input;
                             
    public void MoveConditions(string axisX, string axisY, GameObject obj)
    {
        if(Input.GetAxisRaw(axisX) != 0)
        {
            input = Input.GetAxisRaw(axisX);
            moveInput = new Vector3(input, 0, 0);
            Move(obj);
            obj.transform.rotation = new Quaternion(0, 0, -Mathf.Sign(input) * 90, 90);
        }
        if(Input.GetAxisRaw(axisY) != 0)
        {
            input = Input.GetAxisRaw(axisY);
            moveInput = new Vector3(0, input, 0);
            Move(obj);
            transform.rotation = new Quaternion(0, 0, -Mathf.Sign(input) * 90 + 90, 0);
        } 
    }

    private void Move(GameObject obj)
    {
        Vector3 moveVelocity = moveInput * GameSpace.GameManager.instance.playerSpeed * Time.deltaTime;
        obj.transform.position += moveVelocity;
    }
}
