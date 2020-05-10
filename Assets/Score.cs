using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static TextMeshProUGUI textMesh;
    public static int score = 0;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public static void UpdateScore()
    {
        score++;
        textMesh.text = score.ToString();
    }
}
