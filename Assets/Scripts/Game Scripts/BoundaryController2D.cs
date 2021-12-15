using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController2D : MonoBehaviour
{

    [SerializeField]
    private float boundaryRadius = 15f;
    public float BoundaryRadius { get { return boundaryRadius; } }

    private float tempRadius = 0f;
    public float TempRadius { get { return tempRadius; } }

    [SerializeField]
    private float discSize = 0.5f;
    public float DiscSize { get { return discSize; } }

    [SerializeField] private bool updateOverTime = false;


    // Start is called before the first frame update
    void Start()
    {
        tempRadius = boundaryRadius;
        SetScaleFromRadius(boundaryRadius);   
    }

    private void OnValidate()
    {
        discSize = Mathf.Max(0f, discSize);
        boundaryRadius = Mathf.Max(0f, boundaryRadius);
        SetScaleFromRadius(boundaryRadius);
    }

    private void SetScaleFromRadius(float radius)
    {
        transform.localScale = new Vector3(radius * 2f, radius * 2f, 1f);
        if(TryGetComponent(out MeshRenderer meshRenderer))
        {
            Material mat = meshRenderer.sharedMaterial;
            if(mat != null)
            {
                mat.SetFloat("_Radius", radius);
                mat.SetFloat("_DiscSize", discSize);
            }
        }
    }

    private void Update()
    {
        UpdateRadius();
    }

    void UpdateRadius()
    {
        if (!updateOverTime)
            return;

        float tempRadius = Mathf.Clamp01(Mathf.PerlinNoise(Time.time * 0.1f, 0f)) * 5.0f + boundaryRadius;
        SetScaleFromRadius(tempRadius);
    }
}
