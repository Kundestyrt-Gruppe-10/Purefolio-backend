# Database migrations

[Documentation](https://docs.microsoft.com/nb-no/ef/core/get-started/?tabs=netcore-cli)

To make changes to the model, first:

Install the migration tool globally

```jsx
dotnet tool install --global dotnet-ef
```

Make your changes to the model, then make the migrations with:

```jsx
dotnet ef migrations add <V02_name_of_migration>
```

To apply migrations to database:

```jsx
dotnet ef database update --context=DatabaseContext
```