using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mamo : MonoBehaviour
{

    /* <NavMeshAgent>
     * SetDestination           : ������ ��ǥ����
     * remainingDistance        : NavMeshAgent�� ������ ���������� ���� �Ÿ��� ��ȯ.(ó���� ���� �����̱� ������ �׻� 0�� ��ȯ�Ѵ�. ���� �� ĳ���Ͱ� �̵� ���̶�� ���ǵ� �Բ� �Ǵ��ؾ� �Ѵ�.)
     * velocity                 : �ӵ��� �ǹ���. �� �Ӽ��� ũ��� �̵� ���θ� �Ǵ��Ѵ�.
     * velocity.sqrMagnitude    : �� �� ���� �Ÿ��� ���� �� ����Ѵ�. ������ ������ ����ϴ� Vector3.Distance ���� ������ ����.
     * stoppingDistance         : �����Ÿ�
     * 
     * 
     * <Rigidbody>
     * velocity        : �ӵ�
     * angularVelocity : ȸ��
     * 
     * <IEnumerator>
     * yield return null                        : ���� �����ӱ��� ���
     * yield return new WaitForSeconds(flaot)   : ������ �� ��ŭ ���
     * yield return new WaitFixedUpdate()       : ���� FixedUpdate ���� ���
     * yield return new WaitForEndOfFrame()     : ��� ������ �۾��� ���� ������ ���
     * yield return startCoroutiune(string)     : �ٸ� �ڷ�ƾ�� ���� ������ ���
     * yield return new www(string)             : �� ��� �۾��� ���� ������ ���
     * yield return new AsyncIoeration          : �񵿱� �۾��� ���� ������ ���( �� �ε�);
     * yield break                              : return�� ����.
     * 
     * 
     * <objectPool>
     * Pop     : ��ü Ǯ���� ������Ʈ ��������
     * Push    : ��ü�� ��ȯ�Ͽ� ��ü Ǯ�� ����
     * Release : ��ü�� ��ü Ǯ�� ��ȯ�Ͽ� ��Ȱ�� �����ϵ��� ����
     * 
     * <Time>
     * deltaTime            : ������ ���� ��� �ð��� �����մϴ�. 
     * realtimeSinceStartup : ���� ���ۺ����� ���� ��� �ð��������մϴ�. 
     *                      * ������ ���۵� �� ����� ���� �ð��� ��Ÿ���ϴ�. 
     *                      * �̸� �̿��Ͽ� ������ ��� �ð��� �����ϰų� Ÿ�̸� ���� ������ �� �ֽ��ϴ�.
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
     * Animator�� GetCurrentAnimatorStateInfo �Լ��� ���ؼ� ���� ����ǰ� �ִ� �ִϸ��̼��� ���¸� üũ�� �� �ֽ��ϴ�.
     * if (!PlayerMovement.instance.anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
     *   {
     *       PlayerMovement.instance.anim.SetBool("Attack", false);
     *       PlayerMovement.instance.anim.SetBool("Walk", false);
     *       PlayerMovement.instance.anim.SetBool("Idle", true);
     *   }
     * ���� �ڵ��� ���ǹ��� PlayerMovement�� �ִϸ����Ϳ� ���� ����ǰ� �ִ� �ִϸ��̼��� �̸��� Idle�� �ƴ϶�� ���ǹ� ������ ���� �Ǿ��ֽ��ϴ�.
     * ���� ����ǰ� �ִ� �ִϸ��̼��� �������� �� �� �ִ� ���� GetCurrentAnimatorStateInfo.IsName �Դϴ�.
     * if (PlayerMovement.instance.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
     *   {
     *       //�ϰ� ���� ����
     *   }
     * ���� �ڵ忡�� normalizedTime = 1�� ���� ���� ����ǰ� �ִ� �ִϸ��̼��� ��� ����Ǿ��ٴ� ���̰�,  normalizedTime = 0�� �ִϸ��̼��� ���� �������� �ʾҴٴ� ���� ���մϴ�.
     * �̷��� GetCurrentAnimatorStateInfo�� ���ؼ� ���� ����ǰ��ִ� �ִϸ��̼��� ������ ������ �� �ֽ��ϴ�.
     */


}
