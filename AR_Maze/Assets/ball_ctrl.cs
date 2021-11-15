using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ball_ctrl : MonoBehaviour
{
    public GameObject plane;
    public GameObject spawn_point;
    public GameObject Finish;
    public ParticleSystem particle;
    public GameObject resetVB;

    // Start is called before the first frame update
    void Start()
    {
        //spawn_point.transform.position = this.transform.position;

        resetVB.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
    }

    // Update is called once per frame
    void Update()
    {
        // 오류제거 시작 후 부터 움직일 수 있게(처음엔 kinematic상태로)
        if (Time.deltaTime > 1.0f)
            transform.GetComponent<Rigidbody>().isKinematic = false;

        // 바닥으로 떨어질 때 초기화
        if (transform.position.y < plane.transform.position.y - 10)
        {
            transform.position = spawn_point.transform.position;
            Debug.Log("Reset");
        }


    }

    // 목표지점에 도착하면 파티클 효과 발생
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Finish)
        {
            ParticleSystem particleSystem1 = Instantiate(particle, this.gameObject.transform);

            Debug.Log("clear!");
        }
    }

    // Virtual Button 기반 초기화
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        transform.position = spawn_point.transform.position;
        Debug.Log("Hard Reset");
    }
}
