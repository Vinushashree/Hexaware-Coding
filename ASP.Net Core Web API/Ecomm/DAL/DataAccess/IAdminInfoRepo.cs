﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface IAdminInfoRepo<T>
    {
        T ValidateAdmin(T adminInfo);
    }
}
