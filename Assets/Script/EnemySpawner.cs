
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public bool isWaveEnd = false;

    public WaveData[] waves; 

    public int currentWaveIndex;
    public int currentGroupIndex;

    public Transform[] wayPoints; 

    void Start()
    {
        currentWaveIndex = 0;
        currentGroupIndex = 0;
        StartCoroutine(WaveCoroutine());
    }

    public IEnumerator WaveCoroutine()
    {
        while(currentWaveIndex < waves.Length)
        {
            WaveData wavetemp = waves[currentWaveIndex];
            yield return new WaitForSeconds(wavetemp.delayBeforeWave);

            while(currentGroupIndex < wavetemp.groups.Length)
            {
                EnemyGroup grouptemp = wavetemp.groups[currentGroupIndex];
                for(int i = 0; i < grouptemp.enemyCount; i++)
                {
                    if(MainGameController.instance.isEndGame)
                    {
                        yield break;
                    }

                    GameObject go = Instantiate(grouptemp.enemyPrefab, Vector3.zero, Quaternion.identity);
                    EnemyController enemy = go.GetComponent<EnemyController>();
                    if(enemy == null)
                    {
                        Destroy(go);
                    }
                    else
                    {
                        enemy.Setup(wayPoints);
                    }
                    yield return new WaitForSeconds(grouptemp.enemyDelay);
                }
                yield return new WaitForSeconds(grouptemp.nextGroupDelay);
                currentGroupIndex++;
            }
            currentGroupIndex = 0;
            currentWaveIndex++;
        }
        isWaveEnd = true;
    }
}

[System.Serializable]
public class EnemyGroup
{
    public GameObject enemyPrefab;
    public int enemyCount;
    public float enemyDelay;
    public float nextGroupDelay;

}

[System.Serializable]
public class WaveData
{
    public EnemyGroup[] groups;
    public float delayBeforeWave;

}
