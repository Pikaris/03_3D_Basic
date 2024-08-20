using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

// interface
// 클래스가 상속 받을 수 있다.(개수 제한이 없다)
// 변수는 없다
// 함수는 선언만 있다(반드시 별도의 구현이 필요하다.)

public class Test_UI : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // IPointerClickHandler를 상속 받았기 때문에 이 UI에서 클릭이 있을 때마다 OnPointerClick함수가 실행된다.
    }
}
