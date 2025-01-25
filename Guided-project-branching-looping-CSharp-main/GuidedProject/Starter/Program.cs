// the ourAnimals array will store the following: 
using System.ComponentModel;

string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";
decimal decimalDonation = 0.00m;

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 7];

// TODO: Convert the if-elseif-else construct to a switch statement

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            suggestedDonation = "85.00";
            break;
        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "gus";
            suggestedDonation = "49.99";
            break;
        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            suggestedDonation = "40.00";
            break;
        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "3";
            animalPhysicalDescription = "Medium sized, long hair, yellow, female, about 10 pounds. Uses litter box.";
            animalPersonalityDescription = "A people loving cat that likes to sit on your lap.";
            animalNickname = "Lion";
            suggestedDonation = "";
            break;
        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
    if (!decimal.TryParse(suggestedDonation, out decimalDonation))
    {
        decimalDonation = 45.00m;
    }
    ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
}

do
{
    // display the top-level menu options

    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    switch (menuSelection)
    {
        case "1": 
            //List all of our current pet information
            for(int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "2":
            //Add a new animal friend to the ourAnimals array
            int petCount = 0;
            string anotherPet = "y";
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i,0] != "ID #: ")
                {
                    petCount += 1;
                }
            }
            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes.  We can manage {(maxPets - petCount)} more.");
            }
            while (anotherPet == "y" && petCount < maxPets)
            {
                bool validEntry = false;
                //get species (cat or dog) - string animalSpecies is a required field
                do 
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry.");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                        animalSpecies = readResult.ToLower();
                    if (animalSpecies != "dog" && animalSpecies != "cat")
                        validEntry = false;
                    else
                        validEntry = true;
                } while (validEntry == false);
                //build the animal ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();
                //get the pet's age. Can be ? at initial entry.
                validEntry = false;
                do {
                    int petAge;
                    Console.WriteLine("\n\rEnter pet age.");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                        animalAge = readResult;
                    if (animalAge != "?")
                        validEntry = int.TryParse(animalAge, out petAge);
                    else 
                        validEntry = true;
                } while (validEntry == false);
                //get the description of the pet's physical appearance/condition - animalPhysicalAppearance can be blank.
                do {
                    Console.WriteLine("\n\rEnter a physical description of the pet (size, color, gender, weight, housebroken).");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                        animalPhysicalDescription = readResult.ToLower();
                    if (animalPhysicalDescription == "")
                        animalPhysicalDescription = "tbd";
                } while (animalPhysicalDescription == "");
                //get the description of the pet's personality - animalPersonalityDescription can be blank
                do {
                    Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                        animalPersonalityDescription = readResult.ToLower();
                    if (animalPersonalityDescription == "")
                        animalPersonalityDescription = "tbd";
                } while (animalPersonalityDescription == "");
                //get the pet's nickname. animalNickname can be blank. 
                do {
                    Console.WriteLine("Enter a nickname for the pet");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                        animalNickname = readResult.ToLower();
                    if (animalNickname == "")
                        animalNickname = "tbd";
                } while (animalNickname == "");
                //store the pet informatiom in the ourAnimals array (zero based)
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;
                //increment petCount (the array is zero-based so we increment the counter after adding to the array)
                petCount++;
                //check maxPet limit
                if (petCount < maxPets)
                {
                    //another pet? 
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    do 
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }
                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }
            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }
            break;
        case "3":
            //Ensure animal ages and physical descriptions are complete
            //iterate through entries
            for (int i = 0; i < maxPets; i++)
            {
                bool validEntry = false;
                if (ourAnimals[i, 0] == "ID #: ")
                {
                    continue;
                }
                if (ourAnimals[i, 2] == "Age: " || ourAnimals[i, 2] == "Age: ?")
                {
                    string message = $"Enter an age for {ourAnimals[i, 0]}";
                    do {
                        int petAge;
                        // if age is default value, prompt for value
                        Console.WriteLine(message);
                        readResult = Console.ReadLine();
                        if (readResult != null)
                            animalAge = readResult;
                            // validate value
                            validEntry = int.TryParse(animalAge, out petAge);
                            if (validEntry)
                            {
                                ourAnimals[i, 2] = "Age: " + petAge;
                            }
                            else
                            {
                                message = $"Please enter a valid number for the age of {ourAnimals[i, 0]}";
                            }
                    } while (validEntry == false);
                }
                validEntry = false;
                if (ourAnimals[i, 4] == "Physical description: " || ourAnimals[i, 4] == "Physical description: tbd")
                {
                    string message = $"Enter a physical description for {ourAnimals[i, 0]} (size, color, breed, gender, weight, housebroken)";
                    do {
                        // if physical description is default value, prompt for value
                        Console.WriteLine(message);
                        readResult = Console.ReadLine();
                        if (readResult != null)
                            animalPhysicalDescription = readResult;
                        //validate value
                        if (animalPhysicalDescription != null && animalPhysicalDescription.Length > 0 && (animalPhysicalDescription.Contains("male") || animalPhysicalDescription.Contains("female")) && (animalPhysicalDescription.Contains("small") || animalPhysicalDescription.Contains("medium") || animalPhysicalDescription.Contains("large")))
                            validEntry = true;
                        else 
                            message = $"Please enter a valid physical description for {ourAnimals[i, 0]}. Description must include size, color, breed, gender, weight, and housebroken.";
                        if (validEntry)
                        {
                            ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
                        }
                    } while (validEntry == false);
                }
            }
            Console.WriteLine("Age and physical description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;
        case "4": 
            //Ensure animal nicknames and personality descriptions are complete
            //iterate through entries
            for (int i = 0; i < maxPets; i++)
            {
                bool validEntry = false;
                if (ourAnimals[i, 0] == "ID #: ")
                {
                    continue;
                }
                if (ourAnimals[i, 3] == "Nickname: " || ourAnimals[i, 3] == "Nickname: tbd")
                {
                    string message = $"Enter a nickname for {ourAnimals[i, 0]}";
                    do {
                        // if  default value, prompt for value
                        Console.WriteLine(message);
                        readResult = Console.ReadLine();
                        if (readResult != null)
                            animalNickname = readResult;
                            // validate value
                        if (animalNickname != null && animalNickname.Length > 0)
                            validEntry = true;                            
                        if (validEntry)
                            {
                                ourAnimals[i, 3] = "Nickname: " + animalNickname;
                            }
                            else
                            {
                                message = $"Please enter a valid nickname for {ourAnimals[i, 0]}";
                            }
                    } while (validEntry == false);
                }
                validEntry = false;
                if (ourAnimals[i, 5] == "Personality: " || ourAnimals[i, 5] == "Personality: tbd")
                {
                    string message = $"Enter a personality description for {ourAnimals[i, 0]} (likes or dislikes, tricks, energy level)";
                    do {
                        // if personality is default value, prompt for value
                        Console.WriteLine(message);
                        readResult = Console.ReadLine();
                        if (readResult != null)
                            animalPersonalityDescription = readResult;
                        //validate value
                        if (animalPersonalityDescription != null && animalPersonalityDescription.Length > 0)
                            validEntry = true;
                        else 
                            message = $"Please enter a valid personality description for {ourAnimals[i, 0]}.";
                        if (validEntry)
                        {
                            ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
                        }
                    } while (validEntry == false);
                }
            }
            Console.WriteLine("Nickname and personality description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;
        case "5":
            //Edit an animal's age
            Console.WriteLine("UNDER CONSTRUCTION - please check back to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "6":
            //Edit an animal's personality description
            Console.WriteLine("UNDER CONSTRUCTION - please check back to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "7":
            //Display all cats with a specified characteristic
            Console.WriteLine("UNDER CONSTRUCTION - please check back to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "8":
            //Display all dogs with a specified characteristic
            string dogCharacteristic = "";
            bool searchAgain = true;

            while (searchAgain)
            {
                while (dogCharacteristic == "")
                {
                    Console.Write($"\nEnter one desired dog characteristic to search for: ");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        dogCharacteristic = readResult.ToLower().Trim();
                    }
                }
                bool noMatchesDog = true;
                //loop through the ourAnimals array to search for matching animals
                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 1].Contains("dog"))
                    {
                        string dogDescription = ourAnimals[i,4] + "\n" + ourAnimals[i,5];
                        if (dogDescription.Contains(dogCharacteristic))
                        {
                            Console.WriteLine($"\nOur dog {ourAnimals[i, 3]} is a match!");
                            Console.WriteLine(dogDescription);
                            noMatchesDog = false;
                        }
                    }
                }
                if (noMatchesDog)
                {
                    Console.WriteLine("None of our dogs are a match for: " + dogCharacteristic);
                }
                Console.WriteLine("Search again? (Y or N)");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    if (readResult == "N" || readResult == "n")
                    {
                        searchAgain = false;
                    }
                    else 
                    {
                        dogCharacteristic = "";
                    }
                }
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "Exit":
        case "exit":
            break;
        default: 
            Console.WriteLine("Invalid entry. Please try again.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
    }

} while (menuSelection != "exit");