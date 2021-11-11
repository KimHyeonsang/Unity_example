using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleObjectManager : SingletonParent<SampleObjectManager>
{
    // ** �ҷ��� �����ϴ� ����Ʈ
    private List<GameObject> EnableList = new List<GameObject>();
    public List<GameObject> GetEnableList
    {
        get
        {
            return EnableList;
        }
    }

    //Ƽ��ó�� �̾Ƽ� ������ 
    private Stack<GameObject> DisableList = new Stack<GameObject>();

    public Stack<GameObject> GetDisableList
    {
        get
        {
            return DisableList;
        }
    }


 

    


}
