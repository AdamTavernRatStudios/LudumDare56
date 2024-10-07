using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBlower : MonoBehaviour
{
    public GameObject BubblePrefab;
    public Transform BubbleSpawnPoint;
    public float TimeBetweenBubbles = 5f;
    public int NumBubbles = 4;
    public float TimeBetweenEachBubble = 0.2f;

    public SpriteRenderer bubbleBlowerSR;
    public Sprite OffSprite;
    public Sprite OnSprite;

    private void Start()
    {
        StartCoroutine(BubbleBlowerRoutine());
    }

    private IEnumerator BubbleBlowerRoutine()
    {
        while (true)
        {
            if (!GameManager.Instance.DayIsOccuring)
            {
                yield return null;
                continue;
            }
            bubbleBlowerSR.sprite = OnSprite;
            for (int i = 0; i < NumBubbles; i++)
            {
                SpawnBubble();
                yield return new WaitForSeconds(TimeBetweenEachBubble);
            }
            bubbleBlowerSR.sprite = OffSprite;
            yield return new WaitForSeconds(TimeBetweenBubbles);
        }
    }

    private void SpawnBubble()
    {
        var newBubble = Instantiate(BubblePrefab, BubbleSpawnPoint.transform.position, Quaternion.identity);
        newBubble.transform.localScale = Vector3.zero;
        var finalScale = Vector3.one * UnityEngine.Random.Range(0.8f, 1.2f);
        LeanTween.scale(newBubble, finalScale, 0.5f).setEaseInOutCubic();
        newBubble.GetComponent<Rigidbody2D>().AddForce(Vector2.left * transform.localScale.x * UnityEngine.Random.Range(1, 3), ForceMode2D.Impulse);
    }
}
