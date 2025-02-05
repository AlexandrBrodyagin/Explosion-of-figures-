using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CubeColorizer : MonoBehaviour
{
    private void Awake()
    {
        ApplyRandomColor();
    }

    public void ApplyRandomColor()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}