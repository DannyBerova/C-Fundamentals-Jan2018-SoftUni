public static class AnimalFactory
{
    public static Animal ProduceAnimal(string[] animalArgs)
    {
        Animal animal = null;

        var typeOfAnimal = animalArgs[0];
        var animalName = animalArgs[1];
        var animalWeight = double.Parse(animalArgs[2]);
        double wingSize;
        string livingRegion;
        string breed;

        switch (typeOfAnimal)
        {
            case "Hen":
                wingSize = double.Parse(animalArgs[3]);
                animal = new Hen(animalName, animalWeight, wingSize);
                break;
            case "Owl":
                wingSize = double.Parse(animalArgs[3]);
                animal = new Owl(animalName, animalWeight, wingSize);
                break;
            case "Dog":
                livingRegion = animalArgs[3];
                animal = new Dog(animalName, animalWeight, livingRegion);
                break;
            case "Mouse":
                livingRegion = animalArgs[3];
                animal = new Mouse(animalName, animalWeight, livingRegion);
                break;
            case "Cat":
                livingRegion = animalArgs[3];
                breed = animalArgs[4];
                animal = new Cat(animalName, animalWeight, livingRegion, breed);
                break;
            case "Tiger":
                livingRegion = animalArgs[3];
                breed = animalArgs[4];
                animal = new Tiger(animalName, animalWeight, livingRegion, breed);
                break;
            default:
                break;
        }
        return animal;
    }
}

