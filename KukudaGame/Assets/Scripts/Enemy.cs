using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _PuffParticleSystem;
    private void OnCollisionEnter2D(Collision2D collision) {
        kukuda kuda = collision.collider.GetComponent<kukuda>();

        if(kuda!=null){
            Instantiate(_PuffParticleSystem,transform.position,Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if(enemy!=null){
            return;
        }

        if(collision.contacts[0].normal.y<0){
            Instantiate(_PuffParticleSystem,transform.position,Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        

    }
}
