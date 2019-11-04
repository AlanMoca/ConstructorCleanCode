using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int Health = 10;
    public Entity Target;           //Singleton
    private AutoAttack _autoAttackController;

    public bool AttackOn { get; set; } = true;

    public double AttackRange { get; set; } = 1f;

    public double AttackDelay { get; set; } = 2f;

    public int AttackDamage { get; set; } = 1;

    
    void Start()
    {
        _autoAttackController = new AutoAttack( this );
    }

    private void Update() {
        _autoAttackController.Tick();
    }

    public void TakeDamage( int amout ) {
        Health -= amout;
        if ( Health < 0 ) {
            Die();
        }
    }

    private void Die() {
        Debug.Log( "Dead..." + gameObject.name );
    }

}
