using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack 
{
    private double _nextAttackTime;
    private Entity _owner;

    public AutoAttack( Entity owner ) {                 //CONSTRUCTOR!!! No hereda de Monobehaviour!!! D: D: D:
        _owner = owner;
    }

    public void Tick() {
        if ( CanNotAttack() )
            return;

         DoAttack();
    }

    private bool CanNotAttack() {

        if ( Time.time < _nextAttackTime )
            return true;

        if ( _owner.AttackOn == false )
            return true;

        if ( _owner.Target == null )
            return true;

        var distanceToTarget = Vector3.Distance( _owner.transform.position, _owner.Target.transform.position );
        if ( distanceToTarget > _owner.AttackRange ) {
            return true;
        }

        return false;
    }

    private void DoAttack() {
        _nextAttackTime = Time.time + _owner.AttackDelay;
        _owner.Target.TakeDamage( _owner.AttackDamage );
    }

}
