
namespace PetStore.Service
{
    public class MyPetApi : PetApi
    {
        internal override IPets GetPetsImpl(HttpContext context)
        {
            return new MyPetsImpl(context);
        }
    }
}
