using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwApiNETExample.Managers
{

    public interface IUpdateManager<out T>
    {
        event Updated<T> ManagerUpdate;
    }
    public delegate void Updated<in T>(T colors);
}
