using UnityEngine;
using System.Collections;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] spawnPoints;

    [SerializeField] 
    private GameObject stone_platform;

    [SerializeField] 
    private GameObject wood_platform;

    [SerializeField] 
    private GameObject mushroom_platform;

    [SerializeField]
    private float s_spawnInterval = 1.0f;

    [SerializeField]
    private float w_spawnInterval = 0.2f;

    [SerializeField]
    private float m_spawnInterval = 1.0f;

    [SerializeField]
    private float minVerticalDistance = 1.5f;

    private float lastSpawnY = -Mathf.Infinity;

    private float speedMultiplier = 1.0f;
    private float speedIncreaseRate = 0.05f;

    // Базові швидкості для різних платформ
    [SerializeField]
    private float stoneBaseSpeed = 1f;

    [SerializeField]
    private float woodBaseSpeed = 1.2f;

    [SerializeField]
    private float mushroomBaseSpeed = 0.8f;

    void Start()
    {
        InvokeRepeating("Spawn_StonePlatform", s_spawnInterval, s_spawnInterval);
        InvokeRepeating("Spawn_WoodPlatform", w_spawnInterval, w_spawnInterval);
        InvokeRepeating("Spawn_MushroomPlatform", m_spawnInterval, m_spawnInterval);

        StartCoroutine(IncreaseSpeedOverTime());
    }

    private IEnumerator IncreaseSpeedOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            speedMultiplier *= 1.01f; // Збільшуємо множник на 1% кожну секунду
        }
    }

    private void Spawn_StonePlatform()
    {
        SpawnPlatformAtRandomPoint(stone_platform, stoneBaseSpeed);
    }

    private void Spawn_WoodPlatform()
    {
        SpawnPlatformAtRandomPoint(wood_platform, woodBaseSpeed);
    }

    private void Spawn_MushroomPlatform()
    {
        SpawnPlatformAtRandomPoint(mushroom_platform, mushroomBaseSpeed);
    }

    private void SpawnPlatformAtRandomPoint(GameObject platformPrefab, float baseSpeed)
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("Spawn Points array is empty!");
            return;
        }

        int index = GetValidSpawnIndex();
        GameObject sp = Instantiate(platformPrefab);
        sp.transform.position = spawnPoints[index].transform.position;

        // Встановлюємо базову швидкість і застосовуємо поточний множник швидкості
        MoveScript moveScript = sp.GetComponent<MoveScript>();
        if (moveScript != null)
        {
            moveScript.SetBaseSpeed(baseSpeed); // Встановлюємо базову швидкість
            float newSpeed = moveScript.GetBaseSpeed() * speedMultiplier;
            moveScript.SetSpeed(newSpeed);
        }

        lastSpawnY = sp.transform.position.y;
    }

    private int GetValidSpawnIndex()
    {
        int index;
        int attempts = 0;
        const int maxAttempts = 10;
        do
        {
            index = UnityEngine.Random.Range(0, spawnPoints.Length);
            attempts++;
            if (attempts > maxAttempts)
            {
                Debug.LogWarning("Unable to find a valid spawn point with sufficient vertical distance.");
                break;
            }
        }
        while (Mathf.Abs(spawnPoints[index].transform.position.y - lastSpawnY) < minVerticalDistance);

        return index;
    }
}
