using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable {
    public void TakeDamage(int dmg);
}

public interface IAttackable {
    public void TakeDamage(int dmg);
}

public interface IInteractable {
    public void Interact(PlayerController p);
}