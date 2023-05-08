using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    public float damage = 3;
    Vector2 rightAttackOffset;
    Vector2 rightAttackEffectOffset;
    public GameObject attackAnimationObject;
    public Animator attackAnimation;

    private void Start()
    {
        rightAttackOffset = transform.localPosition;
        rightAttackEffectOffset = attackAnimationObject.transform.localPosition;
    }

    public void AttackRight()
    {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
        attackAnimationObject.SetActive(true);
        attackAnimationObject.transform.localPosition = rightAttackEffectOffset;
        attackAnimationObject.GetComponent<SpriteRenderer>().flipX = false;
        attackAnimation.Play("attack_effect");
    }


    public void HideEffect()
    {
        attackAnimationObject.SetActive(false);
    }

    public void AttackLeft()
    {
        // The 0.1 was added for the knight sprite to work probably
        float leftAttackOffset = rightAttackOffset.x + 0.1f;
        float leftAttackEffectOffset = rightAttackEffectOffset.x + 0.1f;
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(leftAttackOffset * -1, rightAttackOffset.y);
        attackAnimationObject.SetActive(true);
        attackAnimationObject.transform.localPosition = new Vector3(leftAttackEffectOffset * -1, rightAttackEffectOffset.y);
        attackAnimationObject.GetComponent<SpriteRenderer>().flipX = true;
        attackAnimation.Play("attack_effect");
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // Deal damage to the enemy
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.Health -= damage;
                print(enemy.Health);
            }
        }
    }
}
