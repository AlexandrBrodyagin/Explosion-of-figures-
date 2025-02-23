using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private int _minNumbersCubes = 2;
    private int _maxNumbersCubes = 6;
    private float _scaleReductionRatio = 0.5f;

    public GameObject[] SpawnCubes()
    {
        int amount = Random.Range(_minNumbersCubes, _maxNumbersCubes + 1);
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
        newCube.transform.localScale = transform.localScale * _scaleReductionRatio;

        if (newCube.TryGetComponent(out CubeSplitter splitter) && TryGetComponent(out CubeSplitter thisSplitter))
        {
            splitter.SetSplitChance(thisSplitter.GetNextSplitChance());
        }
    }
}