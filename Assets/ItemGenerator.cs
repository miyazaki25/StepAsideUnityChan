using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;

    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //ユニティちゃんのz軸
    private float UnityChanPosz;
    // アイテムのの生成間隔
    private float span = 0.8f;
    // 時間計測用の変数
    private float delta = 0;
    //ゴールポジション
    private float goalPos;

    void Start()
    {
        goalPos = GameObject.Find("Goal").transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        // span秒以上の時間が経過したかを調べる
        if (this.delta > this.span)
        {
            this.delta = 0;
            //ユニティちゃんのz軸を取得
            UnityChanPosz = GameObject.Find("unitychan").transform.position.z;

            //ユニティちゃんがゴールよりz軸が70手前の場合
            if (UnityChanPosz < goalPos - 70 )
            {
                //どのアイテムを出すのかをランダムに設定
                int num = Random.Range(1, 11);
                if (num <= 2)
                {
                    //コーンをx軸方向に一直線に生成
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab) as GameObject;
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, UnityChanPosz + 60);
                    }
                }
                else
                {

                    //レーンごとにアイテムを生成
                    for (int j = -1; j <= 1; j++)
                    {
                        //アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        //アイテムを置くZ座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-5, 6);
                        //60%コイン配置:30%車配置:10%何もなし
                        if (1 <= item && item <= 6)
                        {
                            //コインを生成
                            GameObject coin = Instantiate(coinPrefab) as GameObject;
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, UnityChanPosz + 60 + offsetZ);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            //車を生成
                            GameObject car = Instantiate(carPrefab) as GameObject;
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, UnityChanPosz + 60 + offsetZ);
                        }
                    }
                }
            }
        }    
    }



}

