using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    public float maxDistance;
    public float distance;
    [SerializeField] Transform player;
    [SerializeField] GameObject icon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);
        icon.SetActive(distance < maxDistance);
    }
}
