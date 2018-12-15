using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controls : MonoBehaviour
{
    MovementManager movementInput;
    Shooting shootingInput;

    // Use this for initialization
    void Start()
    {
        movementInput = GetComponent<MovementManager>();
        shootingInput = GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        movementInput.MoveConditions("Horizontal2", "Vertical2", this.gameObject);
        shootingInput.ShootControl("RT2");
    }
}
