using AutoMapper;
using CMS.Models.EntityModels;
using CMS.Models.ViewModels;
using CMS.Models.ViewModels.CreateViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace CMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<CMS.Models.Contexts.CMSContext>(null);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.CreateMap<Board, BoardViewModel>();
            Mapper.CreateMap<Thread, ThreadViewModel>();
            Mapper.CreateMap<Post, PostViewModel>();

            Mapper.CreateMap<CreateBoardViewModel, Board>();
            Mapper.CreateMap<CreatePageViewModel, Page>();

            Mapper.CreateMap<string, SelectListItem>()
                .ForMember(item => item.Text, x => x.MapFrom(s => s))
                .ForMember(item => item.Value, x => x.MapFrom(s => s));
            Mapper.CreateMap<MembershipUser, SelectListItem>()
                .ForMember(item => item.Text, x => x.MapFrom(m => m.UserName.ToUpper()))
                .ForMember(item => item.Value, x => x.MapFrom(m => m.UserName.ToUpper()));
        }
    }
}
