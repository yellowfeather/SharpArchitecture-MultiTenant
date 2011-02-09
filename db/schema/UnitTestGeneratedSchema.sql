
    if exists (select * from dbo.sysobjects where id = object_id(N'Tenants') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Tenants

    if exists (select * from dbo.sysobjects where id = object_id(N'hibernate_unique_key') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table hibernate_unique_key

    create table Tenants (
        Id INT not null,
       Name NVARCHAR(255) null,
       Domain NVARCHAR(255) null,
       ConnectionString NVARCHAR(255) null,
       primary key (Id)
    )

    create table hibernate_unique_key (
         next_hi INT 
    )

    insert into hibernate_unique_key values ( 1 )
