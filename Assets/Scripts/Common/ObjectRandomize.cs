using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRandomize : MonoBehaviour
{
    /// <summary>
    /// 클릭 할 때 마다 외형 리롤하는 것이 목적인 변수
    /// </summary>
    public bool reroll = true;

    [Range(0, 0.5f)]
    /// <summary>
    /// 랜덤 정도
    /// </summary>
    public float randomizeRange = 0.15f;

    // 인스펙터 창에서 값이 성공적으로 변경되었을 때 실행되는 이벤트 함수
    private void OnValidate()
    {
        if(reroll)
        {
            //Debug.Log($"OnValidata - {gameObject.name}");
            Randomize();
            reroll = false;
        }
    }

    public void Randomize()
    {
        transform.localScale = new Vector3(
            1 + Random.Range(-randomizeRange, randomizeRange),      // +-randomizeRange 정도씩 스케일
            1 + Random.Range(-randomizeRange, randomizeRange),
            1 + Random.Range(-randomizeRange, randomizeRange));

        transform.Rotate(0, Random.Range(0, 360), 0);   // y축 랜덤 회전
    }
}
