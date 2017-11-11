using Contapper.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contapper
{
    public static class EnumConverter
    {
        public static Status ConvertToStatusEnum(object value)
        {
            var status = (string)value;

            switch (status)
            {
                case "Interested":
                    return Status.Interested;
                case "NotInterested":
                    return Status.NotInterested;
                case "Indeterminate":
                    return Status.Indeterminate;
                case "Compensation":
                    return Status.Compensation;
                case "Block":
                    return Status.Block;
            }
            return Status.NotInterested;
        }
    }
}
