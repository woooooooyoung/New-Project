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
     */
}
