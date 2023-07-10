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
     * activeInHierarchy    : ���� ������Ʈ�� ��Ȱ��ȭ���� Ȯ���ϴ� ���� !�� ���̸� Ȱ��ȭ���� Ȯ��
     * <Stack>
     * Stack�� ���Լ���(LIFO, Last-In-First-Out) ������� �����մϴ�.
     * ���ο� ��Ҹ� ������ �� ���� �߰��ϰ�, ���ÿ��� ��Ҹ� ������ ���� ���� �ֱٿ� �߰��� ��Һ��� ���ŵ˴ϴ�.
     * Push() �޼��带 ����Ͽ� ��Ҹ� �߰��ϰ�, Pop() �޼��带 ����Ͽ� ��Ҹ� �����մϴ�.
     * ����: ���ο� ����� �߰� �� ���Ű� ��������� ������, �ֱٿ� �߰��� ��ҿ� �� �������� �۾��� ������ �� �����մϴ�.
     * ����: ���� ���� �߰� ��ҿ� �����ϰų� �����ϱ� ��ƽ��ϴ�.
     * 
     * <Queue>
     * Queue�� ���Լ���(FIFO, First-In-First-Out) ������� �����մϴ�.
     * ���ο� ��Ҹ� ť�� ���� �߰��ϰ�, ť���� ��Ҹ� ������ ���� ���� ó���� �߰��� ��Һ��� ���ŵ˴ϴ�.
     * Enqueue() �޼��带 ����Ͽ� ��Ҹ� �߰��ϰ�, Dequeue() �޼��带 ����Ͽ� ��Ҹ� �����մϴ�.
     * ����: ����� �߰� �� ���Ű� ��������� ������, ���������� ��ҿ� ������ �� �����մϴ�.
     * ����: ť ���� �߰� ��ҿ� �����ϰų� �����ϱ� ��ƽ��ϴ�.
     * 
     * <List>
     * List�� ��Ҹ� ������� �����ϴ� ���� �迭�Դϴ�.
     * ��Ҹ� �����ϰų� ������ �� ������, ��ҿ� �ε����� ���� ������ ���� �ֽ��ϴ�.
     * Add() �޼��带 ����Ͽ� ��Ҹ� �߰��ϰ�, Remove() �޼��带 ����Ͽ� ��Ҹ� �����մϴ�.
     * ����: ��ҿ� �ε����� ���� ���� ���� �� ������ �����ϸ�, �߰� ��ҿ� ���� ����/���� �۾��� ���� �����ϴ�.
     * ����: ����� ����/������ �迭�� ũ�� ������ ���� �۾��� �����ϹǷ� ������ ���ϵ� �� �ֽ��ϴ�.
     * ������ �ڷᱸ���� Ư�� ��Ȳ�̳� �䱸���׿� �°� �����Ͽ� ����� �� �ֽ��ϴ�. ���� ���, ������Ʈ Ǯ�������� �Ϲ������� Queue�̳� List�� ����Ͽ� ��Ȱ��ȭ�� ������Ʈ���� �����ϰ�, 
     * �ʿ��� �� Ȱ��ȭ�Ͽ� ����մϴ�. Stack�� Ư�� ��Ȳ�� ������ �� ������, ������Ʈ Ǯ���� ���������� ���Ǵ� ���� �� �����ϴ�. 
     * ������ �ڷᱸ���� �ش� ������Ʈ�� �䱸���װ� ���ɿ� ���� �޶��� �� �ֽ��ϴ�.
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
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * IPointerEnterHandler - OnPointerEnter - �����Ͱ� ������Ʈ�� �� �� ȣ��˴ϴ�.
     * IPointerExitHandler - OnPointerExit - �����Ͱ� ������Ʈ���� ���� �� ȣ��˴ϴ�.
     * IPointerDownHandler - OnPointerDown - �����Ͱ� ������Ʈ ������ ������ �� ȣ��˴ϴ�.
     * IPointerUpHandler - OnPointerUp - �����͸� �� �� ȣ��˴ϴ�(���� �ִ� ������Ʈ���� ȣ��˴ϴ�).
     * IPointerClickHandler - OnPointerClick - ���� ������Ʈ���� �����͸� ������ �� �� ȣ��˴ϴ�.
     * IInitializePotentialDragHandler - OnInitializePotentialDrag - �巡�� Ÿ���� �߰ߵǾ��� �� ȣ��˴ϴ�. ���� �ʱ�ȭ�ϴ� �� ����� �� �ֽ��ϴ�.
     * IBeginDragHandler - OnBeginDrag - �巡�װ� ���۵Ǵ� ������ �巡�� ��� ������Ʈ���� ȣ��˴ϴ�.
     * IDragHandler - OnDrag - �巡�� ������Ʈ�� �巡�׵Ǵ� ���� ȣ��˴ϴ�.
     * IEndDragHandler - OnEndDrag - �巡�װ� ������� �� �巡�� ������Ʈ���� ȣ��˴ϴ�.
     * IDropHandler - OnDrop - �巡�׸� ������ �� �ش� ������Ʈ���� ȣ��˴ϴ�.
     * IScrollHandler - OnScroll - ���콺 ���� ��ũ������ �� ȣ��˴ϴ�.
     * IUpdateSelectedHandler - OnUpdateSelected - ������ ������Ʈ���� �� ƽ���� ȣ��˴ϴ�.
     * ISelectHandler - OnSelect - ������Ʈ�� �����ϴ� ���� ȣ��˴ϴ�.
     * IDeselectHandler - OnDeselect - ������ ������Ʈ�� ���� ������ �� ȣ��˴ϴ�.
     * IMoveHandler - OnMove - �̵� �̺�Ʈ(����, ������, ����, �Ʒ��� ��)�� �߻����� �� ȣ��˴ϴ�.
     * ISubmitHandler - OnSubmit - ���� ��ư�� ������ �� ȣ��˴ϴ�.
     * ICancelHandler - OnCancel - ��� ��ư�� ������ �� ȣ��˴ϴ�.
     *
     *
     *
     */


}
