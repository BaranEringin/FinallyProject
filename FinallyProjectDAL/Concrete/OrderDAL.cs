﻿using ETrade.Business.Concrete;
using FinallyProjectDAL.Abstract;
using FinallyProjectDATA.Context;
using FinallyProjectDATA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallyProjectDAL.Concrete
{
    public class OrderDAL : GenericRepository<Order, Context>, IOrderDAL
    {
    }
}
