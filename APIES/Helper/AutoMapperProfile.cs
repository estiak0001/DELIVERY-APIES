
using APIES.Models.Users;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<CoreUserInfo, UserModel>();
            //CreateMap<RegisterModel, CoreUserInfo>();
            //CreateMap<UpdateModel, CoreUserInfo>();
            //CreateMap<CoreUserInfo, CoreUserInfoDto>();

            ////Manual Attendence

            //CreateMap<HrmAtdManualDto, HrmAtdManual>();
            //CreateMap<HrmAtdManual, HrmAtdManualDto>();

            //CreateMap<HrmAtdMachineData_Dto, HrmAtdMachineData>();
            //CreateMap<HrmAtdMachineData, HrmAtdMachineData_Dto>();
        }
    }
}
   