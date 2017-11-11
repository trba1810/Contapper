using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contapper.DAL.Model
{
    public enum  Status
    {
        [Description("Nezainteresovani")]
        NotInterested,
        [Description("Zainteresovani")]
        Interested,
        [Description("Neodredjeni")]
        Indeterminate,
        [Description("Kompenzacija")]
        Compensation,
        [Description("Blok")]
        Block

    }
}
