using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityOriginal : MonoBehaviour
{

    public int Health = 10;
    public EntityOriginal Target;           //Singleton

    private double _nextAttackTime;

    public bool AttackOn { get; set; } = true;

    public double AttackRange { get; set; } = 1f;

    public double AttackDelay { get; set; } = 2f;

    public int AttackDamage { get; set; } = 1;

    private void Update() {

        if ( Time.time < _nextAttackTime )
            return;

        if ( AttackOn == false )
            return;

        if ( Target == null )
            return;

        var distanceToTarget = Vector3.Distance( transform.position, Target.transform.position );

        if ( distanceToTarget > AttackRange ) {
            return;
        }

        DoAttack();

    }

    private void DoAttack() {
        _nextAttackTime = Time.time + AttackDelay;
        Target.TakeDamage( this.AttackDamage );
    }

    private void TakeDamage( int amout ) {
        Health -= amout;
        if ( Health < 0 ) {
            Die();
        }
    }

    private void Die() {
        Debug.Log( "Dead..." + gameObject.name );
    }

}
