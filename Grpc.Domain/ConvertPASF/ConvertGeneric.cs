using AutoMapper;
using DomainInfo.ConvertPASF.Contracts;

namespace DomainInfo.ConvertPASF
{
    public class ConvertGeneric<TDestiny, TOrigin>: IConvertGeneric<TDestiny>
    {
        private readonly Mapper _mapper;
        private readonly TOrigin _objectConvert;

        public ConvertGeneric(TOrigin convert)
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
                cfg.CreateMap<TOrigin, TDestiny>());

            _mapper = new Mapper(mapperConfiguration);
            _objectConvert = convert;
        }

        public TDestiny Convert()
        { 
            return _mapper.Map<TDestiny>(_objectConvert);
        }
    }
}