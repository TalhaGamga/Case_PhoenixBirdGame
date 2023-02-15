using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float damage;

    Vector3 direction;

    Transform target; 
    [SerializeField] string teamTag;

    [SerializeField] private ProjectileDataSO projectileDataSO;

    [SerializeField] Renderer _renderer;

    private void Awake()
    { 
        speed = projectileDataSO.speed;
        damage = projectileDataSO.damage;
    }

    void Update()
    {
        Go(target);
    }

    public void Go(Transform target)
    {
        if (target)
        {
            this.target = target;

            direction = (target.position - transform.position + Vector3.up).normalized;

            transform.Translate(direction * speed * Time.deltaTime);

            return;
        }

        gameObject.SetActive(false);
    }

    public void SetProjectile(string targetTag,Color color)
    {
        this.teamTag = targetTag;
        _renderer.material.color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable) && !collision.gameObject.CompareTag(teamTag))
        {
            Debug.Log(damagable); 

            damagable.TakeDamage(damage);
        }
    }
}
