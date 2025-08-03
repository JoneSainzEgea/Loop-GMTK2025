using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShadow : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private float maxJumpHeight = 3f;
    [SerializeField] private float minScaleX = 0.3f;
    [SerializeField] private float minScaleY = 0.6f;

    private Vector3 originalScale;
    private float baseY;

    void Start()
    {
        baseY = character.transform.position.y;
        originalScale = transform.localScale;
    }

    void Update()
    {
        transform.position = new Vector2(character.transform.position.x, transform.position.y);

        float currentY = character.transform.position.y;
        float heightFactor = Mathf.Clamp01((currentY - baseY) / maxJumpHeight);

        float scaleX = Mathf.Lerp(originalScale.x, originalScale.x * minScaleX, heightFactor);
        float scaleY = Mathf.Lerp(originalScale.y, originalScale.y * minScaleY, heightFactor);
        transform.localScale = new Vector3(scaleX, scaleY, originalScale.z);
    }
}
