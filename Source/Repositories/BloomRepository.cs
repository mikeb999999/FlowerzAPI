using AutoMapper;
using Flowerz.DataContexts;
using Flowerz.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
namespace FlowerzAPI.Repositories
{
    public class BloomRepository : IBloomRepository
    {
        private readonly FlowerzContext _context; 

       /// Constructor
       public BloomRepository(FlowerzContext context)
        { 
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        /// <summary> Get all blooms </summary>
        Task<List<Bloom>> IBloomRepository.GetBlooms()
        {
            return Task.FromResult(_context.Blooms.ToList<Bloom>());
        }

        /// <summary> Get the requested bloom by id </summary>
        Task<Bloom?> IBloomRepository.GetBloom(long bloomId)
        {
            var theBloom = _context.Blooms.FirstOrDefault(x => x.Id == bloomId);
            return Task.FromResult(theBloom);
        }

        /// <summary> Create a new bloom </summary>
        Task<Bloom> IBloomRepository.CreateBloom(Bloom model)
        {
            throw new NotImplementedException();
        }

        /// <summary> Update an existing bloom  </summary>
        Task<Bloom> IBloomRepository.UpdateBloom(Bloom model)
        {
            throw new NotImplementedException();
        }

        /// <summary> Delete an existing bloom </summary>
        Task<Bloom> IBloomRepository.DeleteBloom(long bloomId)
        {
            throw new NotImplementedException();
        }
    }
}
