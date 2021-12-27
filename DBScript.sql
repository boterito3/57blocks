CREATE TABLE [dbo].[Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[Email] [nvarchar](500) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	UNIQUE ([Email]),
	PRIMARY KEY ([UserId])
)


CREATE TABLE [dbo].[Pokemons](
	[PokemonId] [uniqueidentifier] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[IsPublic] [bit] NOT NULL,
	PRIMARY KEY ([PokemonId]),
    FOREIGN KEY ([CreatedBy]) REFERENCES [Users]([UserId])
)

declare @userId1 uniqueidentifier = NEWID();
declare @userId2 uniqueidentifier = NEWID();

Insert Into [Users] values(@userId1, 'test@test.com', 'MsUYpBqL8mOgdrkuhOUs5SHLYYju7v7GX8ao5s6X3PA=')  --Password: C@miloTest123
Insert Into [Users] values(@userId2, 'test2@test.com', 'MsUYpBqL8mOgdrkuhOUs5SHLYYju7v7GX8ao5s6X3PA=') --Password: C@miloTest123

Insert Into [Pokemons] values (NEWID(), @userId1, 'Charizard', 1)
Insert Into [Pokemons] values (NEWID(), @userId1, 'Pikachu', 1)
Insert Into [Pokemons] values (NEWID(), @userId1, 'Dragonite', 0)
Insert Into [Pokemons] values (NEWID(), @userId2, 'Snorlax', 1)
Insert Into [Pokemons] values (NEWID(), @userId2, 'Mewtwo', 0)

/*
drop table [Pokemons]
drop table [Users]
*/