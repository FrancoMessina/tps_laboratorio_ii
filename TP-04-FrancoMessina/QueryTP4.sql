create database TP4FRANCOMESSINA
GO
use TP4FRANCOMESSINA
GO
create table Clientes (
dni varchar(25) primary key,
nombre varchar(25) NOT NULL ,
apellido varchar(25) NOT NULL ,
numeroTel varchar(25) NOT NULL ,
dadoDeAlta bit NOT NULL 
)
create table Servicios (
precio float NOT NULL,
tipoEntrega int NOT NULL  ,
dni_cliente varchar(25) FOREIGN KEY REFERENCES Clientes(dni),
nombre varchar(25) NOT NULL,
marca varchar(25) NOT NULL ,
modelo varchar(25) NOT NULL ,
fallaUno varchar(25)  NULL ,
fallaDos varchar(25) NULL ,
fallaTres varchar(25) NULL ,
tipo int NULL
)


Insert into Clientes (dni,nombre,apellido,numeroTel,dadoDeAlta) values('10915906','Alejandro','Bongianni','1190762023',1);
Insert into Clientes (dni,nombre,apellido,numeroTel,dadoDeAlta) values('30910905','Mauricio','Cerizza','1190129009',1);
Insert into Clientes (dni,nombre,apellido,numeroTel,dadoDeAlta) values('31093020','Pepe','Argento','1130908080',1);
Insert into Clientes (dni,nombre,apellido,numeroTel,dadoDeAlta) values('34037812','Juan Martin','Del Potro','1190807629',1);


Insert into Servicios (precio,tipoEntrega,dni_cliente,nombre,marca,modelo,fallaUno,fallaDos,fallaTres,tipo) 
values(25950,0,10915906,'Televisor','Sony','T30Pulgadas','SinAudio','PantallaRota','SinImagen',0);
Insert into Servicios (precio,tipoEntrega,dni_cliente,nombre,marca,modelo,fallaUno,fallaDos,fallaTres,tipo) 
values(21100,0,10915906,'AireAcondicionado','Surrey','SoloFrio','PierdeAgua','SoloFrio','SoloCalor',NULL);
Insert into Servicios (precio,tipoEntrega,dni_cliente,nombre,marca,modelo,fallaUno,fallaDos,fallaTres,tipo) 
values(900,0,10915906,'Control','Surrey','IR','NoEmiteSenial','BajaSenial',NULL,1);
Insert into Servicios (precio,tipoEntrega,dni_cliente,nombre,marca,modelo,fallaUno,fallaDos,fallaTres,tipo) 
values(1000,1,30910905,'Control','Surrey','RF','BajaSenial','DisplayRoto',NULL,1);
Insert into Servicios (precio,tipoEntrega,dni_cliente,nombre,marca,modelo,fallaUno,fallaDos,fallaTres,tipo) 
values(28250,0,30910905,'Televisor','Philips','T40Pulgadas','SinAudio','PantallaRota',NULL,1);
Insert into Servicios (precio,tipoEntrega,dni_cliente,nombre,marca,modelo,fallaUno,fallaDos,fallaTres,tipo) 
values(15500,0,10915906,'AireAcondicionado','Samsung','SoloFrio','PierdeAgua','SoloFrio',NULL,NULL);
Insert into Servicios (precio,tipoEntrega,dni_cliente,nombre,marca,modelo,fallaUno,fallaDos,fallaTres,tipo) 
values(1000,0,10915906,'Control','Surrey','RF','BajaSenial','DisplayRoto',NULL,1);
Insert into Servicios (precio,tipoEntrega,dni_cliente,nombre,marca,modelo,fallaUno,fallaDos,fallaTres,tipo) 
values(1000,1,31093020,'Control','Surrey','RF','BajaSenial','DisplayRoto',NULL,1);
Insert into Servicios (precio,tipoEntrega,dni_cliente,nombre,marca,modelo,fallaUno,fallaDos,fallaTres,tipo) 
values(28250,0,34037812,'Televisor','Philips','T40Pulgadas','SinAudio','PantallaRota',NULL,1);
Insert into Servicios (precio,tipoEntrega,dni_cliente,nombre,marca,modelo,fallaUno,fallaDos,fallaTres,tipo) 
values(25950,0,34037812,'Televisor','Sony','T30Pulgadas','SinAudio','PantallaRota','SinImagen',0);