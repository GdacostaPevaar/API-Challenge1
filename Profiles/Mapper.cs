using AutoMapper;
using Challenge1.Entities;
using Challenge1.Models;

namespace Challenge1.Profiles
{
    public class Mapper:Profile
    {

        public Mapper()
        {
            CreateMap<Producto, ProductoDTO>();

            CreateMap< ProductoDTO, Producto>();



        }
    }
}
