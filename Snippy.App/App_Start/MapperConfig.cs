using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Snippy.App.Models.BindingModels;
using Snippy.App.Models.ViewModels;
using Snippy.Models;

namespace Snippy.App.App_Start
{
    public class MapperConfig
    {
        public static void CreateMappings()
        {
            Mapper.CreateMap<Label, ConciseLabelViewModel>()
                .ForMember(viewModel => viewModel.Snippets, config => config.MapFrom(label => label.Snippets.Count));
            
            Mapper.CreateMap<Comment, ConciseCommentViewModel>()
                .ForMember(viewModel => viewModel.Author, config => config.MapFrom(comment => comment.Author.UserName));

            Mapper.CreateMap<Snippet, ConciseSnippetViewModel>();

            Mapper.CreateMap<Snippet, DetailSnippetView>()
                .ForMember(viewModel => viewModel.Author, config => config.MapFrom(snippet => snippet.Author.UserName));

            Mapper.CreateMap<Label, LabelDetailsViewModel>();

            Mapper.CreateMap<Language, LanguageViewModel>();

            Mapper.CreateMap<Snippet, SnippetBindingModel>()
                .ForMember(bindModel => bindModel.LanguageId, config => config.MapFrom(snippet => snippet.Language.Id));
        }
    }
}