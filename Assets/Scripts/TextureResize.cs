using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureResize : MonoBehaviour
{
    public float scaleFactor = 1.0f;
    private Renderer myRenderer; // Cambié el nombre de la variable para evitar la advertencia.

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        UpdateTextureScale();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.hasChanged && Application.isEditor && !Application.isPlaying) {
            UpdateTextureScale();
            transform.hasChanged = false;
        }
    }

    void UpdateTextureScale()
    {
        if (myRenderer.material != null)
        {
            myRenderer.material.mainTextureScale = new Vector2(transform.localScale.x / scaleFactor, transform.localScale.z / scaleFactor);
        }
    }
}
