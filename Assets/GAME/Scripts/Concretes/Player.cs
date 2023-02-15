using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : CharacterBase
{
    public override void Die()
    {
        GetComponent<HybridMovement>().RemoveFromList();
        base.Die();
    }
}
