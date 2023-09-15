using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointscript : MonoBehaviour
{
    private RespawnScript respawn;
    private BoxCollider2D checkPointCollider;
    void Awake() {
        checkPointCollider = GetComponent<BoxCollider2D>();   
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            respawn.respawnPoint = this.gameObject;
            checkPointCollider.enabled = false;
        }
    }
}
