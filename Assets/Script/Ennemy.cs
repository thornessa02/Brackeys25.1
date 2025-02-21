using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public int hp;
    public GameObject bloodFX;
    private void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage()
    {
        hp--;
        Instantiate(bloodFX, transform.position+Vector3.up, Quaternion.identity);
    }
}
