using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux.ORT2.Enums
{

    /// <summary>
    /// Contains enums for all ORT page 
    /// </summary>

    public enum ORTMenu
    {
        Reports,
        Analysis,
        ContactSupport,
        Default,
    };

    public enum TableAReports
    {

    };

    public enum ReportStatus
    {
        InProgress,
        Certified,
        Verified,
        Locked,
        Submitted,
        Default,
    };
}
