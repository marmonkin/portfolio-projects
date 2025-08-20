using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class RoomWave : MonoBehaviour
{
    [Header("Animation Settings")]
    public float WaveDuration = 2f; // Total duration of the wave

    public float WaveDelay = 0.1f; // Delay between each cube's animation
    public float MoveHeight = 3f; // How high cubes move up
    public Vector3 WaveOrigin = Vector3.zero; // Corner where wave starts

    [Header("Easing")]
    public Ease EaseType = Ease.OutBack;

    private List<Transform> roomCubes = new List<Transform>();
    private bool hasAnimated = false;

    private string cubeTag = "RoomBlock";

    private void Start()
    {
        FindAllCubes();
    }

    private void FindAllCubes()
    {
        roomCubes.Clear();

        // Get all transforms in children recursively
        Transform[] allChildren = GetComponentsInChildren<Transform>();

        foreach (Transform child in allChildren)
        {
            // Skip self
            if (child == transform) continue;

            // Optional tag filtering
            if (!string.IsNullOrEmpty(cubeTag) && !child.CompareTag(cubeTag))
                continue;

            // Add to list if it's a cube (you could add more filters here)
            if (child.gameObject.activeInHierarchy)
            {
                roomCubes.Add(child);
            }
        }
    }

    public void TriggerWaveAnimation()
    {
        if (hasAnimated) return;

        hasAnimated = true;

        // Sort cubes by distance from wave origin
        roomCubes.Sort((a, b) =>
            Vector3.Distance(a.position, WaveOrigin).CompareTo(
            Vector3.Distance(b.position, WaveOrigin)));

        // Store original positions
        Vector3[] originalPositions = new Vector3[roomCubes.Count];
        for (int i = 0; i < roomCubes.Count; i++)
        {
            originalPositions[i] = roomCubes[i].position;

            // Start cubes below ground
            roomCubes[i].position = originalPositions[i] - Vector3.up * MoveHeight;
        }

        // Animate each cube with delay based on distance from origin
        for (int i = 0; i < roomCubes.Count; i++)
        {
            float delay = (float)i / roomCubes.Count * WaveDuration;

            roomCubes[i].DOMoveY(originalPositions[i].y, WaveDuration - WaveDelay)
                .SetDelay(delay)
                .SetEase(EaseType);
        }

        hasAnimated = false;
    }

    // Call this from inspector or another script
    [ContextMenu("Test Wave Animation")]
    private void TestAnimation()
    {
        TriggerWaveAnimation();
    }
}