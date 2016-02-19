using System;
using System.Collections.Generic;
using Slb.Ocean.Petrel;
using Slb.Ocean.Petrel.UI;
using Slb.Ocean.Petrel.DomainObject.Well;

namespace DigitalSignal
{
    /// <summary>
    /// Summary description for DSPWindow.
    /// </summary>
    public class DSPWindow : ToggleWindow,  IImageInfoSource, INameInfoSource
    {

        private DSPWindowUI control;
        private List<object> visibleObjects;

        public DSPWindow()
        {
            visibleObjects = new List<object>();
        }

        #region ToggleWindow Members

        /// <summary>
        /// This method determines whether the window can show any or all instances 
        /// of the given Type.
        /// </summary>
        /// <param name="domainObjType">the Type of domain object to check</param>
        /// <returns>
        /// "All" if all objects of the given type can be shown,
        /// "Some" if only certain instances of the type can be shown,
        /// "None" if no objects of the type can be shown.
        /// </returns>
        protected override ToggleWindowTypeSupport CanShowTypeCore(Type domainObjType)
        {
            return ToggleWindowTypeSupport.Some;
        }

        /// <summary>
        /// This method determines whether the window can show the given object.
        /// </summary>
        /// <param name="domainObj">the object to check</param>
        /// <returns>true when it can be shown, false when not</returns>
        protected override bool CanShowObjectCore(object domainObj)
        {
            if (domainObj == null || typeof(WellLog) != domainObj.GetType())
                return false;

            return true;
        }

        /// <summary>
        /// This method will be called when the window should show an object.
        /// It raises the VisibleObjects.Changed event when necessary.
        /// </summary>
        /// <param name="domainObj">the object to show in the window</param>
        protected override void ShowObjectCore(object domainObj)
        {
            if (!control.addData)
                return;

            visibleObjects.Add(domainObj);
            control.addSeries((WellLog)domainObj);
            OnVisibleObjectsChanged(VisibilityChangedEventArgs.FromSingleObject(domainObj, VisibilityState.Visible));
        }

        /// <summary>
        /// This method will be called when the window should hide an object.
        /// It raises the VisibleObjects.Changed event when necessary.
        /// </summary>
        /// <param name="domainObj">the object to hide</param>
        protected override void HideObjectCore(object domainObj)
        {
            if (!IsVisible(domainObj))
                return;

            visibleObjects.Remove(domainObj);
            //control.removeSeries(((Borehole)domainObj).Logs.WellLogs);
            control.removeSeries((WellLog)domainObj);
            OnVisibleObjectsChanged(VisibilityChangedEventArgs.FromSingleObject(domainObj, VisibilityState.Hidden));
        }

        /// <summary>
        /// Determines whether or not the given object is currently visualized in the window.
        /// </summary>
        /// <param name="domainObj">the object to check</param>
        /// <returns>true if the object is visible; otherwise false</returns>
        protected override bool IsVisibleCore(object domainObj)
        {
            // TODO: Add implementation to determine if the object is showing

            return visibleObjects.Contains(domainObj);
        }

        /// <summary>
        /// Gets an enumerator containing all of the objects currently visible in this window
        /// </summary>
        /// <returns></returns>
        protected override System.Collections.IEnumerator GetVisibleObjectsEnumeratorCore()
        {
            // TODO: Add implementation to provide the list of visible objects

            return visibleObjects.GetEnumerator();
        }

        /// <summary>
        /// This method will be called to get the actual Control to host in the Petrel Form.
        /// </summary>
        /// <returns>the Control handling visualization for this window</returns>
        protected override System.Windows.Forms.Control CreateControlCore()
        {
            control = new DSPWindowUI();
            return control;
        }

        /// <summary>
        /// This method will be called when the window's Control should be disposed.
        /// </summary>
        protected override void DisposeControlCore()
        {
            control.Dispose();
            control = null;
        }

        #endregion

		#region IImageInfoSource Members

		public ImageInfo ImageInfo
		{
			get { return new DSPWindowImageInfo(); }
		}

		#endregion

		#region INameInfoSource Members

		public NameInfo NameInfo
		{
			get { return new DSPWindowNameInfo(this); }
		}

		#endregion
    }
}