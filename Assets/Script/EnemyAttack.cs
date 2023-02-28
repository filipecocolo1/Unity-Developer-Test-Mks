using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;            // Refer�ncia ao objeto do jogador
    public float attackDistance = 10f;  // Dist�ncia m�xima que o inimigo pode atacar o jogador
    public float attackTime = 2f;       // Tempo entre os ataques
    public GameObject bulletPrefab;     // Prefab do proj�til que o inimigo vai disparar
    public Transform bulletSpawnPoint; // Local onde o proj�til ser� criado

    private float attackTimer = 0f;     // Contador para o tempo entre os ataques

    void Update()
    {
        // Verifica a dist�ncia entre o jogador e o inimigo
        float distance = Vector3.Distance(transform.position, player.position);

        // Se a dist�ncia for menor ou igual � dist�ncia de ataque, e o tempo entre os ataques j� passou
        if (distance <= attackDistance && attackTimer <= 0f)
        {
            // Atira no jogador
            FireBullet();

            // Reseta o timer
            attackTimer = attackTime;
        }
        else
        {
            // Subtrai o tempo desde a �ltima atualiza��o do timer
            attackTimer -= Time.deltaTime;
        }
    }

    void FireBullet()
    {
        // Cria o proj�til na posi��o do spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Atira na dire��o do jogador
        bullet.GetComponent<Rigidbody2D>().velocity = (player.position - bulletSpawnPoint.position).normalized * 10f;

        // Destroi o proj�til depois de 5 segundos
        Destroy(bullet, 5f);
    }
}
