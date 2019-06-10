using AutoMapper;
using DBRepostitory.Models;
using DBRepostitory.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BussinessLogic.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {

            Mapper.Initialize(cfg => {
                cfg.CreateMap<List<Customers>, List<CustomerViewModel>>();
                cfg.CreateMap<Customers, CustomerViewModel>();
            });
        }

    }
}