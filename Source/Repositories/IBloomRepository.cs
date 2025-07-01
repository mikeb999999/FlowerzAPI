using Flowerz.Persistence.Entities;

namespace FlowerzAPI.Repositories;

public interface IBloomRepository
{
    /// <summary> Get all blooms </summary>
    Task<List<Bloom>> GetBlooms();

    /// <summary> Get the requested bloom by id </summary>
    Task<Bloom?> GetBloom(long bloomId);

    /// <summary> Create a new bloom </summary>
    Task<Bloom> CreateBloom(Bloom model);

    /// <summary> Update an existing bloom  </summary>
    Task<Bloom> UpdateBloom(Bloom model);

    /// <summary> Delete an existing bloom </summary>
    Task<Bloom> DeleteBloom(long bloomId);
}
