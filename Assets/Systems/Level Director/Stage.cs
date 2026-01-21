using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stage : ScriptableObject
{
    [Tooltip("How often the director will attempt to spawn enemies per second")]
    [SerializeField] private float spawnFrequency;
    [Tooltip("Amount of enemies that the director will spawn each time")]
    [SerializeField] private float spawnAmount;
    [SerializeField] private float minSpawnDistance;
    [SerializeField] private float maxSpawnDistance;
    [Tooltip("Enemies that can be spawned during this stage")]
    [SerializeField] private GameObject[] enemiesUsed;
    private float progress = 0f;

    public float SpawnFrequency
    { get { return spawnFrequency; } }
    public float SpawnAmount
    { get { return spawnAmount; } }
    public float MaxSpawnDistance
    { get { return maxSpawnDistance; } }
    public float MinSpawnDistance
    { get { return minSpawnDistance; } }
    public virtual float Progress
    { get { return progress; } private set { progress = Mathf.Clamp01(value); } } // Default progression, can be overridden by specific stages
    public GameObject RandomEnemy
    { get { return enemiesUsed[UnityEngine.Random.Range(0, enemiesUsed.Length)]; } }
    public abstract void StartStage();
    public abstract void DoPayloadBehaviour();
    public abstract void PlayerInRange();
    public abstract void PlayerOutOfRange();
}