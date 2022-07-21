--select and delete in the same query
delete from dados_abertos_medicamentos where room_initiating_user_id in (select user_id from users where user_connected = 0)
  and room_target_user_id in (select user_id from users where user_connected = 0)
  
  --trim quotation marks
  UPDATE `dados_abertos_medicamentos` SET (`NOME_PRODUTO` = TRIM(BOTH '"' FROM `NOME_PRODUTO`), `CATEGORIA_REGULATORIA` = TRIM(BOTH '"' FROM `CATEGORIA_REGULATORIA`), `CLASSE_TERAPEUTICA` = TRIM(BOTH '"' FROM `CLASSE_TERAPEUTICA`), `PRINCIPIO_ATIVO` = TRIM(BOTH '"' FROM `PRINCIPIO_ATIVO`))
  
UPDATE dados_abertos_medicamentos SET NOME_PRODUTO = replace( replace(NOME_PRODUTO, ',', ''), '"', '' );