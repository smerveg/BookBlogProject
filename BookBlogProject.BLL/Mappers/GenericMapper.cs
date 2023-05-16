using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.BLL.Mappers
{
    public static class GenericMapper<TSource,TDestination>
    {
        private static Mapper _mapper = new Mapper(new MapperConfiguration
            (cfg => cfg.CreateMap<TSource, TDestination>().ReverseMap()));

        public static TDestination Map(TSource source)
        {
            return _mapper.Map<TDestination>(source);
    }
    }

    
}
