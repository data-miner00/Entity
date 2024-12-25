# Entity

Entity Framework research.

## Commands

### Code-first Approach

Whenever having a new changes to the models, e.g adding of new columns, need to add the migration first. A new folder named `Migrations` will be created if not already exist. The migration codes will be placed inside the folder.

```
Add-Migration 'migration-name'
# or
dotnet ef migrations add 'migration-name'
```

After that, need to synchronize the changes to the actual database.

```
Update-Database
# or
dotnet ef database update
```

Undo, remove migration can be performed as well.

```
Remove-Migration
```

### Database-first Approach

```
Scaffold-DbContext 'conn-str' Microsoft.EntityFrameworkCore.SqlServer -ContextDir Data -OutDir Models -DataAnnotation
```

## References

- [Entity Framework Tutorial](https://www.entityframeworktutorial.net/)
- [EF Migrations: Rollback last applied migration?](https://stackoverflow.com/questions/11904571/ef-migrations-rollback-last-applied-migration)
