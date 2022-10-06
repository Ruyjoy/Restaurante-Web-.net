SET LANGUAGE spanish; 

USE master;

IF EXISTS (
	SELECT *
	FROM sysdatabases
	WHERE name = 'ComidaOnline'
)
BEGIN
	ALTER DATABASE ComidaOnline SET SINGLE_USER WITH ROLLBACK IMMEDIATE; 
	
	DROP DATABASE ComidaOnline;
END

CREATE DATABASE ComidaOnline;

go

use ComidaOnline;

create table Casas (
   Rut int primary key,
   Nombre varchar(30) not null,
   Especializacion varchar(30) not null
   );
   
create table Platos (
   Id int not null,
   Nombre varchar(30) not null,
   Foto varchar(50) not null,
   Precio float not null,
   Rut int foreign key references Casas (Rut),
   primary key (id, Rut)
   );
   
 
create table Usuarios(
   Cedula int primary key,
   NombreCompleto varchar(30) not null,
   Nombrelogueo varchar(30) unique not null,
   Contraseña varchar(30) not null
   );
   
   
create table Administrador(
   CedulaAdmin int primary key,
   Cargo varchar(30) not null
   foreign key (CedulaAdmin) references Usuarios(Cedula)
   );
   
create table Cliente(
   CedulaCliente int primary key,
   TarjetaCredito varchar(30) not null,
   Direccion varchar(30) not null
   foreign key (Cedulacliente) references Usuarios(Cedula)
   );  
    
create table Pedidos(
   Numero int identity primary key,
   Fecha dateTime not null,
   Cantidad int not null,
   Entregado bit not null,
   IdPlato int not null,
   Cedula int foreign key references Usuarios (Cedula) not null,
   Rut int not null,
   foreign key (IdPlato, Rut) references Platos (Id, Rut)
   );
   
insert into Usuarios
values (1,'jose','jose123','1')
insert into Administrador
values (1,'gerente');

insert into Usuarios
values (987,'Carlos','Carlos','123')
insert into Cliente
values (987, '555666', 'Montevideo');

insert into Usuarios
values (123,'Facundo','Facu','123')
insert into Cliente
values (123, '555666', 'Montevideo');

insert into Casas 
values (1,'Peppe','Vegetariano');

insert into Casas 
values (2,'Pizzeria','Pizzeria');

insert into Casas 
values (3,'Internacional','Internacional');

insert into Casas 
values (4,'Parrilla','Parrilla');

insert into Casas 
values (5,'Minutas','Minutas')

--insert into Platos
--values (1,'Ensalada', '~/FotosPLatos/ensalada.jpg', 100, 1);

insert into Platos
values (1,'Pizza', '~/FotosPlatos/imgres.jpg', 50, 2);

insert into Platos
values (1,'Ramen', '~/FotosPlatos/img_ramen_34672_600.jpg', 150, 3);

insert into Platos
values (1,'Parrilla', '~/FotosPlatos/Parrilla.jpg', 50, 4);

insert into Platos
values (1,'Minutas', '~/FotosPlatos/hamburguesa.jpg', 50, 5);

insert into Platos
values (2, 'Minutas', '~/FotosPlatos/Milanesa.jpg', 50, 5);

insert into Pedidos
values ('04/03/2017 14:14:00', 1, 0, 1, 123, 2)

insert into Pedidos
values ('05/03/2017 15:24:00', 1, 0, 1, 987, 3)

insert into Pedidos
values ('05/03/2017 15:25:00', 1, 0, 1, 987, 4)

insert into Pedidos
values ('05/03/2017 14:26:00', 1, 0, 1, 987, 5)

insert into Pedidos
values ('09/03/2017 16:32:00', 2, 0, 2, 123, 5)

go

create procedure BuscarCasa
@rut int
as
begin 
   select * 
   from Casas
   where rut = @rut;
end

go

create procedure ModificarCasa
@rut int,
@nombre varchar(30),
@especializacion varchar(30)
as
begin 
   update Casas
   set Nombre = @nombre, Especializacion = @especializacion
   where Rut = @rut;
end

go

create procedure AgregarCasa
@rut int,
@nombre varchar(30),
@especializacion varchar(30)
as
begin 
   insert into Casas
   values(@rut, @nombre, @especializacion);
end

go

create procedure EliminarCasa
@rut int
as
begin
  begin transaction
  
   delete Pedidos
   where Rut = @rut;
   
    if @@ERROR <> 0
   begin 
     rollback transaction
     return -2;
   end
   
   delete Platos
   where Rut = @rut;
   
   if @@ERROR <> 0
   begin 
     rollback transaction
     return -1;
   end
   
   delete Casas
   where Rut = @rut;
   
    if @@ERROR <> 0
   begin 
     rollback transaction
     return -3;
   end
   
   commit transaction;
