using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PetStore.Service.Models;
using System.Net;

namespace PetStore.Service
{
    public partial class MyPetsImpl : IPets
    {
        static MyPetsImpl()
        {
            
            _data.Add(new Pet { Age = 3, Id = 0, Name = "Fluffy", OwnerId = 2, Tag = "fluffy0" });
            _data.Add(new Pet { Age = 5, Id = 1, Name = "Spot", OwnerId = 10, Tag = "Spot1" });
            _data.Add(new Pet { Age = 7, Id = 2, Name = "Whiskers", OwnerId = 10, Tag = "Whiskers2" });
            foreach (var pet in _data)
            {
                _store[pet.Id] = pet;
            }
        }
        public MyPetsImpl(HttpContext context)
        {
            Context = context;
        }

        internal HttpContext Context { get; }
        static IDictionary<int, Pet> _store { get; } = new Dictionary<int, Pet>();
        static IList<Pet> _data { get; } = new List<Pet>();
        public Task<PetCreationResult> CreateAsync(PetCreate resource)
        {
            var existing = _data.FirstOrDefault(p => string.Equals(p.Name, resource.Name, StringComparison.OrdinalIgnoreCase));
            var created = false;
            Context.Response.StatusCode = 200;
            if (existing == null)
            {
                Context.Response.StatusCode = 201;
                existing = new Pet { Id = _data.Count + 1 };
                _data.Add(existing);
                _store[existing.Id] = existing;
                created = true;
            }

            existing.Name = resource.Name;
            existing.OwnerId = resource.OwnerId;
            existing.Age = resource.Age;
            existing.Tag = resource.Tag;
            return Task.FromResult(new PetCreationResult(existing, created));
        }

        public Task DeleteAsync(int petId)
        {
            if (!_store.ContainsKey(petId))
            {
                return Task.CompletedTask;
            }
            else
            {
                var existing = _store[petId]!;
                _data.Remove(existing);
                _store.Remove(petId);
                return Task.CompletedTask;
            }
        }

        public Task<Pet> GetAsync(int petId)
        {
            if (!_store.ContainsKey(petId))
            {
                throw new BadHttpRequestException($"{petId} does not exist", 404);
            }

            return Task.FromResult(_store[petId]!);
        }

        public Task<PetCollectionWithNextLink> ListAsync()
        {
            var result = new PetCollectionWithNextLink
            {
                Value = _data.ToArray(),
                NextLink = null
            };

            Context.Response.StatusCode = 200;
            return Task.FromResult(result);
        }

        public Task<Pet> UpdateAsync(int petId, PetUpdate properties)
        {
            if (!_store.ContainsKey(petId))
            {
                throw new BadHttpRequestException($"{petId} does not exist", 404);
            }
            Context.Response.StatusCode = 200;
            var existing = _store[petId]!;
            if (!string.IsNullOrEmpty(properties.Name))
            {
                existing.Name = properties.Name;
            }
            if(properties.OwnerId.HasValue)
            {
                existing.OwnerId = properties.OwnerId.Value;
            }
            if (properties.Age.HasValue)
            {
                existing.Age = properties.Age.Value;
            }
            if (!string.IsNullOrEmpty(properties.Tag))
            {
                existing.Tag = properties.Tag;
            }

            return Task.FromResult(existing);
        }
    }
}
