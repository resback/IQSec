CREATE TABLE vehiculos(
vehiculoID int identity(1,1) primary key,
placas nvarchar(20)
)

CREATE TABLE estacionamiento(
estacionamientoID int identity(1,1) primary key,
placas nvarchar(20),
entrada datetime not null,
salida datetime 
)