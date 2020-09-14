# sw-mglt-calculator
MGLT Calculator provide the information of the numbers stops can a starship do to across one planet to another by given a distance in Mega lights

### How to get this project.
You can clone from this repository by using the command:
``` git clone https://github.com/AlexandreYembo/sw-mglt-calculator.git```

### Requirements
.Net core 3.1

#### How to run the project
Once  you've got the source code, you can run the project by navigating to the folder Kneat.Starwars.Console then you simply run the command:
```dotnet run```

Yuo can provide the number for the distance to get the number of stops for each Starship.


#### How to run the unit testing and integration test
You can run the test individually of on the root folder by executing the follow command:
```dotnet test```

#### Mega lights consumimable calculation: explanation
To calculate the stops it is necessary to provide the distance in Megalights, time consumable and the velocity in megaligth of the starship.

The formula is defined by:
``` stop = hours / consumable Hours ```

Where: hours is (distance / velocity in megalights) and consumable Hours is the hours calculated by the consumable of the starship.

Example:
```stops = ((Distance=1000 / MGLT = 70) / 730 (consumable = "1 month")) ```

For this project the consumable calculation uses the consume type that returns from each Starship. Based on this parameter, there is a interface ```IHoursCalculation``` that implements the proper type via Dependency injection to the concrete class byu using Func, the interface ```IHoursCalculation``` can implement multiple classes.

For example: Starship: Millennium Falcon has consumables equals "2 months", that means it will call the concrete class that returns number of hours by Month. This formula applies the number of days considering an average in relation of 365 days.

The concrete class ```HoursPerMonth``` is implemented by the configuration of Dependecy injection:
```c#
services.AddTransient<Func<string, IHoursCalculation>>(serviceProvider => timeType =>
            {
                switch (timeType.ToUpper())
                {
                ...
                case "MONTH":
                case "MONTHS":
                    return serviceProvider.GetService<HoursPerMonth>();
            }
}
```
Where ```serviceProvider``` is responsible to call the method GetService, to create the instance of ```HourPerMonth``` and timeType is the string that returns from the property ```Consumables```.

#### Code covered
The unit test is covering the code for the Hour calculation by day, week, month and year. Also there is covering for API client, MGLT calculation and the StarshipsService.

For the integration test it was tested end to end by using real data and the request to api and providing the real results.


#### Repository Layer
This layer uses the abstract class or interfaces that implements the concrete class from Infrastructure layer.

#### Infrastructure Layer
This layer provide external access for web api and it used to get the object from this external resource.

#### Service Layer
This layer implements the business roles and it is resposible to calculate the MGLT and to apply the result for each starship.


#### Console Application
This is the application that will accept the user inputs and will print the result of the objects taken from the API with the stop calculated.
