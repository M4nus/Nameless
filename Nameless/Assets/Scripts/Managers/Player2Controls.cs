using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controls : MonoBehaviour, IHurtable
{
    MovementManager movementInput;
    Shooting shootingInput;
    public int maxHealthPoints;
    public int currentHealthPoints;

    // Use this for initialization
    void Start()
    {
        movementInput = GetComponent<MovementManager>();
        shootingInput = GetComponent<Shooting>();
        currentHealthPoints = maxHealthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        movementInput.MoveConditions("Horizontal2", "Vertical2", this.gameObject);
        shootingInput.ShootControl("RT2");
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
