using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    private float minSpeed = 8;
    private float maxSpeed = 12;
    private float mTorque = 10;
    private float SpawnX = 4;
    private float SpawnY = 2;
    public int point;
    public ParticleSystem explosionParticle;
    public Rigidbody targetRb;
    public GameManager gManager;

    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(Vector3.up * Random.Range(minSpeed,maxSpeed), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(-mTorque,mTorque),Random.Range(-mTorque,mTorque), Random.Range(-mTorque,mTorque),ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-SpawnX,SpawnX),SpawnY); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if(gManager.isGameActive)
        {
        Destroy(gameObject);
        Instantiate(explosionParticle,transform.position, explosionParticle.transform.rotation);
        gManager.UpdateScore(point);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad")){
           gManager.gameOver(); 
        }
    }
}
