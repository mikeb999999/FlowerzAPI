using AutoMapper;
using Flowerz.Models;
using FlowerzAPI.Repositories;

namespace FlowerzAPI.Services;

public class BloomService : IBloomService
{
    //Define the local variables
    private readonly IBloomRepository _blooms;
    private readonly IMapper _mapper;

    /// <summary> Constructor </summary>
    public BloomService(
        IBloomRepository blooms,
        IMapper mapper )
    {
        _blooms = blooms;
        _mapper = mapper;
    }

    /// <summary> Get the requested bloom by id  </summary>
    public async Task<List<Bloom>> GetBlooms()
    {
       var entities = await _blooms.GetBlooms();

        //Map the entity to a model
        return _mapper.Map<List<Bloom>>(entities);
    }

    /// <summary> Get the requested bloom by id  </summary>
    public async Task<Bloom> GetBloom(long id)

    {
        var entity = await _blooms.GetBloom(id);
        if (entity == null)
            throw new KeyNotFoundException($"Bloom does not exist for id {id}");
        ;
        return _mapper.Map<Bloom>(entity);
    }

    /// <summary> Create a new bloom </summary>
    public async Task<Bloom> CreateBloom(Bloom bloom)
    { throw new NotImplementedException(); }
    //{
    //    // TODO use return values for errors, bad form to throw exceptions for it
    //    if (bloom == null)
    //       throw new ValidationException("No bloom specified - can't create");
    //    if (bloom.Id != 0)
    //        throw new ValidationException("Id must be 0 when creating a bloom");

    //    //Generate a new entity 
    //    var entity = _mapper.Map<Bloom>(bloom);

    //    //Create the entity
    //    entity = await _blooms.CreateCustomer(entity);

    //    var maxId = _context.Blooms.Max(b => b.Id);
    //    var newBloom = new Bloom() { Id = maxId + 1, Name = bloom.Name, Description = bloom.Description };
    //    _context.Blooms.Add(newBloom);
    //    _context.SaveChanges();
    //    //return data;
    //    return Ok(newBloom);
    //}

    /// <summary> Update an existing bloom  </summary>
    public async Task<Bloom> UpdateBloom(Bloom model)
    { throw new NotImplementedException(); }

    /// <summary> Delete an existing bloom </summary>
    public async Task<Bloom> DeleteBloom(long bloomId)
    { throw new NotImplementedException(); }
}
