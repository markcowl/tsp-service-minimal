using System;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using PetStore.Service.Models;
using PetStore.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection.Metadata.Ecma335;


namespace PetStore.Service
{
    public class PetCreationResult
    {
        public PetCreationResult( Pet pet, bool created) 
        {
            Pet = pet;
            Created = created;
        }

        public Pet Pet { get; set; }
        public bool Created { get; set; }
    }
    public abstract class PetApi
    {
        internal abstract IPets GetPetsImpl(HttpContext context);

        public static void Register(WebApplication app, Func<PetApi> constructor)
        {
            var api = constructor();
            api.RegisterGet(app);
            api.RegisterUpdate(app);
            api.RegisterCreate(app);
            api.RegisterDelete(app);
            api.RegisterList(app);
        }

        internal void RegisterGet(WebApplication app)
        {
            app.MapGet("/pets/{petId}", Get);
        }

        public virtual async Task<Results<BadRequest<PetStoreError>, Ok<Pet>>> Get(HttpContext context, int petId)
        {
            var impl = GetPetsImpl(context);
            var result = await impl.GetAsync(petId);
            return TypedResults.Ok(result);
        }

        internal void RegisterUpdate(WebApplication app)
        {
            app.MapPatch("/pets/{petId}", Update);
        }
 
        public virtual async Task<Results<BadRequest<PetStoreError>, Ok<Pet>>> Update(HttpContext context, int petId, [FromBody]PetUpdate body)
        {
            var impl = GetPetsImpl(context);
            var result = await impl.UpdateAsync(petId, body);
            return TypedResults.Ok(result);
        }

        internal void RegisterDelete(WebApplication app)
        {
            app.MapDelete("/pets/{petId}", Delete);
        }
        
        public virtual async Task<Results<BadRequest<PetStoreError>, Ok>> Delete(HttpContext context, int petId)
        {
            var impl = GetPetsImpl(context);
            await impl.DeleteAsync(petId);
            return TypedResults.Ok();
        }

        internal void RegisterCreate(WebApplication app)
        {
            app.MapPost("/pets", Create);
        }

        ///<summary>
        /// Creates a new instance of the resource.
        ///</summary>
        public virtual async Task<Results<BadRequest<PetStoreError>, Ok<Pet>, Created<Pet>>> Create(HttpContext context, [FromBody]PetCreate body)
        {
            var impl = GetPetsImpl(context);
            var result = await impl.CreateAsync(body);
            switch (result.Created)
            {
                case true:
                    return TypedResults.Created($"/pets/{result.Pet.Id}", result.Pet);
                case false:
                    return TypedResults.Ok(result.Pet);
            }
        }

        internal void RegisterList(WebApplication app)
        {
            app.MapGet("/pets", List);
        }

        ///<summary>
        /// Lists all instances of the resource.
        ///</summary>
        public virtual async Task<Results<BadRequest<PetStoreError>, Ok<PetCollectionWithNextLink>>> List(HttpContext context)
        {
            var impl = GetPetsImpl(context);
            var result = await impl.ListAsync();
            return TypedResults.Ok(result);
        }
    }
}
