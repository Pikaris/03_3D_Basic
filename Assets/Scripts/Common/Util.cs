using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    // 피셔-ㅇ
    public static void Shuffle<T>(T[] source)
    {
        for(int i = source.Length -1; i> 1; i--)                        // i는 마지막부터 0까지 진행
        {
            int index = Random.Range(0, i + 1);                         // 최대값 포함하기 위해 +1
            (source[index], source[i]) = (source[i], source[index]);    // 마지막 것과 스왑하기
        }
    }
}
