using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject player;
    public GameObject[] spawnPoints;
    public GameObject enemy;
    public GameObject sickEnemy;

    public int maxEnemiesOnScreen;
    public int maxSickOnScreen;

    public float minSpawnTime;
    public float maxSpawnTime;
    public int enemiesPerSpawn;
    public int sickPerSpawn;

    public int enemiesOnScreen = 0;
    public int sickOnScreen = 0;
    private float generatedSpawnTime = 0;
    private float currentSpawnTime = 0;
    private bool gameOver = false;
    [SerializeField]
    float currentHealth = Health.health;

    [SerializeField] private AudioClip bite;
    private AudioSource m_AudioSource;

    // Use this for initialization
    void Start () {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        m_AudioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (player == null)
        {
            return;
        }
        currentSpawnTime += Time.deltaTime;
        
        if (currentSpawnTime > generatedSpawnTime)
        {
            currentSpawnTime = 0;
            generatedSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            if (enemiesPerSpawn > 0)
            {
                List<int> previousSpawnLocations = new List<int>();
                if (enemiesPerSpawn > spawnPoints.Length)
                {
                    enemiesPerSpawn = spawnPoints.Length - 1;
                }


                for (int i = 0; i < enemiesPerSpawn; i++)
                {
                    if (enemiesOnScreen < maxEnemiesOnScreen)
                    {
                        enemiesOnScreen += 1;
                        int spawnPoint = -1;
                        while (spawnPoint == -1)
                        {
                            int randomNumber = Random.Range(0, spawnPoints.Length - 1);
                            if (!previousSpawnLocations.Contains(randomNumber))
                            {
                                previousSpawnLocations.Add(randomNumber);
                                spawnPoint = randomNumber;
                            }
                        }

                        GameObject spawnLocation = spawnPoints[spawnPoint];
                        GameObject newEnemy = Instantiate(enemy) as GameObject;
                        newEnemy.transform.position = spawnLocation.transform.position;
                        Enemy enemyScript = newEnemy.GetComponent<Enemy>();
                        enemyScript.target = player.transform;
                        //enemyScript.OnDestroy.AddListener(EnemyDestroyed);
                        //Vector3 targetRotation = new Vector3(player.transform.position.x, newEnemy.transform.position.x, player.transform.position.z);
                        //newEnemy.transform.LookAt(targetRotation);
                    }
                    if (sickOnScreen < maxSickOnScreen)
                    {
                        sickOnScreen += 1;
                        int spawnPoint = -1;
                        while (spawnPoint == -1)
                        {
                            int randomNumber = Random.Range(0, spawnPoints.Length - 1);
                            if (!previousSpawnLocations.Contains(randomNumber))
                            {
                                previousSpawnLocations.Add(randomNumber);
                                spawnPoint = randomNumber;
                            }
                        }
                        GameObject spawnLocation = spawnPoints[spawnPoint];
                        GameObject newSick = Instantiate(sickEnemy) as GameObject;
                        newSick.transform.position = spawnLocation.transform.position;
                        Enemy sickenemyScript = newSick.GetComponent<Enemy>();
                        sickenemyScript.target = player.transform;
                        //sickenemyScript.OnDestroy.AddListener(SickEnemyDestroyed);
                    }
                }
            }
            
        }

        if (Health.health <= 0 && gameOver == false)
        {
            endGame();
        }
    }

    public void endGame()
    {
        gameOver = true;
        SceneManager.LoadScene("GameOver");
    }
    
    public void EnemyDie()
    {
        enemiesOnScreen -= 1;
        PlayBiteSound();
    }
    public void SickDie()
    {
        sickOnScreen -= 1;
        PlayBiteSound();
    }
    private void PlayBiteSound()
    {
        m_AudioSource.clip = bite;
        m_AudioSource.Play();
    }
}
