-- REGISTRAR UN DOCENTE
INSERT INTO Docentes (NumeroDeEmpleado,Nombres,Apellidos)
VALUES (1,'JOSE LUIS', 'GAXIOLA CASTRO');

SELECT * FROM Docentes;

-- DESC Docentes;
PRAGMA table_info(Docentes);
PRAGMA table_info(Actividades);


-- obtener el id de un docente a partir del numero de empleado
select id from Docentes where NumeroDeEmpleado=123;
-- el id del docente ó cero registros encontrados
       
       
-- INSERT múltiple
insert into Actividades (fechaderegistro, docenteid, ejetematico, subeje, descripcion)
values ('2023-09-14',1,'Eje 1','Subeje 1.1','Descripción 1.1'),
       ('2023-09-14',1,'Eje 1','Subeje 1.2','Descripción 1.2');


select * from Actividades;