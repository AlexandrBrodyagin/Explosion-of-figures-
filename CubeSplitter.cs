using UnityEngine;

public class CubeSplitter : MonoBehaviour
{
    [SerializeField] private float _baseSplitChance = 1f;
    [SerializeField] private float _explosionForce = 50f;
    [SerializeField] private float _explosionRadius = 5f;

    private CubeSpawner _spawner;
    private float _currentSplitChance;

    private void Awake()
    {
        _spawner = GetComponent<CubeSpawner>();
        _currentSplitChance = _baseSplitChance;
    }

    public void SetSplitChance(float newChance)
    {
        _currentSplitChance = newChance;
    }

    public void TrySplit()
    {
        if (Random.value > _currentSplitChance)
        {
            Destroy(gameObject);
            return;
        }

        var newCubes = _spawner.SpawnCubes();
        ApplyExplosionForce(newCubes);
        Destroy(gameObject);
    }

    private void ApplyExplosionForce(GameObject[] cubes)
    {
        foreach (var cube in cubes)
        {
            var rb = cube.GetComponent<Rigidbody>();
            rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    public float GetNextSplitChance() => _currentSplitChance * 0.5f;
}