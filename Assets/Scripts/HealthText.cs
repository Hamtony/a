using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    public float timeToLive = 0.5f;
    public TextMeshProUGUI textMesh;
    public float floatSpeed = 50;
    RectTransform rectTransform;
    float timeElapsed = 0.0f;
    public Vector3 floatDirection = new Vector3(0,1,0);
    Color startingColor;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();
        startingColor = GetComponent<Color>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        rectTransform.position += floatDirection * floatSpeed * Time.deltaTime;

        textMesh.color = new Color(startingColor.r, startingColor.g, startingColor.b, 1 - (timeElapsed / timeToLive));

        if(timeElapsed>=timeToLive)
        {
            Destroy(gameObject);
        }
    }
}
