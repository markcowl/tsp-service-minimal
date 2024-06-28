using PetStore.Service;
using PetStore.Service.Controllers;

namespace PetStore.Controllers
{
    public class PetsController : PetsControllerBase
    {
        internal override IPets PetsImpl => new MyPetsImpl(this);
    }
}