end

go

create procedure ListarCasas
as
begin
   select * 
   from Casas;
end

go

create procedure BuscarPlato
@rut int,
@id int
as
begin 
   select Platos.*, Casas.Nombre as nombreCasa, Especializacion 
   from Platos inner join Casas 
     on Platos.Rut = Casas.Rut
   where PLatos.Rut = @rut and Id = @id;
end

go

create procedure ModificarPlato
@id int,
@rut int,
@nombre varchar(30),
@foto varchar(50),
@precio float
as
begin 
   update Platos
   set Nombre = @nombre, Foto = @foto, Precio = @precio
   where Rut = @rut and id = @id;
end

go

create procedure AgregarPlato
@rut int,
@nombre varchar(30),
@foto varchar(50),
@precio float
as
begin 

   if not exists(
   Select *
   from Casas
   Where Rut = @rut)

   begin 
     return -1;
   end
   
   declare @id int;
   
   if not exists (select *
                  from Platos 
                  where Rut = @rut)
   begin 
    set @id = 1;
    
     insert into Platos
   values(@id, @nombre, @foto, @precio, @rut);
   
    if @@ERROR <> 0
   begin 
     return -2;
   end
   
   return ;
   
   end
   
   select @id = MAX(Id) + 1
   from Platos
   where Rut = @rut;
   
   insert into Platos
   values(@id, @nombre, @foto, @precio, @rut);
   
    if @@ERROR <> 0
   begin 
     return -2;
   end
   
   return @id;
   
end
go

create procedure EliminarPlato
@id int,
@rut int
as
begin
  begin transaction
   
   delete Pedidos
   where Rut = @rut and IdPlato = @id;
   
   if @@ERROR <> 0
   begin 
     rollback transaction
     return -1;
   end
   
   delete Platos
   where Rut = @rut and id = @id;
   
   if @@ERROR <> 0
   begin 
     rollback transaction
     return -2;
   end
   
   commit transaction;
end

go

create procedure ListarPlatos
as
begin
   select Platos.*, Casas.Nombre as nombreCasa, Especializacion 
   from Platos inner join Casas 
     on Platos.Rut = Casas.Rut
end

go

create procedure BuscarAdministrador
@nombreLogueo varchar(30)
as
begin 
   select Usuarios.*, Cargo
   from Usuarios inner join Administrador
     on Usuarios.Cedula = Administrador.CedulaAdmin
   where Usuarios.Nombrelogueo = @nombreLogueo;
end

go

create procedure BuscarAdministradorCedula
@cedula int
as
begin 
   select Usuarios.*, Cargo
   from Usuarios inner join Administrador
     on Usuarios.Cedula = Administrador.CedulaAdmin
   where Usuarios.Cedula = @cedula;
end

go

create procedure BuscarCliente
@nombreLogueo varchar(30)
as
begin 
   select Usuarios.*, TarjetaCredito, Direccion
   from Usuarios inner join Cliente
     on Usuarios.Cedula = Cliente.CedulaCliente
   where Usuarios.Nombrelogueo = @nombreLogueo;
end

go

create procedure BuscarClienteCedula
@cedula int
as
begin 
   select Usuarios.*, TarjetaCredito, Direccion
   from Usuarios inner join Cliente
     on Usuarios.Cedula = Cliente.CedulaCliente
   where Usuarios.Cedula = @cedula;
end


go

create procedure AgregarAdministrador
@cedula int,
@nombreCompleto varchar(30),
@nombreLogueo varchar(30),
@contraceña varchar(30),
@cargo varchar(30)
as
begin
   begin transaction 
      if exists (select * 
         from Administrador 
         where CedulaAdmin = @cedula)
      begin 
       rollback transaction
       return -1;
      end
   
      if exists (select * 
         from Usuarios 
         where Nombrelogueo = @nombreLogueo)
      begin 
       rollback transaction
       return -2;
      end
      
      insert into Usuarios
      values (@cedula, @nombreCompleto, @nombreLogueo, @contraceña);
      
      if @@ERROR <> 0
      begin 
       rollback transaction
       return -3;
      end
      
      insert into Administrador
      values (@cedula, @cargo);
      
      if @@ERROR <> 0
      begin 
       rollback transaction
       return -4;
      end
      
    commit transaction;
end

go

