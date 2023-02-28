using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;            // Referência ao objeto do jogador
    public float attackDistance = 10f;  // Distância máxima que o inimigo pode atacar o jogador
    public float attackTime = 2f;       // Tempo entre os ataques
    public GameObject bulletPrefab;     // Prefab do projétil que o inimigo vai disparar
    public Transform bulletSpawnPoint; // Local onde o projétil será criado

    private float attackTimer = 0f;     // Contador para o tempo entre os ataques

    void Update()
    {
        // Verifica a distância entre o jogador e o inimigo
        float distance = Vector3.Distance(transform.position, player.position);

        // Se a distância for menor ou igual à distância de ataque, e o tempo entre os ataques já passou
        if (distance <= attackDistance && attackTimer <= 0f)
        {
            // Atira no jogador
            FireBullet();

            // Reseta o timer
            attackTimer = attackTime;
        }
        else
        {
            // Subtrai o tempo desde a última atualização do timer
            attackTimer -= Time.deltaTime;
        }
    }

    void FireBullet()
    {
        // Cria o projétil na posição do spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Atira na direção do jogador
        bullet.GetComponent<Rigidbody2D>().velocity = (player.position - bulletSpawnPoint.position).normalized * 10f;

        // Destroi o projétil depois de 5 segundos
        Destroy(bullet, 5f);
    }
}
