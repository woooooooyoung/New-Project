using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purpose2 : MonoBehaviour
{
    /* 클래스 다이어그램이란
     * 
     * 클래스 다이어그램 내부의
     * 클래스
     *  가장 윗부분 : 클래스 이름
     *  중간 부분 : 속성(변수)
     *  마지막 부분 : 연산(함수)
     * 
     * 접근 제어자   표시   설명
     * Public
     * Private
     * 
     * 
     * 
     * 클래스 다이어그램
     * 관계
     *  클래스 다이어그램에서 제공하는 클래스들 사이의 관계
     *  관계                              표시              설명
     *  연관 관계   (Association)                        (A has B) 클래스글이 개념상 서로 연결되었음을 나타냄, 보통은 한 클래스가 다른 클래스에서 제공하는 기능을 사용하는 상황일 때
     *  의존 관계   (Dependency)                         (A use B) 연관 관계와 같이 한 클래스가 다른 클래스에서 제골하는 기능을 사용할 때 나타냄, 차이점은 사용하는 동안 짧은 시간만 유지된다는 점
     *  일반화 관계 (Generalization)                     (A is B ) 상속 관계 한 클래스가 다른 클래스를 포함하는 상위 개념일 때
     *  실체화 관계 (Realization)                        (A can B) 인터페이스 관계 책임들을 실제로 구현한 클래스들 사이의 관계를 나타냄
     *  합성 관계   (Composition)                                  클래스들 사이의 전체 또는 부분 같은 관계를 나타냄, 전체 객체의 라이프 타임과 부분 객체의 라이프 타임이 의존적 (전체 객체가 사라지면 부분 객체도 사라짐)
     *  집약 관계   (Aggregation)                                  클래스들 사이의 전체 또는 부분 같은 관계를 나타냄, 전체 객체의 라이프 타임과 부분 객체의 라이프 타임이 독립적 (전체 객체가 사라져도 부분 객체는 사라지지 않음)
     *  
     * 상태 다이어그램
     *  상태 다이어그램이란? 
     *  소프트웨어가 작동할 때 발생하는 프로세스를 시각적으로 표현, 반응적인 성격을 가지는 객체의 행동을 상태로 표현한 것
     * 
     * 상태 다이어그램 구성요소
     * 구성요소     표시                  설명
     * 상태        State   객체가 존재할 수 있는 조건 중 하나 객체가 가질 수 있는 모든 가늘한 경우가 상태로 파악되어야 함 객체는 특정 순산에는 오직 한 상태로만 존재할 수 있음 둥근 모서리를 가진 사각형의 안쪽 상단에 상태 이름 기술
     * 시작          ●     상태의 시작 지점, 상태로 연경되어 있으며, 시작을 ㅗ연결된 전이는 없음, 빨간 테두리에 검은색 원
     * 끝           ◎     상태의 마지막 지점
     * 전이
     * 
     * 플로우 차트
     *  작업을 어떤 순서로 진행하는지 표시해주는 시각적 표현
     *  플로우 차트를 통해 세부 기획을 들어가기 전 빠르고 명확하게 프로세스를 확인할 수 있음
     *  복잡한 구조를 그림으로 표현하기 때문에 다른 사람이 보더라도 쉽게 이해할 수 있음
     *                                          - NO-> 천천히 간다
     * Start --> 운전을 한다 --> 도로가 막히는가?                   --> 주요소에 간다 --> STOP
     *                                          -YES-> 빨리간다
     * 
     * UI 와이어프레임
     * 웹 또는 앱 프로젝트를 진행할 ㄸ깨 필요한 과정 중 하나로 화면 구조를 제안하기 위한 화면 설계도
     * 즉 디자인이 들어가기 전 단계에서, 선(wire)을 이용하여 윤곽선(frame)을 잡는 것을 의미
     * 디자인의 컨셉, 고객의 요구사항, 콘텐츠들의 기능 요소를
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     */
}
