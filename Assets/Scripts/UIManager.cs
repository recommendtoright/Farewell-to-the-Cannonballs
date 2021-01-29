using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instanse;
    public GameObject bulletBar;
    // Start is called before the first frame update
    private void Awake()
    {
        //判断当前UI是否存在
        if (instanse == null)
            instanse = this;
        else
            Destroy(gameObject);//删除当前
    }
    
    public void UpdateBulletNum(float Bnum)
    {
        switch (Bnum)
        {
            case 3:
                bulletBar.transform.GetChild(0).gameObject.SetActive(true);
                bulletBar.transform.GetChild(1).gameObject.SetActive(true);
                bulletBar.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 2:
                bulletBar.transform.GetChild(0).gameObject.SetActive(true);
                bulletBar.transform.GetChild(1).gameObject.SetActive(true);
                bulletBar.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 1:
                bulletBar.transform.GetChild(0).gameObject.SetActive(true);
                bulletBar.transform.GetChild(1).gameObject.SetActive(false);
                bulletBar.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 0:
                bulletBar.transform.GetChild(0).gameObject.SetActive(false);
                bulletBar.transform.GetChild(1).gameObject.SetActive(false);
                bulletBar.transform.GetChild(2).gameObject.SetActive(false);
                break;
            
            
        }
    }
}
