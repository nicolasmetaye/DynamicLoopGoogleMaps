﻿using System.Collections.Generic;
using AutoMapper;
using DynamicLoopGoogleMaps.Domain;
using DynamicLoopGoogleMaps.Models.Models;

namespace DynamicLoopGoogleMaps.Models.Mapping.Profiles
{
    public class AuthorMap : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Author, AuthorModel>()
                .ForMember(model => model.IsEditMode, expression => expression.Ignore());
            Mapper.CreateMap<Author, AuthorListItemModel>()
                .ForMember(model => model.FullName, expression => expression.ResolveUsing(author => author.FirstName + " " + author.LastName));
            Mapper.CreateMap<IEnumerable<Author>, AuthorsListModel>()
                .ForMember(model => model.Authors, expression => expression.ResolveUsing(authors => authors))
                .ForMember(model => model.SuccessMessage, expression => expression.Ignore());
            Mapper.CreateMap<AuthorModel, Author>();
        }
    }
}