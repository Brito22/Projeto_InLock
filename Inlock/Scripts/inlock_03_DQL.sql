USE inlock_games_TARDE
GO

SELECT * FROM ESTUDIO;
SELECT * FROM JOGOS;
SELECT * FROM USUARIO;
SELECT * FROM TIPO_DE_USUARIO;

SELECT nomeJogo, descrição, dataLançamento, valor, nomeEstudio FROM JOGOS
LEFT JOIN ESTUDIO
ON JOGOS.idEstudio = ESTUDIO.idEstudio
GO

SELECT nomeEstudio, nomeJogo as jogo FROM ESTUDIO
LEFT JOIN JOGOS
ON JOGOS.idEstudio = ESTUDIO.idEstudio
GO

SELECT nomeEstudio AS ESTUDIO, nomeJogo AS JOGO FROM JOGOS
RIGHT JOIN ESTUDIO
ON JOGOS.idEstudio = ESTUDIO.idEstudio
GO

SELECT * FROM USUARIO
WHERE email = 'admin@admin.com' and senha = 'admin'
GO

SELECT * FROM JOGOS
WHERE idJogo = 2
GO

SELECT * FROM ESTUDIO
WHERE idEstudio = 2
GO

   SELECT    idUsuario
			                                        ,email
			                                        ,senha
			                                        ,Titulo
                                          FROM USUARIO
                                          LEFT JOIN TIPO_DE_USUARIO
                                          ON USUARIO.idTipoUsuario = TIPO_DE_USUARIO.idTipoUsuario
                                          WHERE email = 'admin@admin.com'
                                          and senha ='admin' 

										      SELECT    idUsuario
			                                        ,email
			                                        ,senha
                                          FROM USUARIO
                                          WHERE email = 'admin@admin.com'
                                          and senha = 'admin']

										  SELECT idjogo, nomeJogo as Jogo, descrição, dataLançamento as DataLançamento, valor, nomeEstudio as Estudio FROM JOGOS LEFT JOIN ESTUDIO ON JOGOS.idEstudio = ESTUDIO.idEstudio


										  SELECT idJogo, nomeJogo as Jogo, descrição, dataLançamento as DataLançamento, valor, nomeEstudio as Estudio FROM JOGOS
                                            LEFT JOIN ESTUDIO
                                            ON JOGOS.idEstudio = ESTUDIO.idEstudio
                                            WHERE idJogo = 5
                                            