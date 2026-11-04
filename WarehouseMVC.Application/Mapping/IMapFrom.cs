using AutoMapper;
using System.Collections.Generic;
using System;
using System.Text;

namespace WarehouseMVC.Application.Mapping
{
    public interface IMapFrom<T>
    {
        //wywołanie metody Mapping w jakiejś klasie spowoduje utworzenie mapy na podstawie profilu z obiektu profile
        //wewnętrznej klasy Profile z AutoMappera
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}