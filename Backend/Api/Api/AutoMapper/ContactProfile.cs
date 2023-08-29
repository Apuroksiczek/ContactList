using Application.Models;
using AutoMapper;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.AutoMapper
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactSmallDto>();
            CreateMap<AddNewContactDto, Contact>();
        }
    }
}
