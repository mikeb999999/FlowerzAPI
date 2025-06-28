using AutoMapper;

using Flowerz.Persistence.Entities;

namespace Flowerz.Persistence.Mapper
{
    public class AutoMapperProfile : Profile
    {
        #region Constructors

        public AutoMapperProfile()
        {
            //Create mapping for the entities and models
            this.CreateMappings<Bloom, Flowerz.Models.Bloom>();

            //Generate the custom mappings
            // N/A
        }

        #endregion

        #region Methods

        // N/A

        #endregion

        #region Helpers

        /// <summary> Generate a mapping between the entity types </summary>
        private void CreateMappings<TEntity, TModel>()
        {
            //Create the model to entity AND entity to model mapping
            this.CreateMap<TModel, TEntity>().ReverseMap();

            //Create the model to model mapping
            this.CreateMap<TModel, TModel>();

            //Create the entity to entity mapping
            this.CreateMap<TEntity, TEntity>();
        }

        #endregion
    }
}
