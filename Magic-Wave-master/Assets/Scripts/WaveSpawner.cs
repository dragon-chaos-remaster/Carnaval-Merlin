using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum SpawnState { SPAWNANDO, ESPERANDO, CONTANDO };

public class WaveSpawner : MonoBehaviour
{
   
    public Pooling[] pooledObjects;
    
    [System.Serializable]
    public class Wave
    {
        public string nome;
        public Transform[] inimigo;
        public int quantidade;
        public float ritmo;
    }

    public Wave[] waves;

    public Transform[] spawnPoints;

    public TextMeshProUGUI[] contagemRegressiva;

    private int proximaWave = 0;
    bool spawnEnemies;
    //public List<GameObject> enemyList = new List<GameObject>();
    public float contadorDaWave;
    public float tempoEntreWaves = 5f;
    //public Transform ondeOInimigoEsta, ondeOInimigoSpawna;
    private float procurarContador = 1f;
    private SpawnState estado = SpawnState.CONTANDO;
    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("ERRO: Não foi encontrado nenhum Ponto de Spawn dos Inimigos na Cena. FAVOR COLOCAR: " + spawnPoints.Length + " PARA A CENA");
        }

        contadorDaWave = tempoEntreWaves;
        
    }
    void Update()
    {
        if(estado == SpawnState.ESPERANDO)
        {
            //Checar se os inimigos ainda estão vivos
            if (!InimigoVivo())
            {
                OnWaveCompleted();
                WaveCount.Instance.numeroDaWave++;
                contagemRegressiva[0].gameObject.SetActive(true);
                contagemRegressiva[1].gameObject.SetActive(true);
                print("Wave Completa");
                return;
                //Começa um novo round
            }
            else
            {
                return;
            }
        }
        int someInt = (int)contadorDaWave;
        contagemRegressiva[0].text = someInt.ToString();
        contagemRegressiva[1].text = someInt.ToString();

        if(contadorDaWave <= 0)
        {
            WaveCount.Instance.waveClear.gameObject.SetActive(false);
            contagemRegressiva[0].gameObject.SetActive(false);
            contagemRegressiva[1].gameObject.SetActive(false);
            if (estado != SpawnState.SPAWNANDO)
            {
                //Começa a spawnar a Wave
                StartCoroutine(CanSpawn(waves[proximaWave]));
            }
        }
        else
        {
            contadorDaWave -= Time.deltaTime;
        }
    }
    bool InimigoVivo()
    {
        procurarContador -= Time.deltaTime;
        if (procurarContador <= 0f)
        {
            procurarContador = 1f;
            if (GameObject.FindGameObjectWithTag("inimigoFraco") == null && GameObject.FindGameObjectWithTag("inimigoTerra") == null)
            {
                //print(GameObject.FindGameObjectWithTag("Enemy").ToString());
                return false;
            }
        }
        return true;
    }
    void OnWaveCompleted()
    {
        estado = SpawnState.CONTANDO;
        contadorDaWave = tempoEntreWaves;
        WaveCount.Instance.waveClear.gameObject.SetActive(true);
        if(proximaWave + 1 > waves.Length - 1)
        {
            proximaWave = 0;
        }
        else
        {
            proximaWave++;
        }
        
    }
    IEnumerator CanSpawn(Wave wave)
    {
        estado = SpawnState.SPAWNANDO;

        //O Spawn
        for (int i = 0; i < wave.quantidade; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f / wave.ritmo);
        }
        //Fim do Spawn
        estado = SpawnState.ESPERANDO;
        
        yield break;
    }
    void SpawnEnemy()
    {
        GameObject enemy = pooledObjects[Random.Range(0,pooledObjects.Length)].GetPooledObject();
        
        if(enemy != null)
        {
            print("Entro");
            Transform randomPos = spawnPoints[Random.Range(0, spawnPoints.Length)];
            //SetEnemyToSpawn();
            
            enemy.SetActive(true);
            enemy.transform.position = randomPos.position;
            //enemy.transform.rotation = randomPos.rotation;
        }
    }
    public void SetEnemyToSpawn()
    {
        Vector3 randomPos = new Vector3(Random.Range(3, 13), 0, Random.Range(-4, -15));
       
       
    }
}
