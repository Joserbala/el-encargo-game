﻿using UnityEngine;

[CreateAssetMenu(fileName = "NewIntVariable", menuName = "Scriptables/Variables/IntVariable")]
public class IntVariableSO : ScriptableObject
{
    [SerializeField] private int value;

    public int Value { get => value; private set => this.value = value; }
}
