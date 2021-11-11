using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleObjectManager : SingletonParent<SampleObjectManager>
{
    // ** 불렛을 관리하는 리스트
    private List<GameObject> EnableList = new List<GameObject>();
    public List<GameObject> GetEnableList
    {
        get
        {
            return EnableList;
        }
    }

    //티슈처럼 뽑아서 쓸려고 
    private Stack<GameObject> DisableList = new Stack<GameObject>();

    public Stack<GameObject> GetDisableList
    {
        get
        {
            return DisableList;
        }
    }


 

    


}
