using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawn : MonoBehaviour
{
    public EnemyMovement Enemy;  //Aqui onde vai armazenar o prefab
    public float TempSpawn;      //Tempo de spawn do Inimigo 
    public int WavesToSpawn;     //Número de ondas a serem spawnadas
    public int EnemiesPerWave;   //Número de inimigos por onda

    private float spawnTimer;    //Contador de tempo para spawn
    private int wavesSpawned;    //Número de ondas spawnadas

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = TempSpawn;
        wavesSpawned = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f && wavesSpawned < WavesToSpawn)
        {
            // Loop para spawnar inimigos de uma onda
            for (int i = 0; i < EnemiesPerWave; i++)
            {
                Instantiate(Enemy, transform.position, Quaternion.identity);
            }

            wavesSpawned++;
            spawnTimer = TempSpawn;
        }
        else if (wavesSpawned >= WavesToSpawn)
        {
            // Se já spawnou todas as ondas, reseta as variáveis
            wavesSpawned = 0;
            spawnTimer = TempSpawn;
        }
    }
}


