using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyChase : MonoBehaviour
{
    public float chaseDistance = 5.0f; // Distância em que o inimigo começa a perseguir o jogador
    public float chaseSpeed = 8.0f; // Velocidade de perseguição do inimigo
    public float normalSpeed = 4.0f; // Velocidade normal do inimigo

    public Transform player; // Referência para o transform do jogador

    private EnemyMovement enemyMovement; // Referência para o script EnemyMovement

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>(); // Obtém a referência do script EnemyMovement que está no mesmo objeto que este script
    }

    private void Update()
    {
        // Verifica se a variável player é diferente de null e se a distância entre o inimigo e o jogador é menor do que a distância de perseguição definida
        if (player != null && Vector2.Distance(transform.position, player.position) < chaseDistance)
        {
            enemyMovement.StartChasing(player); // Inicia a perseguição
            transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime); // Move o inimigo em direção ao jogador com a velocidade de perseguição definida
        }
        // Verifica se a variável enemyMovement é diferente de null e se a distância entre o inimigo e a posição inicial (definida no script EnemyMovement) é menor do que 0.2 unidades
        else if (enemyMovement != null && Vector2.Distance(transform.position, enemyMovement.startingPosition) < 0.2f)
        {
            enemyMovement.StopChasing(); // Para a perseguição
            transform.position = Vector2.MoveTowards(transform.position, enemyMovement.moveSPots[enemyMovement.randomSpot].position, enemyMovement.speed * Time.deltaTime); // Move o inimigo para um dos pontos de movimento aleatórios definidos no script EnemyMovement, com a velocidade normal do inimigo
        }
    }
}
