using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    public GameObject[] SpawnCubes()
    {
        int amount = Random.Range(2, 7);
        GameObject[] newCubes = new GameObject[amount];

        for (int i = 0; i < amount; i++)
        {
            newCubes[i] = Instantiate(
                _cubePrefab,
                transform.position,
                Quaternion.identity
            );

            SetupNewCube(newCubes[i]);
        }

        return newCubes;
    }

    private void SetupNewCube(GameObject newCube)
    {
        newCube.transform.localScale = transform.localScale * 0.5f;

        var splitter = newCube.GetComponent<CubeSplitter>();

        if (splitter != null)
        {
            
            float nextChance = GetComponent<CubeSplitter>().GetNextSplitChance();
            splitter.SetSplitChance(nextChance);
        }
    }
}