using PetStore.Models;

namespace PetStoreDemo
{
    internal static class PetUtils
    {
        internal static string GetData(this Pet pet)
        {
            return $"[name: {pet.Name}, id: {pet.Id}, tag: {pet.Tag}, age: {pet.Age}, ownerId: {pet.OwnerId}]";
        }
    }
}
