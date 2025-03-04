// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Threading;

namespace PetStore
{
    // Data plane generated client.
    /// <summary> The PetStore service client. </summary>
    public partial class PetStoreClient
    {
        private readonly ClientPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual ClientPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of PetStoreClient for mocking. </summary>
        protected PetStoreClient()
        {
        }

        /// <summary> Initializes a new instance of PetStoreClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public PetStoreClient(Uri endpoint) : this(endpoint, new PetStoreClientOptions())
        {
        }

        /// <summary> Initializes a new instance of PetStoreClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public PetStoreClient(Uri endpoint, PetStoreClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new PetStoreClientOptions();

            _pipeline = ClientPipeline.Create(options, Array.Empty<PipelinePolicy>(), Array.Empty<PipelinePolicy>(), Array.Empty<PipelinePolicy>());
            _endpoint = endpoint;
        }

        private Pets _cachedPets;
        private PetCheckups _cachedPetCheckups;
        private PetInsurance _cachedPetInsurance;
        private Toys _cachedToys;
        private ToyInsurance _cachedToyInsurance;
        private Checkups _cachedCheckups;
        private Owners _cachedOwners;
        private OwnerCheckups _cachedOwnerCheckups;
        private OwnerInsurance _cachedOwnerInsurance;

        /// <summary> Initializes a new instance of Pets. </summary>
        public virtual Pets GetPetsClient()
        {
            return Volatile.Read(ref _cachedPets) ?? Interlocked.CompareExchange(ref _cachedPets, new Pets(_pipeline, _endpoint), null) ?? _cachedPets;
        }

        /// <summary> Initializes a new instance of PetCheckups. </summary>
        public virtual PetCheckups GetPetCheckupsClient()
        {
            return Volatile.Read(ref _cachedPetCheckups) ?? Interlocked.CompareExchange(ref _cachedPetCheckups, new PetCheckups(_pipeline, _endpoint), null) ?? _cachedPetCheckups;
        }

        /// <summary> Initializes a new instance of PetInsurance. </summary>
        public virtual PetInsurance GetPetInsuranceClient()
        {
            return Volatile.Read(ref _cachedPetInsurance) ?? Interlocked.CompareExchange(ref _cachedPetInsurance, new PetInsurance(_pipeline, _endpoint), null) ?? _cachedPetInsurance;
        }

        /// <summary> Initializes a new instance of Toys. </summary>
        public virtual Toys GetToysClient()
        {
            return Volatile.Read(ref _cachedToys) ?? Interlocked.CompareExchange(ref _cachedToys, new Toys(_pipeline, _endpoint), null) ?? _cachedToys;
        }

        /// <summary> Initializes a new instance of ToyInsurance. </summary>
        public virtual ToyInsurance GetToyInsuranceClient()
        {
            return Volatile.Read(ref _cachedToyInsurance) ?? Interlocked.CompareExchange(ref _cachedToyInsurance, new ToyInsurance(_pipeline, _endpoint), null) ?? _cachedToyInsurance;
        }

        /// <summary> Initializes a new instance of Checkups. </summary>
        public virtual Checkups GetCheckupsClient()
        {
            return Volatile.Read(ref _cachedCheckups) ?? Interlocked.CompareExchange(ref _cachedCheckups, new Checkups(_pipeline, _endpoint), null) ?? _cachedCheckups;
        }

        /// <summary> Initializes a new instance of Owners. </summary>
        public virtual Owners GetOwnersClient()
        {
            return Volatile.Read(ref _cachedOwners) ?? Interlocked.CompareExchange(ref _cachedOwners, new Owners(_pipeline, _endpoint), null) ?? _cachedOwners;
        }

        /// <summary> Initializes a new instance of OwnerCheckups. </summary>
        public virtual OwnerCheckups GetOwnerCheckupsClient()
        {
            return Volatile.Read(ref _cachedOwnerCheckups) ?? Interlocked.CompareExchange(ref _cachedOwnerCheckups, new OwnerCheckups(_pipeline, _endpoint), null) ?? _cachedOwnerCheckups;
        }

        /// <summary> Initializes a new instance of OwnerInsurance. </summary>
        public virtual OwnerInsurance GetOwnerInsuranceClient()
        {
            return Volatile.Read(ref _cachedOwnerInsurance) ?? Interlocked.CompareExchange(ref _cachedOwnerInsurance, new OwnerInsurance(_pipeline, _endpoint), null) ?? _cachedOwnerInsurance;
        }
    }
}
