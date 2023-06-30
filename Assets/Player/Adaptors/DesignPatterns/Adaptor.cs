using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern
{
    //========================================
    //##		������ ���� Adaptor  		##
    //========================================
    /*
        ����� ���� :
        ȣȯ���� ���� �� ��ü�� ������ �� �ֵ��� �߰� �Ű�ü�� �����ϴ� ����
        ���� :
        1. ȣȯ���� �ʴ� �� ��ü ���̿� ����� �߰� ��ü�� ����
        2. ����� ��ü�� �� ��ü ������ ��ȣ�ۿ� ����� ���
        ���� :
        1. ������ �ڵ带 �������� �ʰ� ������ �����ϹǷ� ������� ��Ģ�� �ؼ��ȴ�.
        2. Ŭ�������� ��ȣ�ۿ뿡 ���� ���踦 ����͸� ���� �������� ������ �� �����Ƿ� ������������ ��Ģ�� �ؼ��ȴ�.
        ���� :
        1. �������̽��� ���� �������� �����Ƿ� �������̽��� �������� ���� �� �ִ� �������� ���� ���Ѵ�.
    */
    public class DollarCustomer
    {
        public Exchanger exchanger;

        public void Buy()
        {
            Debug.Log("���Ǳ���");
            exchanger.Change();
        }
    }

    public class KRWStore
    {
        public Exchanger exchanger;

        public void Sell()
        {
            Debug.Log("�����Ǹ�");
        }
    }

    public class Exchanger
    {
        public DollarCustomer customer;
        public KRWStore store;

        public void Change()
        {
            store.Sell();
        }
    }
}
