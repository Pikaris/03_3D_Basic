using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ForestGenerator : MonoBehaviour
{
    // 여러개의 나무 프리팹을 가진다.
    // forestGenerate가 true가 되면 generateCenter위치가 중심이고 가로가 width, 세로가 height인 사각형 영역 안의 랜덤한 위치에
    // treeCount만큼의 type 타입의 나무를 생성한다.(생성된 나무는 Randomize 실행)
    // 생성 영역은 Gizmos로 표시한다.

    /// <summary>
    /// 생성 버튼 역할을 할 bool
    /// </summary>
    public bool forestGenerate = false;

    /// <summary>
    /// 리셋 버튼 역할을 할 bool
    /// </summary>
    public bool reset = false;

    /// <summary>
    /// 나무 프리팹들(TreeType과 개수와 순서가 맞아야 한다.)
    /// </summary>
    public GameObject[] treePrefabs;

    /// <summary>
    /// 나무 종류 표시용 enum
    /// </summary>
    public enum TreeType
    {
        Tree1,
        Tree2
    }

    /// <summary>
    /// 생성할 나무의 종류
    /// </summary>
    public TreeType type = TreeType.Tree1;

    /// <summary>
    /// 나무 생성 영역 가로 크기
    /// </summary>
    public float width = 10.0f;
    
    /// <summary>
    /// 나무 생성 영역 세로 크기
    /// </summary>
    public float height = 10.0f;

    /// <summary>
    /// 나무 생성 영역 중심점 설정용 트랜스폼
    /// </summary>
    Transform generateCenter;

    /// <summary>
    /// 한번에 생성할 나무 개수
    /// </summary>
    public int treeCount = 10;

    /// <summary>
    /// 생성된 나무들의 부모가 될 transform
    /// </summary>
    Transform trees;

    [Space(10)]
    [Tooltip("일련 번호용(리셋할 때 제외하고 수정 금지)")]
    /// <summary>
    /// 일련 번호용(리셋할 때 제외하고 수정 금지)
    /// </summary>
    public int serialNumber = 0;

    private void Awake()
    {
        generateCenter = transform.GetChild(0);
        trees = transform.GetChild(1);
    }

    private void OnValidate()
    {
        if (forestGenerate)
        {
            GenerateTrees();        // forestGenerate가 눌려지면 나무 생성
            forestGenerate = false;
        }

        if (reset)
        {
            ResetTrees();
            reset = false;
        }
    }

    /// <summary>
    /// 시리얼 넘버만 리셋
    /// </summary>
    private void ResetTrees()
    {
        //if(trees == null)
        //{
        //    trees = transform.GetChild(1);
        //}

        //while (trees.childCount > 0)
        //{
        //    Transform del = trees.GetChild(0);
        //    Destroy(del.gameObject);
        //    //del.SetParent(null);        // Destroy가 즉시 되는 것은 아니기 때문에 일단 tress의 자식에서 뺀다.
        //}

        //for(int i = 0; i < trees.childCount; i++)
        //{
        //    Transform del = trees.GetChild(0);
        //    DestroyImmediate(del.gameObject); // 이래도 안됨
        //}
        serialNumber = 0;
    }

    void GenerateTrees()
    {
        // 필요한 트랜스폼 찾기
        if (generateCenter == null)
        {
            generateCenter = transform.GetChild(0);
        }
        if (trees == null)
        {
            trees = transform.GetChild(1);
        }

        // 생성 영역 최소/최대 구하기
        Vector3 min = generateCenter.position + new Vector3(-width * 0.5f, 0, -height * 0.5f);
        Vector3 max = generateCenter.position + new Vector3(width * 0.5f, 0, height * 0.5f);

        // 개수만큼 나무 생성하기
        for (int i = 0; i < treeCount; i++)
        {
            GameObject tree = Instantiate(treePrefabs[(int)type], trees);   // 생성하고
            tree.transform.position = new Vector3(Random.Range(min.x, max.x), tree.transform.position.y, Random.Range(min.z, max.z));   // 생성 영역 안에 배치하기
            tree.name = $"{treePrefabs[(int)type].name}_{serialNumber}";
            serialNumber++;


            ObjectRandomize objectRandomize = tree.GetComponent<ObjectRandomize>();
            objectRandomize.Randomize();
        }
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (generateCenter == null)
        {
            generateCenter = transform.GetChild(0);
        }

        Vector3 p0 = generateCenter.position + new Vector3(-width * 0.5f, 0, -height * 0.5f);
        Vector3 p1 = generateCenter.position + new Vector3(width * 0.5f, 0, -height * 0.5f);
        Vector3 p2 = generateCenter.position + new Vector3(width * 0.5f, 0, height * 0.5f);
        Vector3 p3 = generateCenter.position + new Vector3(-width * 0.5f, 0, height * 0.5f);

        Gizmos.color = Color.red;   // 나무 생성 영역 그리기
        Gizmos.DrawLine(p0, p1);
        Gizmos.DrawLine(p1, p2);
        Gizmos.DrawLine(p2, p3);
        Gizmos.DrawLine(p3, p0);
    }
#endif


}
