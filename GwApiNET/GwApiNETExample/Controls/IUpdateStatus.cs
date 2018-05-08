using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwApiNETExample.Controls
{

    public interface IUpdateStatus
    {
        event StatusChangeEvent StatusChanged;
        string Status { get; }
        string Description { get; }
    }

    public delegate void StatusChangeEvent(string status);
}
