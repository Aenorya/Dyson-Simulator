using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleMaker : MonoBehaviour
{
    public GameObject bubblePrefab;
    private BubbleKiller bubbleKiller;
    public int bubbleStart = 20;
    public Vector2 limitsX, limitsY;
    public Gradient gradient;
    public List<GameObject> bubblesList;

    void Start()
    {
        bubbleKiller = FindObjectOfType<BubbleKiller>();
        GenerateBubbles();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DeleteBubbles();
            GenerateBubbles();
        }
    }

    void GenerateBubbles()
    {
        for (int index = 0; index < bubbleStart; index++)
        {
            GameObject bubble = Instantiate(bubblePrefab);
            PlaceBubble(bubble);
            SetBubbleColor(bubble);
            bubblesList.Add(bubble);
        }
    }

    void DeleteBubbles()
    {
        foreach (GameObject bubble in bubblesList)
        {
            Destroy(bubble);
        }
        bubblesList.Clear();
    }

    private void PlaceBubble(GameObject bubble)
    {
        float x = bubbleKiller.transform.position.x + Random.Range(limitsX.x, limitsX.y);
        float y = bubbleKiller.transform.position.y + Random.Range(limitsY.x, limitsY.y);
        bubble.transform.position = new Vector2(x, y);
    }

    private void SetBubbleColor(GameObject bubble)
    {
        bubble.GetComponent<SpriteRenderer>().color = gradient.Evaluate(Random.Range(0f, 1f));
    }

    public void DeleteBubble(GameObject bubble)
    {
        //bubblesList.Remove(bubble);
        //Destroy(bubble);
        PlaceBubble(bubble);
        SetBubbleColor(bubble);
    }
}
