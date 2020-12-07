using AutoMapper;
using BookStoreAPI.DTOS;
using BookStoreAPI.Mdels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<PublisherDTO, Publisher>();
        }
    }
}
