using UnityEngine;

public class TorchSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] TorchspawnPoints; // Масив точок спавну

    [SerializeField]
    private GameObject torch; // Префаб факела

    [SerializeField]
    private float t_spawnInterval = 1.0f; // Інтервал спавну

    void Start()
    {
        // Викликаємо метод Spawn_Torch кожні t_spawnInterval секунд
        InvokeRepeating("Spawn_Torch", t_spawnInterval, t_spawnInterval);
    }

    private void Spawn_Torch()
    {
        if (TorchspawnPoints.Length == 0)
        {
            Debug.LogWarning("TorchspawnPoints array is empty!");
            return;
        }

        // Ітеруємо через всі точки спавну
        foreach (GameObject spawnPoint in TorchspawnPoints)
        {
            // Створюємо факел у кожній точці спавну
            GameObject sp = Instantiate(torch);
            sp.transform.position = spawnPoint.transform.position;

            // Перевіряємо позицію точки спавну по осі X для віддзеркалення
            if (spawnPoint.transform.position.x < 0)
            {
                // Якщо точка спавну ліворуч (x < 0), віддзеркалюємо факел
                Vector3 flippedScale = sp.transform.localScale;
                flippedScale.x = -Mathf.Abs(flippedScale.x); // Робимо масштаб по X негативним
                sp.transform.localScale = flippedScale;
            }
            else
            {
                // Якщо точка спавну праворуч (x >= 0), залишаємо факел нормальним
                Vector3 normalScale = sp.transform.localScale;
                normalScale.x = Mathf.Abs(normalScale.x); // Робимо масштаб по X позитивним
                sp.transform.localScale = normalScale;
            }
        }
    }
}
