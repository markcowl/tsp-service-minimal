using PetStore;
using PetStore.Models;
using System.ClientModel;

namespace PetStoreDemo
{
    public class PetMenu
    {
        public Pets Client { get; }
        public PetMenu(PetStoreClient client)
        {
            Client = client.GetPetsClient();
        }

        static T Prompt<T>(string prompt)
        {
            Console.WriteLine();
            Console.WriteLine(prompt);
            Console.CursorVisible = true;
            return (T)Convert.ChangeType(Console.ReadLine(), typeof(T))!;
        }

        static T PromptKey<T>(string prompt)
        {
            Console.WriteLine();
            Console.Write($"{prompt} >");
            Console.CursorVisible = true;
            T result =  (T)Convert.ChangeType($"{Console.ReadKey().KeyChar}", typeof(T));
            Console.WriteLine();
            return result;
        }

        public void Dispatch()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Pet Store Menu");
                Console.WriteLine("1. Create a pet");
                Console.WriteLine("2. List pets");
                Console.WriteLine("3. Update a pet");
                Console.WriteLine("4. Delete a pet");
                Console.WriteLine("5. Exit");
                Console.WriteLine();
                Console.WriteLine();
                var choice = PromptKey<int>("Enter your choice");
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        CreatePet();
                        break;
                    case 2:
                        ListPets();
                        break;
                    case 3:
                        UpdatePet();
                        break;
                    case 4:
                        DeletePet();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        private void HoldForUser()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void DeletePet()
        {
            var toDelete = SelectOne("delete");
            try
            {
                var result = Client.Delete(toDelete.Id);
                Console.WriteLine($"Deleted Pet \"{toDelete.Name}\"");
            }
            catch (ClientResultException client)
            {
                var response = client.GetRawResponse();
                Console.WriteLine($"{response?.Status}: {response?.Content.ToString()}");
                Console.WriteLine($"Caught exception: {client.Message}");
            }

            HoldForUser();
        }

        private void UpdatePet()
        {
            var toUpdate = SelectOne("update");
            Console.WriteLine($"Updating Pet \"{toUpdate.GetData()}\"");
            var newTag = Prompt<string>("Enter the new tag for the pet:");
            try
            {
                var result = Client.Update(toUpdate.Id, BinaryContent.Create(new BinaryData($"{{\"tag\": \"{newTag}\"}}")));
                Console.WriteLine($"Updated Pet \"{toUpdate.Name}\" with new tag \"{newTag}\"");
            }
            catch (ClientResultException client)
            {
                var response = client.GetRawResponse();
                Console.WriteLine($"{response?.Status}: {response?.Content.ToString()}");
                Console.WriteLine($"Caught exception: {client.Message}");
            }

            HoldForUser();
        }

        private Pet SelectOne(string action)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine($"Select a pet to {action}");
                var pets = ListPetsImpl().ToDictionary(p => p.Key, p => p.Value);
                foreach (var pet in pets)
                {
                    Console.WriteLine($"{pet.Key}. {pet.Value.GetData()}");
                }
                Console.WriteLine();
                var choice = PromptKey<int>("Enter your choice");
                if (pets.ContainsKey(choice))
                {
                    return pets[choice];
                }

                Console.WriteLine($"Invalid choice {choice}");
                Console.WriteLine();
            }
        }

        private void StartCollectionAction()
        {
            Console.Clear();
            Console.WriteLine("Current Pets");
            foreach (var pet in ListPetsImpl())
            {
                Console.WriteLine(pet.Value.GetData());
            }

            Console.WriteLine();
        }
        private void ListPets()
        {
            StartCollectionAction();
            HoldForUser();
        }

        private IEnumerable<KeyValuePair<int, Pet>> ListPetsImpl()
        {
            var pets = Client.GetPets().Value.Value;
            for (int i = 0; i < pets?.Count; ++i)
            {
                yield return new KeyValuePair<int, Pet>(i+1, pets[i]);
            }
        }

        public void CreatePet()
        {
            StartCollectionAction();
            Console.WriteLine("Create a Pet");
            var name = Prompt<string>("Enter the name of the pet:");
            var age = Prompt<int>("Enter the age of the pet:");
            var ownerId = 1;
            try
            {
                var result = Client.Create(new PetCreate(name, age, ownerId)).Value;
                Console.WriteLine($"Created Pet {result.GetData()}");
            }
            catch (ClientResultException client)
            {
                var response = client.GetRawResponse();
                Console.WriteLine($"{response?.Status}: {response?.Content.ToString()}");
                Console.WriteLine($"Caught exception: {client.Message}");
            }

            HoldForUser();
        }
    }
}
