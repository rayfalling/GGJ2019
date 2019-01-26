using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour{
    public GameObject PlatformPrefab;
    public GameObject SpeedPlatformPrefab;
    public GameObject SlowPlatformPrefab;
    public Transform BallPostion;

    public int InitializationPlaforms = 30;
    public float LevelWidth = 1.8f;
    public float MinY = .2f;
    public float MaxY = 1.5f;
    public int SpecialChance = 20;
    public int SpeedGen = 5;
    public int SlowGen = 3;
    public float TotalTime = 10f;

    Vector3 _spawnPosition = new Vector3();
    List<GameObject> _stagesNew = new List<GameObject>();
    List<GameObject> _stagesOld = new List<GameObject>();

    // Start is called before the first frame update
    void Start(){
        for (var i = 0; i < InitializationPlaforms; i++) {
            _spawnPosition.y += Random.Range(MinY, MaxY);
            _spawnPosition.x = Random.Range(-LevelWidth, LevelWidth);
            int special = Random.Range(1, SpecialChance);
            if (special == SpeedGen) {
                _stagesOld.Add(Instantiate(SpeedPlatformPrefab, _spawnPosition, Quaternion.identity, transform));
            }
            else if (special == SlowGen) {
                _stagesOld.Add(Instantiate(SlowPlatformPrefab, _spawnPosition, Quaternion.identity, transform));
            }
            else {
                _stagesOld.Add(Instantiate(PlatformPrefab, _spawnPosition, Quaternion.identity, transform));
            }
        }
    }

    private int _count = 1;

    void Update(){
        if (_spawnPosition.y - BallPostion.transform.position.y < 10.0f) {
            if (_count % 2 == 0)
                GenerateStage(_stagesOld);
            else if (_count % 2 == 1) GenerateStage(_stagesNew);

            _count++;
        }
    }

    void GenerateStage(List<GameObject> gameObjects){
        gameObjects.ForEach(Destroy);
        for (var i = 0; i < InitializationPlaforms; i++) {
            _spawnPosition.y += Random.Range(MinY, MaxY);
            _spawnPosition.x = Random.Range(-LevelWidth, LevelWidth);
            int special = Random.Range(1, 20);
            if (special == SpeedGen) {
                gameObjects.Add(Instantiate(SpeedPlatformPrefab, _spawnPosition, Quaternion.identity, transform));
            }
            else if (special == SlowGen) {
                gameObjects.Add(Instantiate(SlowPlatformPrefab, _spawnPosition, Quaternion.identity, transform));
            }
            else {
                gameObjects.Add(Instantiate(PlatformPrefab, _spawnPosition, Quaternion.identity, transform));
            }
        }
    }
}