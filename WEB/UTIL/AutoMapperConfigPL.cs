using AutoMapper;
using BLL.TransferObjects;
using WEB.Models;

namespace WEB_NNINO_2.UTIL
{
    public class AutoMapperConfigPL
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<StudentDTO, StudentViewModel>().ReverseMap();
        }
    }
}