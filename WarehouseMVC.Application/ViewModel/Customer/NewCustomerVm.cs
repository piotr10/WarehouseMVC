using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using FluentValidation;
using WarehouseMVC.Application.Mapping;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Application.ViewModel.Customer
{//tutaj będziemy przetrzymywać informacje na temat nowych użytkowników czyli będą to inform. wyświetlane na formularzu dodawania nowego użytkownika
    public class NewCustomerVm : IMapFrom<WarehouseMVC.Domain.Model.Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public string REGON { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewCustomerVm, WarehouseMVC.Domain.Model.Customer>().ReverseMap();
        }
    }
    public class NewCustomerValidation : AbstractValidator<NewCustomerVm>
    {
        public NewCustomerValidation()
        {
            RuleFor(x => x.Id).NotNull(); // Id nie może być nullem
            RuleFor(x => x.NIP).Length(10); // NIP powinien być 10 cyfrowy
            RuleFor(x => x.REGON).Length(9, 14); // REGON musi mieścić między 9 a 14
            RuleFor(x => x.Name).MaximumLength(255); // maksymalna nazwa firmy to 255 znaków
        }
    }
}

/*
Jeśli chcesz wyłączyć to zachowanie, aby FluentValidation było jedyną wykonywaną 
biblioteką walidacji, możesz ustawić wartość "RunDefaultMvcValidationAfterFluentValidationExecutes = false" w klasie Startup.
Wtedy Walidacja standardowa od ASP.NET Core będzie wyłączona i tylko FluentValidation będzie działać.
*/
