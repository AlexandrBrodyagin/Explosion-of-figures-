using UnityEngine;

[RequireComponent(typeof(CubeSplitter))]
[RequireComponent(typeof(CubeSpawner))]
[RequireComponent(typeof(CubeColorizer))]

public class CubeBehavior : MonoBehaviour
{
    private CubeSplitter _splitter;

    private void Awake()
    {
        _splitter = GetComponent<CubeSplitter>();
    }

    private void OnMouseDown()
    {
        _splitter.TrySplit();
    }
}