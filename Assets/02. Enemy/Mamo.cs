using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mamo : MonoBehaviour
{

    /* <NavMeshAgent>
     * SetDestination           : 도달할 목표지정
     * remainingDistance        : NavMeshAgent에 지정된 목적지까지 남은 거리를 반환.(처음엔 정지 상태이기 때문에 항상 0을 반환한다. 따라서 적 캐릭터가 이동 중이라는 조건도 함께 판단해야 한다.)
     * velocity                 : 속도를 의미함. 이 속성의 크기로 이동 여부를 판단한다.
     * velocity.sqrMagnitude    : 두 점 간의 거리를 구할 때 사용한다. 복잡한 수식을 사용하는 Vector3.Distance 보다 성능이 좋다.
     * stoppingDistance         : 제동거리
     * 
     * 
     * <Rigidbody>
     * velocity        : 속도
     * angularVelocity : 회전
     * 
     * <IEnumerator>
     * yield return null                        : 다음 프레임까지 대기
     * yield return new WaitForSeconds(flaot)   : 지정한 초 만큼 대기
     * yield return new WaitFixedUpdate()       : 다음 FixedUpdate 까지 대기
     * yield return new WaitForEndOfFrame()     : 모든 랜더링 작업이 끝날 때까지 대기
     * yield return startCoroutiune(string)     : 다른 코루틴이 끝날 때까지 대기
     * yield return new www(string)             : 웹 통신 작업이 끝날 때까지 대기
     * yield return new AsyncIoeration          : 비동기 작업이 끝날 때까지 대기( 씬 로딩);
     * yield break                              : return과 같다.
     * 
     * 
     * <objectPool>
     * Pop     : 객체 풀에서 오브젝트 가져오기
     * Push    : 객체를 반환하여 객체 풀에 저장
     * Release : 객체를 객체 풀로 반환하여 재활용 가능하도록 설정
     * 
     * <Time>
     * deltaTime            : 프레임 간의 경과 시간을 누적합니다. 
     * realtimeSinceStartup : 게임 시작부터의 실제 경과 시간을누적합니다. 
     *                      * 게임이 시작된 후 경과한 실제 시간을 나타냅니다. 
     *                      * 이를 이용하여 게임의 경과 시간을 추적하거나 타이머 등을 구현할 수 있습니다.
     * activeInHierarchy    : 게임 오브젝트가 비활성화인지 확인하는 조건 !를 붙이면 활성화인지 확인
     * <Stack>
     * Stack은 후입선출(LIFO, Last-In-First-Out) 방식으로 동작합니다.
     * 새로운 요소를 스택의 맨 위에 추가하고, 스택에서 요소를 제거할 때는 가장 최근에 추가된 요소부터 제거됩니다.
     * Push() 메서드를 사용하여 요소를 추가하고, Pop() 메서드를 사용하여 요소를 제거합니다.
     * 장점: 새로운 요소의 추가 및 제거가 상대적으로 빠르며, 최근에 추가된 요소에 더 집중적인 작업을 수행할 때 유용합니다.
     * 단점: 스택 내의 중간 요소에 접근하거나 수정하기 어렵습니다.
     * 
     * <Queue>
     * Queue는 선입선출(FIFO, First-In-First-Out) 방식으로 동작합니다.
     * 새로운 요소를 큐의 끝에 추가하고, 큐에서 요소를 제거할 때는 가장 처음에 추가된 요소부터 제거됩니다.
     * Enqueue() 메서드를 사용하여 요소를 추가하고, Dequeue() 메서드를 사용하여 요소를 제거합니다.
     * 장점: 요소의 추가 및 제거가 상대적으로 빠르며, 순차적으로 요소에 접근할 때 유용합니다.
     * 단점: 큐 내의 중간 요소에 접근하거나 수정하기 어렵습니다.
     * 
     * <List>
     * List는 요소를 순서대로 저장하는 동적 배열입니다.
     * 요소를 삽입하거나 삭제할 수 있으며, 요소에 인덱스를 통해 접근할 수도 있습니다.
     * Add() 메서드를 사용하여 요소를 추가하고, Remove() 메서드를 사용하여 요소를 제거합니다.
     * 장점: 요소에 인덱스를 통한 빠른 접근 및 수정이 가능하며, 중간 요소에 대한 삽입/삭제 작업이 비교적 빠릅니다.
     * 단점: 요소의 삽입/삭제가 배열의 크기 조정과 복사 작업을 동반하므로 성능이 저하될 수 있습니다.
     * 각각의 자료구조는 특정 상황이나 요구사항에 맞게 선택하여 사용할 수 있습니다. 예를 들어, 오브젝트 풀링에서는 일반적으로 Queue이나 List를 사용하여 비활성화된 오브젝트들을 관리하고, 
     * 필요할 때 활성화하여 사용합니다. Stack은 특정 상황에 유용할 수 있지만, 오브젝트 풀링에 직접적으로 사용되는 경우는 더 적습니다. 
     * 선택할 자료구조는 해당 프로젝트의 요구사항과 성능에 따라 달라질 수 있습니다.
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * <Animator>
     * Animator의 GetCurrentAnimatorStateInfo 함수를 통해서 현재 진행되고 있는 애니메이션의 상태를 체크할 수 있습니다.
     * if (!PlayerMovement.instance.anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
     *   {
     *       PlayerMovement.instance.anim.SetBool("Attack", false);
     *       PlayerMovement.instance.anim.SetBool("Walk", false);
     *       PlayerMovement.instance.anim.SetBool("Idle", true);
     *   }
     * 위의 코드의 조건문은 PlayerMovement의 애니메이터에 현재 진행되고 있는 애니메이션의 이름이 Idle이 아니라면 조건문 안으로 들어가게 되어있습니다.
     * 현재 진행되고 있는 애니메이션이 무엇인지 볼 수 있는 것이 GetCurrentAnimatorStateInfo.IsName 입니다.
     * if (PlayerMovement.instance.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
     *   {
     *       //하고 싶은 동작
     *   }
     * 위의 코드에서 normalizedTime = 1의 뜻은 현재 진행되고 있는 애니메이션이 모두 진행되었다는 것이고,  normalizedTime = 0은 애니메이션이 아직 시작하지 않았다는 것을 뜻합니다.
     * 이렇게 GetCurrentAnimatorStateInfo를 통해서 현재 진행되고있는 애니메이션의 정보를 가져올 수 있습니다.
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * IPointerEnterHandler - OnPointerEnter - 포인터가 오브젝트에 들어갈 때 호출됩니다.
     * IPointerExitHandler - OnPointerExit - 포인터가 오브젝트에서 나올 때 호출됩니다.
     * IPointerDownHandler - OnPointerDown - 포인터가 오브젝트 위에서 눌렸을 때 호출됩니다.
     * IPointerUpHandler - OnPointerUp - 포인터를 뗄 때 호출됩니다(눌려 있던 오브젝트에서 호출됩니다).
     * IPointerClickHandler - OnPointerClick - 동일 오브젝트에서 포인터를 누르고 뗄 때 호출됩니다.
     * IInitializePotentialDragHandler - OnInitializePotentialDrag - 드래그 타겟이 발견되었을 때 호출됩니다. 값을 초기화하는 데 사용할 수 있습니다.
     * IBeginDragHandler - OnBeginDrag - 드래그가 시작되는 시점에 드래그 대상 오브젝트에서 호출됩니다.
     * IDragHandler - OnDrag - 드래그 오브젝트가 드래그되는 동안 호출됩니다.
     * IEndDragHandler - OnEndDrag - 드래그가 종료됐을 때 드래그 오브젝트에서 호출됩니다.
     * IDropHandler - OnDrop - 드래그를 멈췄을 때 해당 오브젝트에서 호출됩니다.
     * IScrollHandler - OnScroll - 마우스 휠을 스크롤했을 때 호출됩니다.
     * IUpdateSelectedHandler - OnUpdateSelected - 선택한 오브젝트에서 매 틱마다 호출됩니다.
     * ISelectHandler - OnSelect - 오브젝트를 선택하는 순간 호출됩니다.
     * IDeselectHandler - OnDeselect - 선택한 오브젝트를 선택 해제할 때 호출됩니다.
     * IMoveHandler - OnMove - 이동 이벤트(왼쪽, 오른쪽, 위쪽, 아래쪽 등)가 발생했을 때 호출됩니다.
     * ISubmitHandler - OnSubmit - 전송 버튼이 눌렸을 때 호출됩니다.
     * ICancelHandler - OnCancel - 취소 버튼이 눌렸을 때 호출됩니다.
     *
     *
     *
     */


}
