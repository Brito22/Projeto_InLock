USE inlock_games_TARDE
GO

INSERT INTO TIPO_DE_USUARIO (Titulo)
VALUES ('ADMINISTRADOR'), ('CLIENTE');
GO

INSERT INTO USUARIO(email, senha, idTipoUsuario)
VALUES ('admin@admin.com','admin', 1 ), ('cliente@cliente.com','cliente', 2);
GO

INSERT INTO ESTUDIO(nomeEstudio)
VALUES ('Blizzard' ), ('Rockstar Studios'),('Square Enix');
GO

INSERT INTO JOGOS(nomeJogo,descrição,dataLançamento,valor,idEstudio)
VALUES ('Diablo 3', 'é um jogo que contém bastante
ação e é viciante, seja você um novato ou um fã.','15-05-2012', 99, 1 ), ('Red Dead Redemption II','jogo
eletrônico de ação-aventura western.','26-10-2018', 120 , 2);
GO

INSERT INTO JOGOS (nomeJogo, descrição, dataLançamento,valor,idEstudio) 
VALUES (@nomeJogo, @descrição, @dataLançamento, @valor, @idEstudio)