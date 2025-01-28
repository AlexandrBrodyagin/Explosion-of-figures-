using UnityEngine;

public class CubeDivision : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField][Range(0, 1)] private float _splitChance = 0.5f;

    private float _sizeReductionFactor = 0.5f;
    public float SplitChance => _splitChance;

    private void OnMouseDown()
    {
        HandleCubeClick();
    }

    private void HandleCubeClick()
    {
        if (IsSplit())
        {
            SplitCube();
        }

        Destroy(gameObject);
    }

    private bool IsSplit()
    {
        return Random.value <= _splitChance;
    }

    private void SplitCube()
    {
        int minCountCubes = 2;
        int maxCountCubes = 6;
        float chanseDivisor = 0.5f;

        _splitChance *= chanseDivisor;
        int numbersOfCubes = Random.Range(minCountCubes, maxCountCubes + 1);

        for (int i = 0; i < numbersOfCubes; i++)
        {
            GameObject newCube = CreateCube();
        }
    }

    private GameObject CreateCube()
    {
        GameObject newCube = Instantiate(_cubePrefab, transform.position, Random.rotation);
        newCube.transform.localScale = transform.localScale * _sizeReductionFactor;
        return newCube;
    }

}
