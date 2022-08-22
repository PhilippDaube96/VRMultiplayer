using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
//using Unity.XR.CoreUtils;
//using Microsoft.MixedReality.Toolkit;

public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    private PhotonView photonView;

    private Transform headRig;
    private Transform rightHandRig;
    private Transform leftHandRig;
    // Start is called before the first frame update
    void Start()
    {
       photonView = GetComponent<PhotonView>(); 

        //XROrigin origin = FindObjectOfType<XROrigin>();
        //headRig = origin.transform.Find("MainCamera");
        //rightHandRig = origin.transform.Find("MainCamera/RightHand Controller");
        //leftHandRig = origin.transform.Find("MainCamera/LeftHand Controller");
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            rightHand.gameObject.SetActive(false);
            leftHand.gameObject.SetActive(false);
            head.gameObject.SetActive(false);

            MapPosition(head, XRNode.Head);
            MapPosition(leftHand, XRNode.LeftHand);
            MapPosition(rightHand, XRNode.RightHand);

            //MapPosition(head,headRig);
            //MapPosition(leftHand, leftHandRig);
            //MapPosition(rightHand, rightHandRig);
        }
        
    }

     void MapPosition(Transform target,XRNode node)
    //void MapPosition(Transform target, Transform rigTransform)
    {
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

        target.position = position;
        target.rotation = rotation;

        //target.position = rigTransform.position;
        //target.rotation = rigTransform.rotation;
    }
}
