# 57blocks- Pokemon API

The API is deployed in AZURE and ready to use, you can find the [Swagger Documentation Here](https://57blocks.azurewebsites.net/swagger/index.html )

In order to use it properly you need to:

1. Execute the `login` call in the Users controller, sending any of these credentials
- > User1: test@test.com, Password: C@miloTest123
- > User2: test2@test.com, Password: C@miloTest123
- > Both users have already privated and public pokemons.
2. In the response of `login` request you will receive the `accessToken`.
3. You will place that `accessToken` in the `Authorize` option in the top right of the swagger documentation.
4. After placing the `accessToken` you are free to use the endpoints as you wish


## Important Notes and Considerations:

- I decided to use a simple architecture with 2 layers (api, and domain) because a matter of time and complexity. In the future I could have more layers, and even separate all the database and data access by implementing a repository/unit of work pattern.
- I decided to use Mediator pattern with `MediatR` library which is widely used.
- The `SavePokemon` endpoint in the Pokemons controller, is capable of create new pokemons and update existent pokemons depends if you send the `PokemonId` property.
- The `Pokemon` object have a property called  `IsPublic` which is the flag to determine if the pokemon can be viewed for any person or not.
- Token expires after 20 minutes, so after that time you will need to generate a new token.
- Users can only Update or Delete the pokemons they own.
- The database is also in azure, so if you want to connect to it from SSMS, please provide me your `IP address` to whitelist you.
- In case you want to run it locally you only need to clone the repository, build it and execute it. Of course I have to whitelist your `IP address` first to be able to connect to the database.
- If you want to use a local database, there is a SQL script called `DBScript.sql` in the root of the repository, ready to be used. If you go this way remember to adjust the connection string in the `appsettings.json` file of the api.
- I did not have enough time to implement unit testing.
