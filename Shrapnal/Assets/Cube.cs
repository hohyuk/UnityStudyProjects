using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] GameObject m_Prefab = null;            // 파편 프리팹 변수
    [SerializeField] float m_force = 0f;                    // 파편이 날아갈 힘
    [SerializeField] Vector3 m_offset = Vector3.zero;       // 파편이 날아갈 위치에 영향을 줄 벡터

    public void Explosion()
    {
        GameObject t_clone = Instantiate(m_Prefab, transform.position, Quaternion.identity);
        Rigidbody[] t_rigids = t_clone.GetComponentsInChildren<Rigidbody>();

        for(int i=0;i<t_rigids.Length;++i)
        {
            t_rigids[i].AddExplosionForce(m_force, transform.position + m_offset, 10f);
        }
        gameObject.SetActive(false);
    }
}
