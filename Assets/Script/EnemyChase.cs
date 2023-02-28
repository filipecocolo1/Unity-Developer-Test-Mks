using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyChase : MonoBehaviour
{
    public float chaseDistance = 5.0f; // Dist�ncia em que o inimigo come�a a perseguir o jogador
    public float chaseSpeed = 8.0f; // Velocidade de persegui��o do inimigo
    public float normalSpeed = 4.0f; // Velocidade normal do inimigo

    public Transform player; // Refer�ncia para o transform do jogador

    private EnemyMovement enemyMovement; // Refer�ncia para o script EnemyMovement

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>(); // Obt�m a refer�ncia do script EnemyMovement que est� no mesmo objeto que este script
    }

    private void Update()
    {
        // Verifica se a vari�vel player � diferente de null e se a dist�ncia entre o inimigo e o jogador � menor do que a dist�ncia de persegui��o definida
        if (player != null && Vector2.Distance(transform.position, player.position) < chaseDistance)
        {
            enemyMovement.StartChasing(player); // Inicia a persegui��o
            transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime); // Move o inimigo em dire��o ao jogador com a velocidade de persegui��o definida
        }
        // Verifica se a vari�vel enemyMovement � diferente de null e se a dist�ncia entre o inimigo e a posi��o inicial (definida no script EnemyMovement) � menor do que 0.2 unidades
        else if (enemyMovement != null && Vector2.Distance(transform.position, enemyMovement.startingPosition) < 0.2f)
        {
            enemyMovement.StopChasing(); // Para a persegui��o
            transform.position = Vector2.MoveTowards(transform.position, enemyMovement.moveSPots[enemyMovement.randomSpot].position, enemyMovement.speed * Time.deltaTime); // Move o inimigo para um dos pontos de movimento aleat�rios definidos no script EnemyMovement, com a velocidade normal do inimigo
        }
    }
}
