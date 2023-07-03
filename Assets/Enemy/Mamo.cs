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
     * 
     * 
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
     */


}
