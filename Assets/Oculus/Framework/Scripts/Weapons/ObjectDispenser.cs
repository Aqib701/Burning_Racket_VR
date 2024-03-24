using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG {


    /// <summary>
    /// This is an example of how to spawn ammo depending on the weapon that is equipped in the opposite hand
    /// </summary>
    public class ObjectDispenser : MonoBehaviour {

        /// <summary>
        /// Used to determine if holding a weapon
        /// </summary>
        public Grabber LeftGrabber;

        /// <summary>
        /// Used to determine if holding a weapon
        /// </summary>
        public Grabber RightGrabber;

        /// <summary>
        /// Disable this if weapon not equipped
        /// </summary>
        public GameObject DispenserObject;

       
        public GameObject MainGrabObject;
        //void Update() {
        //    bool weaponEquipped = false;

        //    if (grabberHasWeapon(LeftGrabber) || grabberHasWeapon(RightGrabber)) {
        //        weaponEquipped = true;
        //    }

        //    // Only show if we have something equipped
        //    if(SwordDispenserObject.activeSelf != weaponEquipped) {
        //        SwordDispenserObject.SetActive(weaponEquipped);
        //    }
        //}

        //bool grabberHasWeapon(Grabber g) {

        //    if(g == null || g.HeldGrabbable == null) {
        //        return false;
        //    }

        //    // Holding shotgun, pistol, or rifle
        //    string grabName = g.HeldGrabbable.transform.name;
        //    if (grabName.Contains("Shotgun") || grabName.Contains("Pistol") || grabName.Contains("Rifle")) {
        //        return true;
        //    }

        //    return false;
        //}

     

        public void GrabObject(Grabber grabber) {

            GameObject ammo = Instantiate(MainGrabObject, grabber.transform.position, grabber.transform.rotation) as GameObject;
            Grabbable g = ammo.GetComponent<Grabbable>();

            //// Disable rings for performance
            //GrabbableRingHelper grh = ammo.GetComponentInChildren<GrabbableRingHelper>();
            //if (grh) {
            //    Destroy(grh);
            //    RingHelper r = ammo.GetComponentInChildren<RingHelper>();
            //    Destroy(r.gameObject);
            //}


            // Offset to hand
            ammo.transform.parent = grabber.transform;
            ammo.transform.localPosition = -g.GrabPositionOffset;
            ammo.transform.parent = null;

            grabber.GrabGrabbable(g);
        }
    }
}

