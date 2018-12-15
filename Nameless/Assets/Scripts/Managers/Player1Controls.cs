using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controls : MonoBehaviour
{
    MovementManager movementInput;
    Shooting shootingInput;

    // Use this for initialization
    void Start ()
    {
        movementInput = this.GetComponent<MovementManager>();
        shootingInput = this.GetComponent<Shooting>();        
    }
	
	// Update is called once per frame
	void Update ()
    {
        movementInput.MoveConditions("Horizontal1", "Vertical1", this.gameObject);
        shootingInput.ShootControl("RT1");
    }
}
