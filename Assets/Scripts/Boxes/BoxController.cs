using UnityEngine;

public class BoxController : MonoBehaviour
{
    public int health;
    public int numberOfBox = 50;
    private static int currentNumberOfBox;


    public Texture crackedNormal;
    public Texture crackedHeight;
    public Texture crackedOcclusion;

    public float increasedNormalMapValue;

    private Material material;

    public GameObject prefab;

    private Quaternion rotation;


    void Start()
    {
        material = GetComponent<Renderer>().material;
        currentNumberOfBox = numberOfBox;

        // Normal map özelliklerini etkinleþtirin
        material.EnableKeyword("_NORMALMAP");

        Vector3 rotationAngles = new Vector3(90, 0, 0);
        rotation = Quaternion.Euler(rotationAngles);

    }

    public void TakeDamage()
    {
        health--;

        if (health >= 1)
        {
            ApplyCrackEffect();

        }
        else if (health <= 0)
        {
            // Üçüncü darbe aldý, tuðla yok edilsin
            Destroy(gameObject);
            currentNumberOfBox--;
            ParameterManager.Instance.boxNumberUI.UpdateNumberOfBoxUI(currentNumberOfBox);

            SpawnPowerUp(prefab, gameObject.transform.position);
        }
    }


    public void SpawnPowerUp(GameObject prefab, Vector3 position)
    {

        if (prefab != null)
        {
            GameObject spawnedPrefab = Instantiate(prefab, position, rotation);
            MoveDown movement = spawnedPrefab.AddComponent<MoveDown>();

        }

    }


    public void ApplyCrackEffect()
    {

        if (crackedNormal != null)
        {
            material.SetTexture("_BumpMap", crackedNormal);
            IncreaseNormalMapValue();
        }
        if (crackedHeight != null)
        {
            material.SetTexture("_ParallaxMap", crackedHeight);

        }
        if (crackedOcclusion != null)
        {
            material.SetTexture("_OcclusionMap", crackedOcclusion);

        }

    }


    void IncreaseNormalMapValue()
    {

        increasedNormalMapValue += 2f;
        material.SetFloat("_BumpScale", increasedNormalMapValue);


    }


    public int GetBoxNumber()
    {
        return currentNumberOfBox;
    }





}
