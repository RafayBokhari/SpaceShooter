using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] Renderer meshrender;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
       meshrender = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 offset = meshrender.material.mainTextureOffset;
        //offset = offset + new Vector2(0, speed*Time.deltaTime);
        //meshrender.material.mainTextureOffset = offset;

        meshrender.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);

    }
}
