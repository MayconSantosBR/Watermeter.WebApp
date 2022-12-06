using AutoMapper;

namespace Watermetter.Models
{
    public class MapperService
    {
        public MapperService()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile<OwnerProfile>();
            });

            configuration.CreateMapper();
        }
    }
}
