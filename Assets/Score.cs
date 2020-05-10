using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static TextMeshProUGUI textMesh;
    public static int score = 0;
    private static ParticleSystem sizzle;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        sizzle = GetComponent<ParticleSystem>();
    }

    public static void UpdateScore()
    {
        score++;
        textMesh.text = score.ToString();
        sizzle.Play();
    }
}
