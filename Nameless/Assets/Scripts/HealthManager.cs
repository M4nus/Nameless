using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHurtable {

    void Die();

    void TakeDamage(int damage);

    int GetCurrentHealthPoints();



}
