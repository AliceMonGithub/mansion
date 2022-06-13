using System;
using System.Collections;
using UltEvents;
using UniRx;
using UnityEngine;

namespace Codebase.HidingObjectLogic
{
    public class HidingObjectBehavior : MonoBehaviour
    {
        [SerializeField] private bool _inside;
        [SerializeField] private Transform _insidePos;
        [SerializeField] private Transform _outsidePos;
        [SerializeField] private GameObject _hero;

        private CompositeDisposable _disposible;

        public void Interact()
        {
            if (_inside)
            {
                //GetOutside();
                Debug.Log("Вылез");
            }
            else
            { 
                //GetInside();
                Debug.Log("Залез");
            }

            _inside = !_inside;
        }

        //private IEnumerator GetOut2()
        //{
        //    float deltaTime = 0;
        //    Vector3 startPos = _hero.transform.position;
        //    //if (deltaTime >= 1)
        //    //{
        //    //    _hero.transform.position = _insidePos.position;
        //    //    _disposible.Clear();
        //    //}
        //    _hero.transform.position = Vector3.Lerp(startPos, _insidePos.position, deltaTime);

        //    deltaTime += Time.deltaTime;

        //    yield return new WaitForSeconds(1);
        //}


        //private void GetInside()
        //{
        //    float deltaTime = 0;
        //    Vector3 startPos = _hero.transform.position;

        //    Observable.EveryUpdate().Subscribe(action =>
        //    {
        //        if (deltaTime >= 1)
        //        {
        //            _hero.transform.position = _insidePos.position;
        //            _disposible.Clear();
        //        }
        //        _hero.transform.position = Vector3.Lerp(startPos, _insidePos.position, deltaTime);

        //        deltaTime += Time.deltaTime;

        //    }).AddTo(_disposible);

        //    _hero.GetComponent<CharacterController>().enabled = true;
        //}

        //private void GetOutside()
        //{
            //float deltaTime = 0;
            //Vector3 startPos = _insidePos.position;

            //Observable.EveryUpdate().Subscribe(action =>
            //{
            //    if (deltaTime >= 1)
            //    {
            //        _insidePos.position = _outsidePos.position;
            //        _disposible.Clear();
            //    }
            //    _insidePos.position = Vector3.Lerp(startPos, _outsidePos.position, deltaTime);

            //    deltaTime += Time.deltaTime;

            //}).AddTo(_disposible);

            //_hero.GetComponent<CharacterController>().enabled = false;
        //}
    }
}
 
