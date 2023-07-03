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
     */
}
