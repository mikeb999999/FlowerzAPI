using AutoMapper;
using Flowerz.DataContexts;
using Flowerz.Models;

namespace FlowerzAPI.Services;

public class BloomService: IBloomService
{
    //Define the local variables
    private FlowerzContext _context; // Temp! will be moved to repository layer
    private readonly IMapper _mapper;

    /// <summary> Constructor </summary>
    public BloomService(
        FlowerzContext context,
        IMapper mapper
        )//(IBloomRepository blooms)
    {
        _context = context;
        _mapper = mapper;
        // _blooms = blooms;
    }

    /// <summary> Get all customers matching the filter criteria </summary>
    public async Task<List<Bloom>> GetBlooms()
    {
        //Get the entities
        var entities = _context.Blooms;

        // var entities = await _blooms.GetBlooms();

        //Map the entity to a model
        return _mapper.Map<List<Bloom>>(entities);
    }

    /// <summary> Get the first bloom matching the filter criteria </summary>
    public async Task<Bloom> GetBloom(long id)

    {
        var bloom = _context.Blooms.FirstOrDefault(b => b.Id == id);
        if (bloom == null)
            throw new KeyNotFoundException($"Bloom does not exist for id {id}");
        //....................   return NotFound($"Bloom does not exist for id {id}");
        return _mapper.Map<Bloom>(bloom);
    }

    /// <summary> Create a new bloom </summary>
    public async Task<Bloom> CreateBloom(Bloom model)
    { throw new NotImplementedException(); }

    /// <summary> Update an existing bloom  </summary>
    public async Task<Bloom> UpdateBloom(Bloom model)
    { throw new NotImplementedException(); }

    /// <summary> Delete an existing bloom </summary>
    public async Task<Bloom> DeleteBloom(long bloomId)
    { throw new NotImplementedException(); }
}
