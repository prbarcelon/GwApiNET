using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GwApiNETExample.Controls;

namespace GwApiNETExample
{

    internal class UpdateStatusHelper
    {
        public static void OnStatusUpdate(IUpdateStatus sender, string status, StatusChangeEvent handler)
        {
            if (handler != null)
            {
                handler(status);
            }
        }

        /// <summary>
        /// Used to verify if a property is changing.
        /// If a property is changing, then the <see cref="OnPropertyChanged"/> and <see cref="OnPropertyChanging"/>
        /// will be called.
        /// </summary>
        /// <typeparam name="T">Type of the object being checked</typeparam>
        /// <param name="oldValue">previous property value</param>
        /// <param name="newValue">new property value</param>
        /// <returns></returns>
        public static bool CheckStatusChanged(string oldValue, string newValue)
        {
            if (oldValue == null && newValue == null)
                return false;

            if ((oldValue == null && newValue != null) || !oldValue.Equals(newValue))
                return true;

            return false;
        }
    }
}