create procedure AgregarCliente
@cedula int,
@nombreCompleto varchar(30),
@nombreLogueo varchar(30),
@contraceña varchar(30),
@tarjetaCredito varchar(30),
@direccion varchar(30)
as
begin
   if exists (select *
   from Usuarios
   where Cedula = @cedula)
   begin 
     return -1;
   end
   
   if exists (select *
   from Usuarios
   where Nombrelogueo = @nombreLogueo)
   begin 
     return -2;
   end

   begin transaction 
      insert into Usuarios
      values (@cedula, @nombreCompleto, @nombreLogueo, @contraceña);
      
      if @@ERROR <> 0
      begin 
       rollback transaction
       return -3;
      end
      
      insert into Cliente
      values (@cedula, @tarjetaCredito, @direccion);
      
      if @@ERROR <> 0
      begin 
       rollback transaction
       return -4;
      end
      
    commit transaction;
end

go

create procedure ModificarAdministrador
@cedula int,
@nombreCompleto varchar(30),
@nombreLogueo varchar(30),
@contraceña varchar(30),
@cargo varchar(30)
as
begin
   begin transaction 
      update Usuarios
      set NombreCompleto = @nombreCompleto, Nombrelogueo = @nombreLogueo, Contraseña = @contraceña
      where Cedula = @cedula;
      
      if @@ERROR <> 0
      begin 
       rollback transaction
       return -1;
      end
      
      update Administrador
      set Cargo = @cargo
      where CedulaAdmin = @cedula;
      
      if @@ERROR <> 0
      begin 
       rollback transaction
       return -2;
      end
      
    commit transaction;
end

go

create procedure EliminarAdministrador
@cedula int
as
begin
   begin transaction 
   
      delete Administrador
      where CedulaAdmin = @cedula;
      
      if @@ERROR <> 0
      begin 
       rollback transaction
       return -1;
      end
      
      delete Usuarios
      where Cedula = @cedula;
      
      if @@ERROR <> 0
      begin 
       rollback transaction
       return -2;
      end
      
    commit transaction;
end

go

create procedure AgregarPedido
@Fecha dateTime,
@Cantidad int,
@Entregado bit,
@IdPlato int,
@Cedula int,
@Rut int
as
begin
   if not exists (select *
   from Cliente
   where CedulaCliente = @Cedula)
   begin 
      return -1;
   end
   
   if not exists (select *
   from Casas
   where Rut = @Rut)
   begin 
      return -2;
   end
   
   if not exists (select *
   from Platos
   where Id = @IdPlato)
   begin 
      return -3;
   end
   
   insert into Pedidos
   values (@Fecha, @Cantidad, @Entregado, @IdPlato, @Cedula, @Rut);
   
   if @@ERROR <> 0
   begin 
      return -4;
   end
   
   return @@identity;
end

go

create procedure ListarPedidos
as
begin
 
 select Pedidos.*, Direccion, TarjetaCredito,Precio,Foto,platos.Nombre, Casas.Nombre as Casa ,Especializacion,Usuarios.NombreCompleto, Usuarios.Nombrelogueo, Usuarios.Contraseña
 from Usuarios inner join Cliente
 on Usuarios.Cedula = Cliente.CedulaCliente inner join Pedidos
 on Cliente.CedulaCliente = Pedidos.Cedula inner join Platos
 on Platos.Rut = Pedidos.Rut and Pedidos.IdPlato = Platos.Id inner join Casas
 on Casas.Rut = Platos.Rut
 Order by Fecha
 
 end
 
 go
 

create procedure BuscarPedido
@numero int
as
begin
 
 select Pedidos.*, Direccion, TarjetaCredito,Precio,Foto,platos.Nombre, Casas.Nombre as Casa ,Especializacion,Usuarios.NombreCompleto, Usuarios.Nombrelogueo, Usuarios.Contraseña
 from Usuarios inner join Cliente
 on Usuarios.Cedula = Cliente.CedulaCliente inner join Pedidos
 on Pedidos.Cedula = Cliente.CedulaCliente inner join Platos
 on Platos.Id = Pedidos.IdPlato inner join Casas
 on Platos.Rut = Casas.Rut
 where Pedidos.Numero = @numero
 
 end
 
 
 go

create procedure ModificarPedido
@numero int,
@Fecha dateTime,
@Cantidad int,
@Entregado bit,
@IdPlato int,
@Cedula int,
@Rut int
as
begin
   update Pedidos
      set Fecha = @Fecha, Cantidad = @Cantidad, Entregado = @Entregado, IdPlato = @IdPlato, Cedula = @Cedula, Rut = @Rut
      where Numero = @numero;
end

go

create procedure ListarPlatosCasa

@rut int
as
begin
   select Platos.*, Casas.Nombre as nombreCasa, Especializacion 
   from Platos inner join Casas 
     on Platos.Rut = Casas.Rut
     where Casas.Rut = @rut;
end

go
 